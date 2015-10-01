using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmNhap : Form
    {
        public frmNhap()
        {
            InitializeComponent();
        }

        private Hashtable listMatHangOld = new Hashtable();

        private void frmNhap_Load(object sender, EventArgs e)
        {
            pckNgayNhap.Text = DateTime.Today.TimeOfDay.ToString();
            txtMaHoaDon.Text = LayMaHoaDonTheoNgay(DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString());
            txtGhiChu.Text = "";

            groupChiTietHDN.Enabled = false;
            btnGhi.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            txtGhiChu.Select();

            LoadComboboxLoaiMatHangTheoMaSanPham(cbxMaMatH,"");
            LoadComboboxLoaiMatHangTheoMaSanPham(cbxDauKhoa, "DAU");
            LoadComboboxLoaiMatHangTheoMaSanPham(cbxDay, "DAY");
            LoadComboboxLoaiMatHangTheoMaSanPham(cbxDai, "DAI");
            // Function hiển thị.
            HienThi();

        }

        private void LoadComboboxLoaiMatHangTheoMaSanPham(ComboBox cbxLoad, string strTienToMaMatHang)
        {
            string selectMatHang = "";
            if(strTienToMaMatHang == "")
                selectMatHang = "SELECT* FROM tblMatHang";
            else
                selectMatHang = "SELECT* FROM tblMatHang WHERE SUBSTRING(tblMatHang.MaMatH,1,3) = '" + strTienToMaMatHang + "'";
            try
            {
                DataSet ds = DataConn.GrdSource(selectMatHang);
                ds = DataConn.GrdSource(selectMatHang);
                cbxLoad.DataSource = ds.Tables[0];
                cbxLoad.DisplayMember = "TenMatH";
                cbxLoad.ValueMember = "MaMatH";
                if (ds.Tables[0].Rows.Count > 0 && strTienToMaMatHang == "")
                    maMatHang = ds.Tables[0].Rows[cbxLoad.SelectedIndex][0].ToString();                
            }
            catch (FormatException)
            {
                MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Hãy xem trợ giúp!");
            }
        }

        private string LayMaHoaDonTheoNgay(string ngayText)
        {
            string MaHD = "";
            int maSo = 1;
            string select1 = "select MaHD FROM tblHoaDonNhap";

            DataSet ds = DataConn.GrdSource(select1);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MaHD = ngayText + maSo.ToString("000");
            }
            else
            {
                SqlDataReader sqlData = DataConn.ThucHienReader(select1);
                try
                {
                    while (sqlData.Read())
                    {
                        string getMaHD = sqlData.GetString(0);
                        string getNgay = getMaHD.Substring(0, 8);
                        string getMa = getMaHD.Substring(8);
                        if (getMaHD.Length == 10)
                        {
                            getNgay = getMaHD.Substring(0, 7);
                            getMa = getMaHD.Substring(7);
                        }
                        if (getNgay == ngayText)
                        {
                            if (maSo == Convert.ToInt32(getMa))
                                maSo++;
                        }
                        MaHD = ngayText + maSo.ToString("000");
                    }
                }
                finally
                {
                    sqlData.Close();
                    sqlData.Dispose();
                }
            }
            return MaHD;
        }

        string maMatHang = "";
        //string v = "";
        private void cboMaMatH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaMatH.SelectedIndex >= 0)
            {
                maMatHang = cbxMaMatH.SelectedValue.ToString();
                if (maMatHang.Substring(0,3) == "MSP")
                {
                    cbxDay.Enabled = true;
                    cbxDauKhoa.Enabled = true;
                    cbxDai.Enabled = true;
                    txtSoLuongDay.Enabled = true;
                    txtSoLuongDau.Enabled = true;
                    txtSoLuongDai.Enabled = true;
                }
                else
                {
                    cbxDay.Enabled = false;
                    cbxDauKhoa.Enabled = false;
                    cbxDai.Enabled = false;
                    txtSoLuongDay.Enabled = false;
                    txtSoLuongDau.Enabled = false;
                    txtSoLuongDai.Enabled = false;
                }
                
                //v = cboMaMatH.SelectedValue.ToString();
                string select1 = "select dongia from tblmathang where MaMatH =N'" + cbxMaMatH.SelectedValue.ToString() + "'";
                SqlDataReader sqlData = DataConn.ThucHienReader(select1);
                try
                {
                    while (sqlData.Read())
                    {
                        txtDonGia.Text = sqlData.GetDouble(0).ToString();
                    }
                }
                finally
                {
                    sqlData.Close();
                    sqlData.Dispose();
                }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHoaDon.Text == "")
                {
                    MessageBox.Show("Hãy nhập mã hóa đơn!", "Chú ý!");
                    txtMaHoaDon.Select();
                    return;
                }
                if (pckNgayNhap.Text == "")
                {
                    MessageBox.Show("Hãy chọn ngày nhập!", "Chú ý!");
                    pckNgayNhap.Select();
                    return;
                }

                string select1 = "select tblHoaDonNhap.MaHD from tblHoaDonNhap";
                SqlDataReader sqlData = DataConn.ThucHienReader(select1);

                try
                {
                    while (sqlData.Read())
                    {
                        if (sqlData.GetString(0) == txtMaHoaDon.Text)
                        {
                            sqlData.Close();
                            sqlData.Dispose();
                            throw new SameKeyException();
                        }
                    }
                }
                finally
                {
                    sqlData.Close();
                    sqlData.Dispose();
                }

                string select = "";
                select = "insert into tblHoaDonNhap(MaHD,NgayNhap,GhiChu) values(N'" + txtMaHoaDon.Text + "',N'" + pckNgayNhap.Text + "',N'" + txtGhiChu.Text + "')";
                DataConn.ThucHienCmd(select);
                HienThi();

                groupChiTietHDN.Enabled = true;
                btnGhi.Enabled = true;
                txtGhiChu.ReadOnly = true;
                btnThem.Enabled = true;
                pckNgayNhap.Enabled = false;

                btnThem_Click(sender, e);

            }
            catch (SameKeyException)
            {
                MessageBox.Show("Đã có mã hóa đơn này!", "Thông báo!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Định dạng dữ liệu không đúng!", "Thông báo!");
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }

        }

        private void HienThi()
        {
            string select = "SELECT tblHoaDonNhap.MaHD [Mã hóa đơn],tblChiTietHDN.MaMatH [Mã mặt hàng],TenMatH [Mặt hàng],tblChiTietHDN.SoLuong [Số lượng],NgayNhap [Ngày nhập],tblChiTietHDN.DonGia [Đơn giá]" +
                " FROM tblHoaDonNhap INNER JOIN tblChiTietHDN ON tblHoaDonNhap.MaHD=tblChiTietHDN.MaHD" +
                " INNER JOIN tblMatHang ON tblChiTietHDN.MaMatH=tblMatHang.MaMatH" +
                " WHERE tblHoaDonNhap.MaHD='" + txtMaHoaDon.Text + "'";
            DataSet ds = DataConn.GrdSource(select);
            grdNhapHang.DataSource = ds.Tables[0];
            grdNhapHang.Refresh();
        }

        private void mặtHàngMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmNewMatH mhm = new frmNewMatH();
            //mhm.ShowDialog();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool SoSanhSoLuongTrongListOld(string maMH, string sLuong)
        {
            foreach (string key in listMatHangOld.Keys)
                if (key == maMH && listMatHangOld[key].ToString() == sLuong)
                    return true;
            return false;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiMatHangDaThem())
            {
                if (MessageBox.Show("Đã Thêm Mặt Hàng Này!\nBạn Muốn Sửa Lại Không?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    CapNhapThongTinMatHang(sender, e);
                }
            }
            else
            {
                try
                {
                    //Exception khi không đủ dữ liệu
                    if (cbxMaMatH.Text == "")
                    {
                        MessageBox.Show("Hãy chọn mặt hàng!", "Chú ý!");
                        cbxMaMatH.Select();
                        return;
                    }

                    if (!KiemTraDuLieuNhapSo()) return;

                    string sqlQuery;
                    //Thêm vào bảng tblChiTietHDN
                    sqlQuery = "insert into tblChiTietHDN(MaHD,MaMatH,SoLuong,DonGia) values(N'" + txtMaHoaDon.Text + "',N'" + maMatHang + "'," + txtSoLuong.Text + "," + txtDonGia.Text + ")";
                    DataConn.ThucHienCmd(sqlQuery);

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                    sqlQuery = "update tblMatHang set SoLuong=SoLuong+" + txtSoLuong.Text + ",DonGia='" + txtDonGia.Text + "' where MaMatH=N'" + maMatHang + "'";
                    DataConn.ThucHienCmd(sqlQuery);

                    listMatHangOld.Add(maMatHang, (double.Parse(txtSoLuong.Text)));

                    HienThi();
                    btnTongTien_Click(sender, e);
                    //MessageBox.Show("Nhập hàng thành công!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Hãy xem lại!");
                }
                catch (SameKeyException)
                {
                    MessageBox.Show("Đã nhập mặt hàng này!", "Thông báo!");
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Hãy nhập đủ các dữ liệu trước khi nhấn nút ghi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool KiemTraDuLieuNhapSo()
        {
            if (double.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                txtSoLuong.Select();
                return false;
            }
            if (!KiemTraSoNguyenText(txtSoLuong.Text)) return false;
            
            // Nếu Mặt Hàng Là Sản Phẩm
            if (maMatHang.Substring(0, 3) == "MSP")
            {
                if (double.Parse(txtSoLuongDau.Text) <= 0)
                {
                    MessageBox.Show("Số lượng Đầu phải lớn hơn 0!");
                    txtSoLuongDau.Select();
                    return false;
                }
                if (!KiemTraSoNguyenText(txtSoLuongDau.Text)) return false;

                if (double.Parse(txtSoLuongDay.Text) <= 0)
                {
                    MessageBox.Show("Số lượng Dây phải lớn hơn 0!");
                    txtSoLuongDay.Select();
                    return false;
                }
                if (!KiemTraSoNguyenText(txtSoLuongDay.Text)) return false;

                if (double.Parse(txtSoLuongDai.Text) <= 0)
                {
                    MessageBox.Show("Số lượng Đai phải lớn hơn 0!");
                    txtSoLuongDai.Select();
                    return false;
                }
                if (!KiemTraSoNguyenText(txtSoLuongDai.Text)) return false;
            }
            return true;
        }

        private bool KiemTraSoNguyenText(string strText)
        {
            int int0 = 0;
            if (!int.TryParse(strText, out int0))
            {
                MessageBox.Show("Nhập số nguyên !");
                txtSoLuong.Select();
                return false;
            }
            return true;
        }

        private bool KiemTraTonTaiMatHangDaThem()
        {
            string select1 = "select MaMatH from tblChiTietHDN WHERE MaHD='" + txtMaHoaDon.Text + "'";
            SqlDataReader sqlData = DataConn.ThucHienReader(select1);

            try
            {
                while (sqlData.Read())
                {
                    if (sqlData.GetString(0) == maMatHang)
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

        private void CapNhapThongTinMatHang(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaMatH.Text == "" && txtDonGia.Text == "" && txtSoLuong.Text == "")
                    throw new NotEnoughInfoException();
                if (double.Parse(txtSoLuong.Text) <= 0)
                {
                    MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                    txtSoLuong.Select();
                    return;
                }

                if(KiemTraTonTaiMatHangDaThem())
                {
                    if (SoSanhSoLuongTrongListOld(maMatHang, txtSoLuong.Text))
                    {
                        return;
                    }
                    else
                    {
                        string updateQuery = "";
                        // Trừ đi số lượng đã thêm trước đó.
                        updateQuery = "UPDATE tblMatHang SET SoLuong=SoLuong-" + double.Parse(listMatHangOld[maMatHang].ToString()) + " WHERE MaMatH=N'" + maMatHang + "'";
                        DataConn.ThucHienCmd(updateQuery);

                        //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                        updateQuery = "update tblMatHang set SoLuong=SoLuong+" + txtSoLuong.Text + ",DonGia='" + txtDonGia.Text + "' where MaMatH=N'" + maMatHang + "'";
                        DataConn.ThucHienCmd(updateQuery);

                        // Cập nhập lại số lượng mới.
                        updateQuery = "UPDATE tblChiTietHDN SET SoLuong=" + txtSoLuong.Text + ",DonGia=" + txtDonGia.Text + " WHERE MaHD='" + txtMaHoaDon.Text + "' AND MaMatH=N'" + maMatHang + "'";
                        DataConn.ThucHienCmd(updateQuery);
                    }
                }                  
                                
                CapNhapLaiSoLuongTrongListOld(maMatHang);
                HienThi();
                btnTongTien_Click(sender, e);
            }
            catch (NotEnoughInfoException)
            {
                MessageBox.Show("Hãy nhập dữ liệu để sửa!", "Thông báo!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Định dạng dữ liệu không đúng!", "Thông báo!");
            }
            catch (SameKeyException)
            {
                
            }
        }

        private void CapNhapLaiSoLuongTrongListOld(string maMH)
        {
            listMatHangOld.Remove(maMH);
            listMatHangOld.Add(maMH, (double.Parse(txtSoLuong.Text)));
        }

        private void grdNhapHang_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdNhapHang.RowCount > 0)
            {
                if (grdNhapHang.CurrentCell == null)
                    return;
                if (grdNhapHang.CurrentCell.RowIndex < grdNhapHang.RowCount)
                {
                    try
                    {
                        int hang = grdNhapHang.CurrentCell.RowIndex;
                        string select = "SELECT tblHoaDonNhap.MaHD,tblChiTietHDN.MaMatH,TenMatH,tblChiTietHDN.SoLuong,NgayNhap,tblChiTietHDN.DonGia" +
                                        " FROM tblHoaDonNhap INNER JOIN tblChiTietHDN ON tblHoaDonNhap.MaHD=tblChiTietHDN.MaHD" +
                                        " INNER JOIN tblMatHang ON tblChiTietHDN.MaMatH=tblMatHang.MaMatH" +
                                        " WHERE tblHoaDonNhap.MaHD=N'" + grdNhapHang.Rows[hang].Cells[0].Value.ToString() + "'" +
                                        " AND tblChiTietHDN.MaMatH=N'" + grdNhapHang.Rows[hang].Cells[2].Value.ToString() + "'";
                        DataSet ds = DataConn.GrdSource(select);

                        txtMaH.Text = ds.Tables[0].Rows[0]["MaMatH"].ToString();
                        cbxMaMatH.Text = ds.Tables[0].Rows[0]["TenMatH"].ToString();
                        txtMaHoaDon.Text = ds.Tables[0].Rows[0]["MaHD"].ToString();
                        txtSoLuong.Text = ds.Tables[0].Rows[0]["SoLuong"].ToString();
                        pckNgayNhap.Text = ds.Tables[0].Rows[0]["NgayNhap"].ToString();
                        txtDonGia.Text = ds.Tables[0].Rows[0]["DonGia"].ToString();
                        //MessageBox.Show(txtMaH.Text);
                        //v = ds.Tables[0].Rows[0]["MaMatH"].ToString();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Định dạng dữ liệu không đúng!", "Thông báo!");
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

        private void btnTongTien_Click(object sender, EventArgs e)
        {
            if (grdNhapHang.RowCount <= 0)
            {
                btnXoa.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                try
                {
                    if (txtMaHoaDon.Text == "")
                        throw new NotEnoughInfoException();

                    string sql = "SELECT MaHD FROM tblChiTietHDN";
                    SqlDataReader sqlData = DataConn.ThucHienReader(sql);
                    int c = 0;
                    while (sqlData.Read())
                    {
                        if (sqlData.GetString(0) == txtMaHoaDon.Text)
                        {
                            c = 1;
                        }
                    }

                    if (c == 0)
                    {
                        sqlData.Close();
                        sqlData.Dispose();
                        throw new NotEnoughInfoException();
                    }
                    else
                    {
                        sqlData.Close();
                        sqlData.Dispose();
                        string select = "SELECT SoLuong,DonGia FROM tblChiTietHDN WHERE MaHD='" + txtMaHoaDon.Text + "'";

                        SqlDataReader sqlData1 = DataConn.ThucHienReader(select);
                        double gia = 0;
                        double soluong = 0;
                        double tong = 0;
                        try
                        {
                            while (sqlData1.Read())
                            {
                                soluong = sqlData1.GetDouble(0);
                                gia = sqlData1.GetDouble(1);
                                tong += gia * soluong;
                            }
                        }
                        finally
                        {
                            sqlData1.Close();
                            sqlData1.Dispose();
                        }
                        string update = "UPDATE tblHoaDonNhap SET TongTien=" + tong.ToString() + " WHERE MaHD='" + txtMaHoaDon.Text + "'";
                        DataConn.ThucHienCmd(update);
                    }
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Bạn chưa nhập mã hóa đơn hoặc chưa có hóa đơn với mã này!", "Thông báo");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Định dạng dữ liệu không đúng!", "Thông báo!");
                }
                catch (Exception se)
                {
                    MessageBox.Show("" + se.Message);
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            //if (txtMaHoaDon.Text == "")
            //{
            //    MessageBox.Show("Hãy nhập mã hóa đơn để in!","Thông báo!");
            //    txtMaHoaDon.Select();
            //    return;
            //}
            //frmInHDN inhdn = new frmInHDN(txtMaHoaDon.Text);
            //inhdn.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbxMaMatH.Text = "";
            txtDonGia.Text = "0";
            txtSoLuong.Text = "0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "DELETE tblChiTietHDN WHERE MaHD='" + txtMaHoaDon.Text + "' AND MaMatH=N'" + maMatHang + "'";
                DataConn.ThucHienCmd(delete);
                //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                string select = "update tblMatHang set SoLuong=SoLuong-" + txtSoLuong.Text + ",DonGia='" + txtDonGia.Text + "' where MaMatH=N'" + maMatHang + "'";
                DataConn.ThucHienCmd(select);

                listMatHangOld.Remove(maMatHang);

                HienThi();
                btnTongTien_Click(sender, e);
            }
            catch (FormatException)
            {
                MessageBox.Show("Định dạng dữ liệu không đúng!", "Thông báo!");
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void pckNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            // DateTime.Today.Day.ToString() 
            txtMaHoaDon.Text = LayMaHoaDonTheoNgay(pckNgayNhap.Value.Day.ToString() + pckNgayNhap.Value.Month.ToString() + pckNgayNhap.Value.Year.ToString());
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (maMatHang.Substring(0, 3) == "MSP")
            {
                int int0 = 0;
                if (int.TryParse(txtSoLuong.Text, out int0))
                {
                    txtSoLuongDau.Text = txtSoLuongDay.Text = txtSoLuong.Text;
                }
            }
        }
    }
}