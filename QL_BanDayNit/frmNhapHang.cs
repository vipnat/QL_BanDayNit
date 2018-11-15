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

        public delegate void LoadDataMH();
        public LoadDataMH MyLoadDataBanHang;

        private int intSelectIntem = 0;
        private Hashtable listMatHangOld = new Hashtable();
        private Hashtable listCheckDauDayDai = new Hashtable();
        /**** listCheckDauDayDai 
        Value = 0 Không Kèm Đầu Đai
        Value = 1 Dây Có Đai
        *****/
        string maMatHang = "";
        string maDay = "";
        string maDau = "";
        string maDai = "";

        private void frmNhap_Load(object sender, EventArgs e)
        {
            pckNgayNhap.Text = DateTime.Today.TimeOfDay.ToString();
            txtMaHoaDon.Text = LayMaHoaDonTheoNgay(DateTime.Today.Day.ToString("00") + DateTime.Today.Month.ToString("00") + DateTime.Today.Year.ToString());
            txtGhiChu.Text = "";

            groupChiTietHDN.Enabled = false;
            btnGhi.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            txtGhiChu.Select();

            //LoadComboboxLoaiMatHangTheoMaSanPham(cbxTenMatHang, "");
            LoadComboboxMatHang();
            LoadComboboxLoaiMatHangTheoMaSanPham(cbxDauKhoa, "DAU");
            LoadComboboxLoaiMatHangTheoMaSanPham(cbxDay, "DAY");
            LoadComboboxLoaiMatHangTheoMaSanPham(cbxDai, "DAI");

            cbDai_CheckedChanged(sender, e);
            cbDauDay_CheckedChanged(sender, e);

            // Function hiển thị.
            HienThi();

        }

        private void LoadComboboxLoaiMatHangTheoMaSanPham(ComboBox cbxLoad, string strTienToMaMatHang)
        {
            string selectMatHang = "";
            if (strTienToMaMatHang == "")
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
                        if (getMaHD.Length == 11)
                        {
                            getNgay = getMaHD.Substring(0, 8);
                            getMa = getMaHD.Substring(8);
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

        //string v = "";
        private void cboMaMatH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDauDay.Checked = false;
            cbDai.Checked = false;

            if (cbxTenMatHang.SelectedIndex >= 0)
            {
                maMatHang = cbxTenMatHang.SelectedValue.ToString();
                if (maMatHang.Substring(0, 3) == "MSP")
                {
                    //cbxDay.Enabled = true;
                    //cbxDauKhoa.Enabled = true;
                    //cbxDai.Enabled = true;
                    cbDauDay.Enabled = true;
                    cbDai.Enabled = true;
                }
                else
                {
                    //cbxDay.Enabled = false;
                    //cbxDauKhoa.Enabled = false;
                    //cbxDai.Enabled = false;
                    cbDauDay.Enabled = false;
                    cbDai.Enabled = false;
                }

                //v = cboMaMatH.SelectedValue.ToString();
                if (groupChiTietHDN.Enabled)
                {
                    string select1 = "select DonGia from tblMatHang where MaMatH =N'" + cbxTenMatHang.SelectedValue.ToString() + "'";
                    SqlDataReader sqlData = DataConn.ThucHienReader(select1);
                    try
                    {
                        while (sqlData.Read())
                        {
                            txtDonGia.Text = sqlData.GetDecimal(0).ToString();
                        }
                    }
                    finally
                    {
                        sqlData.Close();
                        sqlData.Dispose();
                    }
                }

            }
        }

        private void cbxDauKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDauKhoa.SelectedIndex >= 0)
            {
                maDau = cbxDauKhoa.SelectedValue.ToString();
            }
        }

        private void cbxDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDay.SelectedIndex >= 0)
            {
                maDay = cbxDay.SelectedValue.ToString();
            }
        }

        private void cbxDai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDai.SelectedIndex >= 0)
            {
                maDai = cbxDai.SelectedValue.ToString();
            }
        }


        private void btnNhap_Click(object sender, EventArgs e)
        {
            maMatHang = cbxTenMatHang.SelectedValue.ToString();
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
                select = "insert into tblHoaDonNhap(MaHD,NgayNhap,GhiChu) values(N'" + txtMaHoaDon.Text + "',N'" + pckNgayNhap.Value.ToString("MM/dd/yyyy") + "',N'" + txtGhiChu.Text + "')";
                DataConn.ThucHienCmd(select);
                HienThi();

                groupChiTietHDN.Enabled = true;
                btnGhi.Enabled = true;
                txtGhiChu.ReadOnly = true;
                btnThem.Enabled = true;
                pckNgayNhap.Enabled = false;

                cbxDauKhoa_SelectedIndexChanged(sender, e);
                cbxDay_SelectedIndexChanged(sender, e);
                cbxDai_SelectedIndexChanged(sender, e);

                btnThem_Click(sender, e);
                btnThem.Enabled = false;

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

        private bool KiemTraSoLuongTrongKhoTheoMaMH(string _strMaMatHang)
        {
            bool _kiemTra = true;
            string selectSoLuong = "SELECT SoLuong FROM tblMatHang WHERE MaMatH='" + _strMaMatHang + "'";
            int _intSoLuongBanDau = DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectSoLuong);
            if (KiemTraTonTaiMatHangDaThem()) // Nếu Là Update
            {
                // Kiểm Tra Mặt Hàng Là Đầu - Đai - Dây
                string _strTienToMa = _strMaMatHang.Substring(0, 3);
                if (_strTienToMa == "DAY" || _strTienToMa == "DAU" || _strTienToMa == "DAI")
                {
                    // Lấy Lại Số Lượng Ban Đầu
                    _intSoLuongBanDau = _intSoLuongBanDau + int.Parse(listMatHangOld[maMatHang].ToString());
                }
            }

            if (_intSoLuongBanDau < double.Parse(txtSoLuong.Text))
            {
                _kiemTra = false;
            }
            return _kiemTra;
        }

        private void HienThi()
        {
            string select = "SELECT tblHoaDonNhap.MaHD [Mã HĐ],tblChiTietHDN.MaMatH [Mã MH],TenMatH [Mặt Hàng],tblChiTietHDN.SoLuong [Số Lượng],tblChiTietHDN.DonGia [Đơn Giá]" +
                " FROM tblHoaDonNhap INNER JOIN tblChiTietHDN ON tblHoaDonNhap.MaHD=tblChiTietHDN.MaHD" +
                " INNER JOIN tblMatHang ON tblChiTietHDN.MaMatH=tblMatHang.MaMatH" +
                " WHERE tblHoaDonNhap.MaHD='" + txtMaHoaDon.Text + "'";
            DataSet ds = DataConn.GrdSource(select);
            grdNhapHang.DataSource = ds.Tables[0];
            grdNhapHang.Refresh();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdNhapHang.CurrentCell = grdNhapHang.Rows[intSelectIntem].Cells[0];
                grdNhapHang.Columns[2].Width = 250;
                grdNhapHang.FirstDisplayedScrollingRowIndex = intSelectIntem;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (grdNhapHang.RowCount > 0)
                if (MessageBox.Show("Hoàn Thành Hóa Đơn Và Thoát ?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                    this.Close();
            else this.Close();
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
                    intSelectIntem = grdNhapHang.CurrentCell.RowIndex;
                    CapNhapThongTinMatHang(sender, e);
                }
            }
            else
            {
                try
                {
                    //Exception khi không đủ dữ liệu
                    if (cbxTenMatHang.Text == "")
                    {
                        MessageBox.Show("Hãy chọn mặt hàng!", "Chú ý!");
                        cbxTenMatHang.Select();
                        return;
                    }

                    if (!KiemTraDuLieuNhapSo()) return;

                    string sqlQuery;  // Chuỗi Query
                    string _strChuoiMa = ""; // Kiểm Tra Hàng Nhập Có Thêm Đai

                    // Kiểm Tra Mặt Hàng Thêm Vào Là Sản Phẩm 
                    if (maMatHang.Substring(0, 3) == "MSP")
                    {
                        if (cbDauDay.Checked)
                        {
                            if (!KiemTraSoLuongTrongKhoTheoMaMH(maDau))
                            {
                                MessageBox.Show("Số Đầu Còn Lại Không Đủ !");
                                return;
                            }
                            if (!KiemTraSoLuongTrongKhoTheoMaMH(maDay))
                            {
                                MessageBox.Show("Số Dây Còn Lại Không Đủ !");
                                return;
                            }
                            _strChuoiMa = _strChuoiMa + maDau + maDay;
                            string _sqlSLDai = "";
                            if (cbDai.Checked == true) // Nếu Có Sử Dụng Đai
                            {
                                if (!KiemTraSoLuongTrongKhoTheoMaMH(maDai))
                                {
                                    MessageBox.Show("Số Đai Còn Lại Không Đủ !");
                                    return;
                                }
                                _strChuoiMa = _strChuoiMa + maDai;
                                _sqlSLDai = " OR MaMatH=N'" + maDai + "'";
                            }

                            /**** Update Lại Số Lượng Đầu Đai ****/
                            // Query Cập nhật lại Số Lượng Dây Và Đầu Thêm Vào
                            sqlQuery = "UPDATE tblMatHang SET SoLuong=SoLuong-" + txtSoLuong.Text + " " +
                                       "WHERE MaMatH=N'" + maDay + "' OR MaMatH=N'" + maDau + "'" + _sqlSLDai;
                            DataConn.ThucHienCmd(sqlQuery);
                        }
                    }

                    // Add Value vào List check tồn tại Đầu - Dây - Đai (0 = không đai, 1 = có đai)
                    listCheckDauDayDai.Add(maMatHang, _strChuoiMa);

                    //Thêm vào bảng tblChiTietHDN
                    sqlQuery = "insert into tblChiTietHDN(MaHD,MaMatH,SoLuong,DonGia) values(N'" + txtMaHoaDon.Text + "',N'" + maMatHang + "'," + txtSoLuong.Text + ",@prDonGia)";
                    DataConn.ThucHienInsertSqlParameter(sqlQuery, "@prDonGia", float.Parse(txtDonGia.Text));

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                    sqlQuery = "update tblMatHang set SoLuong=SoLuong+" + txtSoLuong.Text + ",DonGia=@prDonGia where MaMatH=N'" + maMatHang + "'";
                    DataConn.ThucHienInsertSqlParameter(sqlQuery, "@prDonGia", float.Parse(txtDonGia.Text));

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
            double _soLuongSanPham = double.Parse(txtSoLuong.Text);
            if (_soLuongSanPham <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                txtSoLuong.Select();
                return false;
            }
            if (!KiemTraSoNguyenText(txtSoLuong.Text)) return false;

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
                if (cbxTenMatHang.Text == "" && txtDonGia.Text == "" && txtSoLuong.Text == "")
                    throw new NotEnoughInfoException();
                if (double.Parse(txtSoLuong.Text) <= 0)
                {
                    MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                    txtSoLuong.Select();
                    return;
                }

                if (KiemTraTonTaiMatHangDaThem())
                {
                    if (SoSanhSoLuongTrongListOld(maMatHang, txtSoLuong.Text))
                    {
                        return;
                    }
                    else
                    {
                        string updateQuery = "";
                        // Kiểm Tra Mặt Hàng Thêm Vào Là Sản Phẩm 
                        if (listCheckDauDayDai[maMatHang].ToString() != "")
                        {
                            string _strSQLSLDai = "";
                            if (!KiemTraSoLuongTrongKhoTheoMaMH(maDau))
                            {
                                MessageBox.Show("Số Đầu Còn Lại Không Đủ !");
                                return;
                            }
                            if (!KiemTraSoLuongTrongKhoTheoMaMH(maDay))
                            {
                                MessageBox.Show("Số Dây Còn Lại Không Đủ !");
                                return;
                            }
                            if (cbDai.Checked) // Nếu Có Sử Dụng Đai
                            {
                                if (!KiemTraSoLuongTrongKhoTheoMaMH(maDai))
                                {
                                    MessageBox.Show("Số Đai Còn Lại Không Đủ !");
                                    return;
                                }
                                _strSQLSLDai = " OR MaMatH=N'" + maDai + "'";
                            }

                            // Cộng thêm số lượng đã trừ đi trước đó.
                            updateQuery = "UPDATE tblMatHang SET SoLuong=SoLuong+" + double.Parse(listMatHangOld[maMatHang].ToString()) + " " +
                                          "WHERE MaMatH=N'" + maDau + "' OR MaMatH=N'" + maDay + "'" + _strSQLSLDai;
                            DataConn.ThucHienCmd(updateQuery);

                            // Query Cập nhật lại Số Lượng Dây Và Đầu Thêm Vào Mới
                            updateQuery = "UPDATE tblMatHang SET SoLuong=SoLuong-" + txtSoLuong.Text + " " +
                                       "WHERE MaMatH=N'" + maDay + "' OR MaMatH=N'" + maDau + "'" + _strSQLSLDai;
                            DataConn.ThucHienCmd(updateQuery);
                        }

                        // Trừ đi số lượng đã thêm trước đó.
                        updateQuery = "UPDATE tblMatHang SET SoLuong=SoLuong-" + double.Parse(listMatHangOld[maMatHang].ToString()) + " WHERE MaMatH=N'" + maMatHang + "'";
                        DataConn.ThucHienCmd(updateQuery);

                        //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                        updateQuery = "UPDATE tblMatHang set SoLuong=SoLuong+" + txtSoLuong.Text + ",DonGia=@prDonGia WHERE MaMatH=N'" + maMatHang + "'";
                        DataConn.ThucHienInsertSqlParameter(updateQuery, "@prDonGia", float.Parse(txtDonGia.Text));

                        // Cập nhập lại số lượng mới.
                        updateQuery = "UPDATE tblChiTietHDN SET SoLuong=" + txtSoLuong.Text + ",DonGia=@prDonGia WHERE MaHD='" + txtMaHoaDon.Text + "' AND MaMatH=N'" + maMatHang + "'";
                        DataConn.ThucHienInsertSqlParameter(updateQuery, "@prDonGia", float.Parse(txtDonGia.Text));
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
                        string _strMaMatHangSelect = grdNhapHang.Rows[hang].Cells[1].Value.ToString();
                        string select = "SELECT tblHoaDonNhap.MaHD,tblChiTietHDN.MaMatH,TenMatH,tblChiTietHDN.SoLuong,NgayNhap,tblChiTietHDN.DonGia" +
                                        " FROM tblHoaDonNhap INNER JOIN tblChiTietHDN ON tblHoaDonNhap.MaHD=tblChiTietHDN.MaHD" +
                                        " INNER JOIN tblMatHang ON tblChiTietHDN.MaMatH=tblMatHang.MaMatH" +
                                        " WHERE tblHoaDonNhap.MaHD=N'" + grdNhapHang.Rows[hang].Cells[0].Value.ToString() + "'" +
                                        " AND tblChiTietHDN.MaMatH=N'" + _strMaMatHangSelect + "'";
                        DataSet ds = DataConn.GrdSource(select);

                        txtMaH.Text = ds.Tables[0].Rows[0]["MaMatH"].ToString();
                        //cbxMaMatH.Text = ds.Tables[0].Rows[0]["TenMatH"].ToString();
                        cbxTenMatHang.SelectedValue = _strMaMatHangSelect;
                        txtSoLuong.Text = ds.Tables[0].Rows[0]["SoLuong"].ToString();
                        txtDonGia.Text = ds.Tables[0].Rows[0]["DonGia"].ToString();

                        // Không Được Thay Đổi Đầu & Dây Hoặc Đai Đã Chọn
                        cbDauDay.Enabled = false;
                        cbDai.Enabled = false;

                        string _strChuoiMa = listCheckDauDayDai[_strMaMatHangSelect].ToString();
                        if (_strChuoiMa != "")
                        {
                            // Mở và chọn CheckBox nếu Có Thêm Đầu Đai
                            cbDauDay.Checked = true;
                            cbDai.Checked = true;
                            // Không được sửa Đầu Đai đã chọn
                            cbxDauKhoa.Enabled = false;
                            cbxDay.Enabled = false;
                            cbxDai.Enabled = false;
                            // Hiển thị lên Combobox
                            cbxDauKhoa.SelectedValue = _strChuoiMa.Substring(0, 6);
                            cbxDay.SelectedValue = _strChuoiMa.Substring(6, 6);
                            cbxDai.SelectedValue = _strChuoiMa.Substring(12);
                        }
                        else
                        {
                            cbDauDay.Checked = false;
                            cbDai.Checked = false;
                        }
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
                        decimal gia = 0;
                        double soluong = 0;
                        double tong = 0;
                        try
                        {
                            while (sqlData1.Read())
                            {
                                soluong = sqlData1.GetDouble(0);
                                gia = sqlData1.GetDecimal(1);
                                tong += (double)gia * soluong;
                            }
                        }
                        finally
                        {
                            sqlData1.Close();
                            sqlData1.Dispose();
                        }
                        string update = "UPDATE tblHoaDonNhap SET TongTien=@prTongTien WHERE MaHD='" + txtMaHoaDon.Text + "'";
                        DataConn.ThucHienInsertSqlParameter(update, "@prTongTien", float.Parse(tong.ToString()));
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
            cbxTenMatHang.Text = "";
            txtDonGia.Text = "0";
            txtSoLuong.Text = "0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm Tra Mặt Hàng Thêm Vào Có Thêm Đầu + Dây
                if (cbDauDay.Checked)
                {
                    string _strSQLSLDai = "";
                    string updateQuery = "";
                    if (cbDai.Checked) // Nếu Có Sử Dụng Đai
                    {
                        _strSQLSLDai = " OR MaMatH=N'" + maDai + "'";
                    }

                    // Cộng thêm số lượng đã trừ đi trước đó.
                    updateQuery = "UPDATE tblMatHang SET SoLuong=SoLuong+" + double.Parse(listMatHangOld[maMatHang].ToString()) + " " +
                                  "WHERE MaMatH=N'" + maDau + "' OR MaMatH=N'" + maDay + "'" + _strSQLSLDai;
                    DataConn.ThucHienCmd(updateQuery);
                }

                string delete = "DELETE tblChiTietHDN WHERE MaHD='" + txtMaHoaDon.Text + "' AND MaMatH=N'" + maMatHang + "'";
                DataConn.ThucHienCmd(delete);
                //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                string select = "UPDATE tblMatHang set SoLuong=SoLuong-" + txtSoLuong.Text + " WHERE MaMatH=N'" + maMatHang + "'";
                DataConn.ThucHienCmd(select);

                listMatHangOld.Remove(maMatHang);
                listCheckDauDayDai.Remove(maMatHang);
                // Lấy hàng được chọn để xóa
                intSelectIntem = grdNhapHang.CurrentCell.RowIndex;
                // Đưa con trỏ lên 1 hàng sau khi xóa
                intSelectIntem = intSelectIntem > 0 ? intSelectIntem - 1 : 0;

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
            txtMaHoaDon.Text = LayMaHoaDonTheoNgay(pckNgayNhap.Value.Day.ToString("00") + pckNgayNhap.Value.Month.ToString("00") + pckNgayNhap.Value.Year.ToString());
        }

        private void cbDauDay_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDauDay.Checked)
            {
                cbxDay.Enabled = true;
                cbxDauKhoa.Enabled = true;
            }
            else
            {
                cbxDay.Enabled = false;
                cbxDauKhoa.Enabled = false;
            }

        }

        private void cbDai_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDai.Checked)
            {
                cbxDai.Enabled = true;
            }
            else
            {
                cbxDai.Enabled = false;
            }
        }

        private void LoadComboboxMatHang()
        {
            // Load cbx Mã Mặt Hàng
            string selectMatHang = "SELECT * FROM tblMatHang WHERE SUBSTRING(MaMatH,1,3) ='MSP'" +
                                   "AND DonGia > 0  ";
            DataSet dsMatHang = DataConn.GrdSource(selectMatHang);
            cbxMa.DataSource = dsMatHang.Tables[0];
            cbxMa.DisplayMember = "MaMatH";
            cbxMa.ValueMember = "TenMatH";
            if (dsMatHang.Tables[0].Rows.Count > 0)
            {
                maMatHang = dsMatHang.Tables[0].Rows[cbxMa.SelectedIndex][0].ToString();
                cbxMa.Text = cbxMa.SelectedValue.ToString();
            }
            // Load cbx Tên Mặt Hàng
            cbxTenMatHang.DataSource = dsMatHang.Tables[0];
            cbxTenMatHang.DisplayMember = "TenMatH";
            cbxTenMatHang.ValueMember = "MaMatH";
        }

        private void btnMHMoi_Click(object sender, EventArgs e)
        {
            frmMatHang frmMH = new frmMatHang();
            frmMH.MyLoadDataBanHang = new frmMatHang.LoadDataMH(LoadComboboxMatHang);
            frmMH.ShowDialog();
        }
    }

}