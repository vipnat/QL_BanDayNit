using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmMatHang : Form
    {
        public frmMatHang()
        {
            InitializeComponent();
        }
        private static CultureInfo ViCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private int intSelectIntem = 0;
        private string maLoaiHang = "MSP";
        //Load từ Grid lên các textbox
        private void grvHienThiList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grvHienThiList.RowCount > 0)
            {
                if (grvHienThiList.CurrentCell == null)
                    return;
                if (grvHienThiList.CurrentCell.RowIndex < grvHienThiList.RowCount)
                {
                    try
                    {
                        int hangSelect = grvHienThiList.CurrentCell.RowIndex;
                        string maMatHang = grvHienThiList.Rows[hangSelect].Cells[0].Value.ToString();
                        string select = "select MaMatH,TenMatH,SoLuong,DonGia from tblMatHang WHERE MaMatH=N'" + maMatHang + "' AND SUBSTRING(MaMatH,1,3) ='" + maLoaiHang + "'";
                        DataSet ds = DataConn.GrdSource(select);
                        string strChuoiMaHang = ds.Tables[0].Rows[0]["MaMatH"].ToString();
                        txtMaHang.Text = strChuoiMaHang.Substring(3);
                        lblMaHang.Text = strChuoiMaHang.Substring(0, 3);
                        ChonCheckedBoxTheoMaHang(lblMaHang.Text);
                        txtSoLuong.Text = ds.Tables[0].Rows[0]["SoLuong"].ToString();
                        txtDonGia.Text = ds.Tables[0].Rows[0]["DonGia"].ToString();
                        txtTenHang.Text = ds.Tables[0].Rows[0]["TenMatH"].ToString();
                        // Lấy Giá Bán Cho Khách Hàng Tự Do
                        string select1 = "select GiaBan from tblGiaBan WHERE MaMatH=N'" + maMatHang + "'";
                        DataSet ds1 = DataConn.GrdSource(select1);
                        txtGiaBan.Text = ds1.Tables[0].Rows[0]["GiaBan"].ToString();

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

        private void ChonCheckedBoxTheoMaHang(string strMa)
        {
            if (String.Compare(strMa, "MSP", true) == 0) rdbSanPham.Checked = true;
            if (String.Compare(strMa, "DAU", true) == 0) rdbDau.Checked = true;
            if (String.Compare(strMa, "DAI", true) == 0) rdbDai.Checked = true;
            if (String.Compare(strMa, "DAY", true) == 0) rdbDay.Checked = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void HienThi()
        {
            string select = "SELECT mh.MaMatH [Mã Hàng],TenMatH [Tên Hàng],SoLuong [Số Lượng],DonGia [Đơn Giá],gb.GiaBan [Giá Bán],gb.MaKH [Mã KH]" +
                            "FROM tblMatHang mh, tblGiaBan gb " +
                            "WHERE mh.MaMatH = gb.MaMatH AND SUBSTRING(mh.MaMatH,1,3) ='" + maLoaiHang + "' ORDER BY mh.MaMatH DESC";
            DataSet ds = DataConn.GrdSource(select);
            grvHienThiList.DataSource = ds.Tables[0];
            grvHienThiList.Refresh();
            if (ds.Tables[0].Rows.Count > 0)
            {

                grvHienThiList.CurrentCell = grvHienThiList.Rows[intSelectIntem].Cells[0];

                grvHienThiList.Columns[0].Width = 100;
                grvHienThiList.Columns[1].Width = 280;
                grvHienThiList.Columns[2].Width = 105;
                grvHienThiList.Columns[3].Width = 95;
                grvHienThiList.Columns[4].Width = 95;
                grvHienThiList.Columns[5].Width = 90;
                grvHienThiList.FirstDisplayedScrollingRowIndex = intSelectIntem;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuNhap()) return;
            if (KiemTraTrungMaMatHangTrongTable(lblMaHang.Text + txtMaHang.Text, "tblMatHang"))
            {
                if (MessageBox.Show("Đã Có Mặt Hàng Này!\nBạn Muốn Sửa Lại Không?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    intSelectIntem = grvHienThiList.CurrentCell.RowIndex;
                    CapNhapDuLieuMatHang(sender, e);
                    if (MessageBox.Show("Thêm Giá Bán Cho Từng Khách Hàng ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        HienThiFormNhapGia(lblMaHang.Text + txtMaHang.Text);
                    }
                }
            }
            else
            {
                try
                {
                    //Exception khi không đủ dữ liệu
                    if (txtMaHang.Text == "")
                    {
                        MessageBox.Show("Hãy nhập mã hàng!", "Chú ý");
                        txtMaHang.Select();
                        return;
                    }
                    if (txtTenHang.Text == "")
                    {
                        MessageBox.Show("Hãy nhập tên hàng!", "Chú ý");
                        txtTenHang.Select();
                        return;
                    }

                    string select1 = "select TenMatH from tblMatHang";
                    SqlDataReader sqlData1 = DataConn.ThucHienReader(select1);
                    if (sqlData1 != null)
                    {
                        while (sqlData1.Read())
                        {
                            if (sqlData1.GetString(0) == txtTenHang.Text)
                            {
                                sqlData1.Close();
                                sqlData1.Dispose();
                                throw new SameKeyException();
                            }
                        }
                    }
                    sqlData1.Close();
                    sqlData1.Dispose();

                    string select = "insert into tblMatHang values(N'" + lblMaHang.Text + txtMaHang.Text + "',N'" + txtTenHang.Text + "'," + txtSoLuong.Text + "," + txtDonGia.Text.Replace(",", ".") + ")";
                    DataConn.ThucHienCmd(select);

                    ThemGiaBanChoKhachHang(lblMaHang.Text + txtMaHang.Text, txtGiaBan.Text);

                    HienThi();
                    if (MessageBox.Show("Thêm Giá Bán Cho Từng Khách Hàng ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        HienThiFormNhapGia(lblMaHang.Text + txtMaHang.Text);
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Không đúng định dạng cần thiết! Hãy xem trợ giúp!");
                }
                catch (SameKeyException)
                {
                    MessageBox.Show("Đã có mặt hàng với mã hoặc tên này! Hãy nhập mặt hàng khác!");
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Không có đủ dữ liệu để thêm!");
                }
            }
        }

        private bool KiemTraDuLieuNhap()
        {
            int int0 = 0;
            float float0 = 0;
            if (!int.TryParse(this.txtSoLuong.Text, out int0))
            {
                MessageBox.Show("Số lượng là số nguyên !");
                txtSoLuong.Select();
                return false;
            };
            if (!int.TryParse(this.txtMaHang.Text, out int0))
            {
                MessageBox.Show("Nhập số nguyên cho Mã Hàng !");
                txtMaHang.Select();
                return false;
            }
            if (!float.TryParse(this.txtDonGia.Text, out float0))
            {
                MessageBox.Show("Nhập số nguyên cho Đơn Giá !");
                txtDonGia.Select();

                return false;
            }
            if (!float.TryParse(this.txtGiaBan.Text, out float0))
            {
                MessageBox.Show("Nhập số nguyên cho Giá Bán !");
                txtGiaBan.Select();
                return false;
            }
            if (double.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                txtSoLuong.Select();
                return false;
            }
            if (double.Parse(txtDonGia.Text) <= 0)
            {
                MessageBox.Show("Đơn giá không được nhỏ hơn 0!");
                txtDonGia.Select();
                return false;
            }
            if (double.Parse(txtGiaBan.Text) <= 0)
            {
                MessageBox.Show("Giá bán không được nhỏ hơn 0!");
                txtGiaBan.Select();
                return false;
            }
            return true;
        }

        private void ThemGiaBanChoKhachHang(string mahang, string giaban)
        {
            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            DataTable dtTable = dsKH.Tables[0];
            foreach (DataRow row in dtTable.Rows)
            {
                string maKH = row["MaKH"].ToString();
                string insertGia = "INSERT into tblGiaBan values(N'" + mahang + "',N'" + maKH + "'," + giaban.Replace(",", ".") + ")";
                DataConn.ThucHienCmd(insertGia);
            }
        }

        private void UpdateGiaBanKhachHangChung(string mahang, string giaban)
        {
            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            DataTable dtTable = dsKH.Tables[0];
            foreach (DataRow row in dtTable.Rows)
            {
                string maKH = row["MaKH"].ToString();
                string insertGia = "UPDATE tblGiaBan SET GiaBan='" + giaban.Replace(",", ".") + "' WHERE MaMatH='" + mahang + "' AND MaKH='" + maKH + "'";
                DataConn.ThucHienCmd(insertGia);
            }
        }

        private bool KiemTraTrungMaMatHangTrongTable(string strMaMH, string tableName)
        {
            //Exception khi trùng Mã mặt hàng (trùng khóa chính)
            string select1 = "select MaMatH from " + tableName;
            SqlDataReader sqlData = DataConn.ThucHienReader(select1);
            try
            {
                while (sqlData.Read())
                {
                    if (sqlData.GetString(0) == lblMaHang.Text + txtMaHang.Text)
                    {
                        sqlData.Close();
                        sqlData.Dispose();
                        return true;
                    }
                }
            }
            finally
            {
                sqlData.Close();
                sqlData.Dispose();
            }
            return false;
        }

        private void CapNhapDuLieuMatHang(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHang.Text == "" && txtSoLuong.Text == "" && txtDonGia.Text == "" && txtTenHang.Text == "" && txtGiaBan.Text == "")
                    throw new NotEnoughInfoException();

                string update = "UPDATE tblMatHang SET TenMatH=N'" + txtTenHang.Text + "',SoLuong='" + txtSoLuong.Text + "',DonGia='" + txtDonGia.Text.Replace(",", ".") + "' WHERE MaMatH=N'" + lblMaHang.Text + txtMaHang.Text + "'";
                DataConn.ThucHienCmd(update);
                if (MessageBox.Show("Cập Nhật Giá Chung Cho Khách Hàng ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    UpdateGiaBanKhachHangChung(lblMaHang.Text + txtMaHang.Text, txtGiaBan.Text);
                }
                else
                {
                    return;
                }
                HienThi();
            }
            catch (NotEnoughInfoException)
            {
                MessageBox.Show("Không có đủ dữ liệu để sửa!");
            }
        }

        private void HienThiFormNhapGia(string maMatHang)
        {
            frmNhapGiaBan frmNhapGia = new frmNhapGiaBan(maMatHang);
            frmNhapGia.MyLoadData = new frmNhapGiaBan.LoadData(HienThi);
            frmNhapGia.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm Tra Mặt Hàng Có Trong Hóa Đơn Nhập
                if (KiemTraTrungMaMatHangTrongTable(lblMaHang.Text + txtMaHang.Text, "tblChiTietHDN"))
                {
                    MessageBox.Show("Có Hóa Đơn Nhập Liên Quan Mặt Hàng Này!\nBạn hãy xóa hóa đơn liên quan trước!", "Chú ý!");
                    return;
                }

                // Kiểm cra Mặt Hàng Có Trong Hóa Đơn Xuất
                if (KiemTraTrungMaMatHangTrongTable(lblMaHang.Text + txtMaHang.Text, "tblChiTietHDX"))
                {
                    MessageBox.Show("Có Hóa Đơn Xuất Liên Quan Mặt Hàng Này!\nBạn hãy xóa hóa đơn liên quan trước!", "Chú ý!");
                    return;
                }

                string deleteGb = "DELETE tblGiaBan WHERE MaMatH=N'" + lblMaHang.Text + txtMaHang.Text + "'";
                DataConn.ThucHienCmd(deleteGb);

                string delete = "DELETE tblMatHang WHERE MaMatH=N'" + lblMaHang.Text + txtMaHang.Text + "'";
                DataConn.ThucHienCmd(delete);

                HienThi();
            }
            catch (SameKeyException)
            {
                MessageBox.Show("Có thể có hóa đơn liên quan đến mặt hàng này! Bạn hãy xóa hóa đơn liên quan trước!", "Chú ý!");
            }
        }

        private void rdbSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSanPham.Checked) lblMaHang.Text = maLoaiHang = "MSP";
            if (rdbDay.Checked) lblMaHang.Text = maLoaiHang = "DAY";
            if (rdbDau.Checked) lblMaHang.Text = maLoaiHang = "DAU";
            if (rdbDai.Checked) lblMaHang.Text = maLoaiHang = "DAI";
            HienThi();
        }

        private void txtMaHang_Leave(object sender, EventArgs e)
        {
            int int0 = 0;
            if (!int.TryParse(this.txtMaHang.Text, out int0))
            {
                MessageBox.Show("Nhập Số Nguyên Cho Mã Hàng !");
                txtMaHang.Select();
                return;
            }
            txtMaHang.Text = String.Format("{0:000}", double.Parse(txtMaHang.Text));
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;

            string decimalString = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char decimalChar = Convert.ToChar(decimalString);

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            { }
            else if (e.KeyChar == decimalChar && txtDonGia.Text.IndexOf(decimalString) == -1)
            { }
            else if (e.KeyChar == decimalChar && txtGiaBan.Text.IndexOf(decimalString) == -1)
            { }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}