using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmDanhSachHDX : Form
    {
        public frmDanhSachHDX()
        {
            InitializeComponent();
        }

        int sohangChon = 0;
        bool checkHienThiChiTiet = false;
        private void frmDanhSachHDX_Load(object sender, EventArgs e)
        {
            chkListBox.Items.Insert(0, "Mã hóa đơn");
            chkListBox.Items.Insert(1, "Tên nhân viên");
            chkListBox.Items.Insert(2, "Mã mặt hàng");
            chkListBox.Items.Insert(3, "Tên mặt hàng");
            chkListBox.Items.Insert(4, "Số lượng");
            chkListBox.Items.Insert(5, "Ngày xuất");
            chkListBox.Items.Insert(6, "Đơn giá");
            chkListBox.Items.Insert(7, "Ghi chú");
            HienThi();
        }

        private void HienThi()
        {
            string select = "SELECT tblHoaDonXuat.MaHD [Mã hóa đơn],tblNhanVien.TenNhanVien [Nhân viên],tblChiTietHDX.MaMatH [Mã hàng],tblMatHang.TenMatH [Mặt hàng],tblChiTietHDX.SoLuong [Số lượng],tblHoaDonXuat.NgayXuat [Ngày xuất],tblChiTietHDX.DonGia [Đơn giá],tblHoaDonXuat.GhiChu [Ghi chú]" +
                            " FROM tblHoaDonXuat INNER JOIN tblChiTietHDX ON tblHoaDonXuat.MaHD=tblChiTietHDX.MaHD" +
                            " INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDX.MaMatH" +
                            " INNER JOIN tblNhanVien ON tblNhanVien.MaNhanVien=tblHoaDonXuat.MaNhanVien";
            DataSet ds = DataConn.GrdSource(select);
            grdView.DataSource = ds.Tables[0];
            grdView.Refresh();
            checkHienThiChiTiet = true;
        }

        private void HienThiHD()
        {
            string select = "SELECT hdx.MaHD [Mã HĐ],hdx.MaNhanVien [Mã NV],hdx.NgayXuat [Ngày Xuất],hdx.TongTien[Tổng Tiền],SUM(ctx.SoLuong) [Tổng Số Lượng],hdx.GhiChu [Ghi Chú] FROM tblHoaDonXuat hdx JOIN tblChiTietHDX ctx ON hdx.MaHD = ctx.MaHD GROUP BY hdx.MaHD,hdx.MaNhanVien,hdx.NgayXuat,hdx.TongTien,hdx.GhiChu ORDER BY hdx.NgayXuat DESC";
            DataSet ds = DataConn.GrdSource(select);
            grdView.DataSource = ds.Tables[0];
            grdView.Refresh();
            checkHienThiChiTiet = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string strTenMH = grdView.Rows[sohangChon].Cells[3].Value.ToString();
            string strMaHD = grdView.Rows[sohangChon].Cells[0].Value.ToString();
            string strMaMH = grdView.Rows[sohangChon].Cells[2].Value.ToString();

            if (checkHienThiChiTiet)
                if (MessageBox.Show("Xóa Sản Phẩm: " + strTenMH + " Trong HĐ ?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    string sqlDelete = "DELETE FROM tblChiTietHDX WHERE MaHD=N'" + strMaHD + "' AND MaMatH='" + strMaMH + "'";
                    DataConn.ThucHienCmd(sqlDelete);

                    UpdateTongTien(strMaHD);

                    btnXemHoaDon_Click(sender, e);
                }
        }

        private string LayTongTienCuaMaHoaDon(string maHD)
        {
            string selectTongTien = "SELECT SUM(SoLuong*DonGia) AS TongTien FROM tblChiTietHDX WHERE MaHD='" + maHD + "'";
            DataSet dsTongTien = DataConn.GrdSource(selectTongTien);
            string getTongTien = dsTongTien.Tables[0].Rows[0]["TongTien"].ToString();
            if (getTongTien == "") return "0";
            return getTongTien;
        }

        private void UpdateTongTien(string maHoaDon)
        {
            float tongTien = float.Parse(LayTongTienCuaMaHoaDon(maHoaDon));
            float tongTienGoc = 0;

            string sqlSelectHDX = "SELECT [MaMatH],[SoLuong] FROM [tblChiTietHDX] WHERE MaHD='"+ maHoaDon + "'";
            DataSet dsHoaDonXuat = DataConn.GrdSource(sqlSelectHDX);
            DataTable dtTableHDX = dsHoaDonXuat.Tables[0];

            foreach (DataRow row in dtTableHDX.Rows)
            {
                string maMHang = row["MaMatH"].ToString();
                double soLuong = Convert.ToDouble(row["SoLuong"].ToString());
                string getTongTienGoc = "SELECT (DonGia*" + soLuong + ")AS TongGoc FROM tblMatHang WHERE MaMatH = N'" + maMHang + "'";
                tongTienGoc = tongTienGoc + DataConn.Lay1GiaFloat_ExecuteScalar(getTongTienGoc);
            }

            // Update Tiền Gốc Hóa Đơn
            string updateTongTienGoc = "UPDATE [tblHoaDonXuat] SET [TongTienGoc] = @TongGoc WHERE MaHD='" + maHoaDon + "'";
            DataConn.ThucHienInsertSqlParameter(updateTongTienGoc, "@TongGoc", tongTienGoc);

            // Update Tổng Tiền Hóa Đơn
            string updateTongTien = "UPDATE [tblHoaDonXuat] SET [TongTien] = @TTien WHERE MaHD='" + maHoaDon + "'";
            DataConn.ThucHienInsertSqlParameter(updateTongTien, "@TTien", tongTien);

        }

        private void grdView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdView.RowCount > 0)
            {
                if (grdView.CurrentCell == null)
                    return;
                if (grdView.CurrentCell.RowIndex < grdView.RowCount)
                {
                    if (!cbxChiTiet.Checked)
                    {
                        int hang = grdView.CurrentCell.RowIndex;
                        string select = "SELECT *FROM tblHoaDonXuat WHERE tblHoaDonXuat.MaHD=N'" + grdView.Rows[hang].Cells[0].Value.ToString() + "'";
                        DataSet ds = DataConn.GrdSource(select);
                        txtMa.Text = ds.Tables[0].Rows[0]["MaHD"].ToString();
                    }
                    else
                        try
                        {
                            int hang = grdView.CurrentCell.RowIndex;
                            string select = "SELECT tblHoaDonXuat.MaHD,tblNhanVien.TenNhanVien,tblChiTietHDX.MaMatH,tblMatHang.TenMatH,tblChiTietHDX.SoLuong,tblHoaDonXuat.NgayXuat,tblChiTietHDX.DonGia,tblHoaDonXuat.GhiChu" +
                                " FROM tblHoaDonXuat INNER JOIN tblChiTietHDX ON tblHoaDonXuat.MaHD=tblChiTietHDX.MaHD" +
                                " INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDX.MaMatH" +
                                " INNER JOIN tblNhanVien ON tblNhanVien.MaNhanVien=tblHoaDonXuat.MaNhanVien" +
                                " WHERE tblHoaDonXuat.MaHD=N'" + grdView.Rows[hang].Cells[0].Value.ToString() + "'" +
                                " AND tblChiTietHDX.MaMatH=N'" + grdView.Rows[hang].Cells[2].Value.ToString() + "'";
                            DataSet ds = DataConn.GrdSource(select);
                            txtMa.Text = ds.Tables[0].Rows[0]["MaHD"].ToString();
                        }
                        catch (Exception se)
                        {
                            MessageBox.Show("" + se.Message);
                        }
                }
                else
                    return;
            }
        }

        private void chkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkListBox.GetItemChecked(0) == true)
                grdView.Columns[0].Visible = true;
            else
                grdView.Columns[0].Visible = false;

            if (chkListBox.GetItemChecked(1) == true)
                grdView.Columns[1].Visible = true;
            else
                grdView.Columns[1].Visible = false;

            if (chkListBox.GetItemChecked(2) == true)
                grdView.Columns[2].Visible = true;
            else
                grdView.Columns[2].Visible = false;

            if (chkListBox.GetItemChecked(3) == true)
                grdView.Columns[3].Visible = true;
            else
                grdView.Columns[3].Visible = false;

            if (chkListBox.GetItemChecked(4) == true)
                grdView.Columns[4].Visible = true;
            else
                grdView.Columns[4].Visible = false;

            if (chkListBox.GetItemChecked(5) == true)
                grdView.Columns[5].Visible = true;
            else
                grdView.Columns[5].Visible = false;
            if (cbxChiTiet.Checked == true)
            {
                if (chkListBox.GetItemChecked(6) == true)
                    grdView.Columns[6].Visible = true;
                else
                    grdView.Columns[6].Visible = false;

                if (chkListBox.GetItemChecked(7) == true && cbxChiTiet.Checked == true)
                    grdView.Columns[7].Visible = true;
                else
                    grdView.Columns[7].Visible = false;
            }

            //if (chkListBox.GetItemChecked(8) == true)
            //    grdView.Columns[8].Visible = true;
            //else
            //    grdView.Columns[8].Visible = false;

            //if (chkListBox.GetItemChecked(9) == true)
            //    grdView.Columns[9].Visible = true;
            //else
            //    grdView.Columns[9].Visible = false;
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            //if (txtMa.Text == "")
            //{
            //    MessageBox.Show("Hóa đơn xuất này chưa có hoặc bạn chưa chọn hóa đơn!");
            //    return;
            //}
            //frmInHDX inhdx = new frmInHDX(txtMa.Text);
            //inhdx.ShowDialog();
        }

        private void cbxChiTiet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxChiTiet.Checked == false)
            {
                HienThiHD();
            }
            else
            {
                HienThi();
            }
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            string select = "SELECT tblHoaDonXuat.MaHD,tblNhanVien.TenNhanVien,tblChiTietHDX.MaMatH,tblMatHang.TenMatH,tblChiTietHDX.SoLuong,tblHoaDonXuat.NgayXuat,tblChiTietHDX.DonGia ,tblHoaDonXuat.GhiChu FROM tblHoaDonXuat  INNER JOIN tblChiTietHDX ON tblHoaDonXuat.MaHD=tblChiTietHDX.MaHD INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDX.MaMatH INNER JOIN tblNhanVien ON tblNhanVien.MaNhanVien=tblHoaDonXuat.MaNhanVien Where tblChiTietHDX.MaHD ='" + txtMa.Text + "'";
            DataSet ds = DataConn.GrdSource(select);
            grdView.DataSource = ds.Tables[0];
            grdView.Refresh();
            checkHienThiChiTiet = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sohangChon = grdView.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
        }
    }
}