﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using iTextSharp.text.xml.simpleparser;
using iTextSharp.text.html.simpleparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using System.Collections;
using System.Threading;
using System.Diagnostics;

namespace QL_BanDayNit
{
    public partial class frmXuatHang : Form
    {
        public frmXuatHang()
        {
            InitializeComponent();
        }

        public delegate void LoadDataMH();
        public LoadDataMH MyLoadDataBanHang;

        private int intSelectIntem = 0;
        private string maLoaiHang = "MSP";
        string _strMaMatHang = "";
        string _strMaKhachHang = "";
        string strMaNhanVien = "";
        string strNoCu = "";
        bool blHoaDonSua = false;
        private Hashtable listMatHangOld = new Hashtable();
        private Hashtable listMatHangTra = new Hashtable();

        private void frmXuatHang_Load(object sender, EventArgs e)
        {
            pckNgayXuat.Text = DateTime.Today.TimeOfDay.ToString();

            cbxTraHang.Checked = false;
            cbxTraHang.Enabled = false;
            grdTraHang.Visible = false;
            lblTra.Visible = false;
            lblTongTra.Visible = false;

            txtMaHD.Text = LayMaHoaDonTheoNgay(DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString());

            cboMaNhanVien.Text = "";
            txtGhiChu.Text = lblNoCu.Text = lblAllTong.Text = "";
            lblTongTien.Text = lblTongSL.Text = "0";

            listMatHangOld.Clear();
            listMatHangTra.Clear();
            groupChiTietHDX.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = false;
            btnInHD.Enabled = false;

            // Khóa Combobox Chọn Khách Hàng
            cbxKhachHang.Enabled = true;
            // Khóa Combobox Chọn Nhân Viên
            cboMaNhanVien.Enabled = true;

            // Load cbx Khách Hàng
            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            cbxKhachHang.DataSource = dsKH.Tables[0];
            cbxKhachHang.DisplayMember = "TenKH";
            cbxKhachHang.ValueMember = "MaKH";

            // Load cbx Mặt Hàng và Mã Mặt Hàng
            LoadComboboxMatHang(maLoaiHang);

            // Load cbx Nhan Vien
            string selectNhanVien = "select* from tblNhanVien";
            DataSet dsNhanVien = DataConn.GrdSource(selectNhanVien);
            cboMaNhanVien.DataSource = dsNhanVien.Tables[0];
            cboMaNhanVien.DisplayMember = "TenNhanVien";
            cboMaNhanVien.ValueMember = "MaNhanVien";
            if (dsNhanVien.Tables[0].Rows.Count > 0)
                strMaNhanVien = dsNhanVien.Tables[0].Rows[cboMaNhanVien.SelectedIndex][0].ToString();

            HienThi();
        }

        private void LoadComboboxMatHang(string maHang)
        {
            // Load cbx Mã Mặt Hàng
            string selectMatHang = "SELECT * FROM tblMatHang WHERE SUBSTRING(MaMatH,1,3) ='" + maHang + "'" +
                                   "AND DonGia > 0  ";
            DataSet dsMatHang = DataConn.GrdSource(selectMatHang);

            // Tạo Table Hiển THị
            DataTable tableHienThi = new DataTable();
            tableHienThi.Columns.Add("MaMatH");
            tableHienThi.Columns.Add("MaRutGon");

            // Chuyển sang list để làm datasource cho combobox  
            foreach (DataRow row in dsMatHang.Tables[0].Rows)
            {
                string strLaySoMaSP = row["MaMatH"].ToString().Substring(3);
                tableHienThi.Rows.Add(row["MaMatH"], strLaySoMaSP);
            }

            cbxMaMatH.DataSource = tableHienThi;
            cbxMaMatH.DisplayMember = "MaRutGon";
            cbxMaMatH.ValueMember = "MaMatH";


            if (dsMatHang.Tables[0].Rows.Count > 0)
            {
                _strMaMatHang = dsMatHang.Tables[0].Rows[cbxMaMatH.SelectedIndex][0].ToString();
                cbxTenMatHang.Text = LayTenMatHangTheoMa(cbxMaMatH.SelectedValue.ToString());
            }
            // Load cbx Tên Mặt Hàng
            cbxTenMatHang.DataSource = dsMatHang.Tables[0];
            cbxTenMatHang.DisplayMember = "TenMatH";
            cbxTenMatHang.ValueMember = "MaMatH";
        }

        private string LayTenMatHangTheoMa(string strMaMH)
        {
            string sqlSqlectTen = "SELECT tblMatHang.TenMatH FROM tblMatHang WHERE MaMatH ='" + strMaMH + "'";
            return DataConn.Lay1GiaTriSelect_ExecuteScalar(sqlSqlectTen);
        }

        private void LoadCombobox()
        {
            // Load cbx Mã Mặt Hàng
            string selectMatHang = "SELECT * FROM tblMatHang WHERE SUBSTRING(MaMatH,1,3) ='" + maLoaiHang + "'" +
                                   "AND DonGia > 0  ";
            DataSet dsMatHang = DataConn.GrdSource(selectMatHang);


            // Tạo Table Hiển THị
            DataTable tableHienThi = new DataTable();
            tableHienThi.Columns.Add("MaMatH");
            tableHienThi.Columns.Add("MaRutGon");

            // Chuyển sang list để làm datasource cho combobox  
            foreach (DataRow row in dsMatHang.Tables[0].Rows)
            {
                string strLaySoMaSP = row["MaMatH"].ToString().Substring(3);
                tableHienThi.Rows.Add(row["MaMatH"], strLaySoMaSP);
            }

            // Load Combobox Mã Mặt Hàng
            cbxMaMatH.DataSource = tableHienThi;
            cbxMaMatH.DisplayMember = "MaRutGon";
            cbxMaMatH.ValueMember = "MaMatH";


            if (dsMatHang.Tables[0].Rows.Count > 0)
            {
                _strMaMatHang = dsMatHang.Tables[0].Rows[cbxMaMatH.SelectedIndex][0].ToString();
                cbxTenMatHang.Text = LayTenMatHangTheoMa(cbxMaMatH.SelectedValue.ToString());
            }
            // Load cbx Tên Mặt Hàng
            cbxTenMatHang.DataSource = dsMatHang.Tables[0];
            cbxTenMatHang.DisplayMember = "TenMatH";
            cbxTenMatHang.ValueMember = "MaMatH";
        }

        private string LayMaHoaDonTheoNgay(string ngayText)
        {
            string MaHD = "";
            int maSo = 1;
            string select1 = "select MaHD FROM tblHoaDonXuat";

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

        private void cboMaMatH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaMatH.ValueMember != null)
            {
                _strMaMatHang = cbxMaMatH.SelectedValue.ToString();
                cbxTenMatHang.Text = LayTenMatHangTheoMa(cbxMaMatH.SelectedValue.ToString());
            }

            try
            {
                string strDonGia = LayDonGiaTheoMaKhachHang(cbxMaMatH.SelectedValue.ToString(), _strMaKhachHang);
                if (strDonGia == "")
                {
                    strDonGia = LayDonGiaTheoMatHang(cbxMaMatH.SelectedValue.ToString());
                }
                txtDonGia.Text = strDonGia;
            }
            catch (Exception)
            {

            }
        }

        private void cbxTenMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxTenMatHang.ValueMember != null && !cbxKhachHang.Enabled)
            {
                cbxMaMatH.Text = cbxTenMatHang.SelectedValue.ToString().Substring(3);
            }
            try
            {
                string strDonGia = LayDonGiaTheoMaKhachHang(cbxMaMatH.SelectedValue.ToString(), _strMaKhachHang);
                if (strDonGia == "")
                {
                    strDonGia = LayDonGiaTheoMatHang(cbxMaMatH.SelectedValue.ToString());
                }
                txtDonGia.Text = strDonGia;
            }
            catch (Exception)
            {
            }

        }

        private string LayDonGiaTheoMaKhachHang(string maMatHang, string maKhachHang)
        {
            string DonGia = "";
            string select = "SELECT tblGiaBan.GiaBan FROM tblGiaBan WHERE tblGiaBan.MaMatH = '" + maMatHang + "' and tblGiaBan.MaKH = '" + maKhachHang + "'";
            SqlDataReader sqlData = DataConn.ThucHienReader(select);
            try
            {
                //MessageBox.Show("1");
                while (sqlData.Read())
                {
                    DonGia = sqlData.GetDecimal(0).ToString();
                }
            }
            finally
            {
                sqlData.Close();
                sqlData.Dispose();
            }
            return DonGia;
        }

        private string LayNoCuTheoMaKhachHang(string maKhachHang)
        {
            string selectNoCu = "SELECT tblKhachHang.NoCu FROM tblKhachHang WHERE tblKhachHang.MaKH = '" + maKhachHang + "'";
            return DataConn.Lay1GiaTriSelect_ExecuteScalar(selectNoCu);
        }

        private string LayDonGiaTheoMatHang(string maMatHang)
        {
            float fDonGia = 0;

            string selectGiaBan = "SELECT [tblMatHang].[DonGia] FROM [tblMatHang] WHERE [tblMatHang].MaMatH = '" + maMatHang + "'";
            string selectGiaTheoKH = "SELECT [tblMatHang].[DonGia] FROM [tblMatHang] INNER JOIN [tblGiaBan] ON [tblMatHang].MaMatH = [tblGiaBan].MaMatH WHERE [MaKH]='" + _strMaKhachHang + "' AND [tblMatHang].MaMatH = '" + maMatHang + "'";

            if (DataConn.Lay1GiaFloat_ExecuteScalar(selectGiaTheoKH) > 0)
                fDonGia = DataConn.Lay1GiaFloat_ExecuteScalar(selectGiaTheoKH);
            else
            {
                fDonGia = DataConn.Lay1GiaFloat_ExecuteScalar(selectGiaBan) + 4;
                string insertGiaBan = "INSERT INTO [tblGiaBan] VALUES(N'" + maMatHang + "',N'" + _strMaKhachHang + "'," + fDonGia + " )";
                if (_strMaKhachHang != "")
                    DataConn.ThucHienCmd(insertGiaBan);
            }

            return fDonGia.ToString();
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.ValueMember != null)
            {
                strMaNhanVien = cboMaNhanVien.SelectedValue.ToString();
            }
        }

        private string LaySoDienThoaiNhanVienTheoMa(string maNhanVien)
        {
            string selectSDT = "SELECT tblNhanVien.DienThoai FROM tblNhanVien WHERE tblNhanVien.MaNhanVien = '" + maNhanVien + "'";
            return DataConn.Lay1GiaTriSelect_ExecuteScalar(selectSDT);
        }

        private void HienThi()
        {
            // SQL Select data
            string selectXuat = " SELECT tblMatHang.MaMatH [Mã MH], tblMatHang.TenMatH [Mặt Hàng],tblChiTietHDX.SoLuong [Số Lượng],tblChiTietHDX.DonGia [Đơn Giá],tblChiTietHDX.SoLuong * tblChiTietHDX.DonGia as [Thành Tiền]" +
                            " FROM tblChiTietHDX INNER JOIN tblHoaDonXuat ON tblHoaDonXuat.MaHD=tblChiTietHDX.MaHD" +
                            " INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDX.MaMatH" +
                            " WHERE tblHoaDonXuat.MaHD='" + txtMaHD.Text + "'";
            string selectTraHang = " SELECT tblMatHang.MaMatH [Mã MH], tblMatHang.TenMatH [Mặt Hàng],tblChiTietHDN.SoLuong [Số Lượng],tblChiTietHDN.DonGia [Đơn Giá],tblChiTietHDN.SoLuong * tblChiTietHDN.DonGia as [Thành Tiền]" +
                            " FROM tblChiTietHDN INNER JOIN tblHoaDonNhap ON tblHoaDonNhap.MaHD=tblChiTietHDN.MaHD" +
                            " INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDN.MaMatH" +
                            " WHERE tblHoaDonNhap.MaHD='" + txtMaHD.Text + "'";

            DataSet ds = DataConn.GrdSource(cbxTraHang.Checked ? selectTraHang : selectXuat);
            grdXuatHang.DataSource = ds.Tables[0];
            grdXuatHang.Refresh();
            lblSoMatHang.Text = ds.Tables[0].Rows.Count.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                // grdXuatHang.Columns[4].Visible = false;
                grdXuatHang.Columns[1].Width = 250;
                grdXuatHang.CurrentCell = grdXuatHang.Rows[intSelectIntem].Cells[0];
                grdXuatHang.FirstDisplayedScrollingRowIndex = intSelectIntem;
            }
        }

        private void HienThiTraHang()
        {
            // SQL Select data
            string selectTraHang = " SELECT tblMatHang.MaMatH [Mã MH], tblMatHang.TenMatH [Mặt Hàng],tblChiTietHDN.SoLuong [Số Lượng],tblChiTietHDN.DonGia [Đơn Giá],tblChiTietHDN.SoLuong * tblChiTietHDN.DonGia as [Thành Tiền]" +
                            " FROM tblChiTietHDN INNER JOIN tblHoaDonNhap ON tblHoaDonNhap.MaHD=tblChiTietHDN.MaHD" +
                            " INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDN.MaMatH" +
                            " WHERE tblHoaDonNhap.MaHD='" + txtMaHD.Text + "'";

            DataSet ds = DataConn.GrdSource(selectTraHang);
            grdTraHang.DataSource = ds.Tables[0];
            grdTraHang.Refresh();
            lblSoMatHang.Text = ds.Tables[0].Rows.Count.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                // grdTraHang.Columns[4].Visible = false;
                grdTraHang.Columns[1].Width = 250;
                grdTraHang.CurrentCell = grdTraHang.Rows[intSelectIntem].Cells[0];
                grdTraHang.FirstDisplayedScrollingRowIndex = intSelectIntem;
            }
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaNhanVien.Text == "")
                {
                    MessageBox.Show("Hãy chọn tên nhân viên xuất hàng!", "Chú ý!");
                    cboMaNhanVien.Select();
                    return;
                }
                if (pckNgayXuat.Text == "")
                {
                    MessageBox.Show("Hãy chọn ngày xuất!", "Chú ý!");
                    pckNgayXuat.Select();
                    return;
                }
                if (cbxKhachHang.Text == "")
                {
                    MessageBox.Show("Hãy Chọn Khách Hàng!", "Chú ý!");
                    cbxKhachHang.Select();
                    return;
                }
                if (!KiemTraNhanVienTonTai(strMaNhanVien)) return;
                _strMaKhachHang = cbxKhachHang.SelectedValue.ToString();

                // Khóa Combobox Chọn Khách Hàng
                cbxKhachHang.Enabled = false;
                // Khóa Combobox Chọn Nhân Viên
                cboMaNhanVien.Enabled = false;

                if (KiemTraHoaDonTonTai(txtMaHD.Text))
                {
                    MessageBox.Show("Đã có hóa đơn với mã này!", "Chú ý!");
                    return;
                }

                string select = "insert into tblHoaDonXuat(MaHD,MaNhanVien,NgayXuat,GhiChu) values(N'" + txtMaHD.Text + "',N'" + strMaNhanVien + "',N'" + pckNgayXuat.Value.ToString("MM/dd/yyyy") + "',N'" + txtGhiChu.Text + "')";
                DataConn.ThucHienCmd(select);

                MessageBox.Show("Tạo Thành Công Hóa Đơn Số " + txtMaHD.Text);

                txtTraTien.Text = "0";
                HienThi();
                groupChiTietHDX.Enabled = true;
                btnGhi.Enabled = true;
                cbxTraHang.Enabled = true;

                strNoCu = LayNoCuTheoMaKhachHang(_strMaKhachHang);
                lblNoCu.Text = "Nợ Cũ : " + strNoCu;
                if (Convert.ToInt32(strNoCu) > 0)
                {
                    lblNoCu.Visible = true;
                    lblAllTong.Visible = true;
                }
                else
                {
                    lblNoCu.Visible = false;
                    lblAllTong.Visible = false;
                }
                txtDonGia.Text = LayDonGiaTheoMatHang(cbxMaMatH.SelectedValue.ToString());
            }
            catch (SameKeyException)
            {

            }
            catch (FormatException)
            {
                MessageBox.Show("Không đúng định dạng dữ liệu!", "Thông báo!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool KiemTraNhanVienTonTai(string strMaNhanVien)
        {
            // Kiểm Tra Nhân Viên
            string selectNhanVien = "SELECT* FROM tblNhanVien WHERE MaNhanVien = '" + strMaNhanVien + "'";
            DataSet dsNhanVien = DataConn.GrdSource(selectNhanVien);
            if (dsNhanVien.Tables[0].Rows.Count > 0) return true;
            return false;
        }

        private bool KiemTraHoaDonTonTai(string strMaHoaDon)
        {
            // Kiểm Tra Nhân Viên
            string selectHDX = "SELECT* FROM tblHoaDonXuat WHERE MaHD = '" + strMaHoaDon + "'";
            string selectHDN = "SELECT* FROM tblHoaDonNhap WHERE MaHD = '" + strMaHoaDon + "'";

            DataSet dsHoaDon = DataConn.GrdSource(cbxTraHang.Checked ? selectHDN : selectHDX);
            if (dsHoaDon.Tables[0].Rows.Count > 0) return true;
            return false;
        }

        private bool KiemTraChiTietHoaDonTonTai(string strMaHoaDon)
        {
            // Kiểm Tra Nhân Viên
            string selectHD = "SELECT* FROM tblChiTietHDX WHERE MaHD = '" + strMaHoaDon + "'";
            DataSet dsHoaDon = DataConn.GrdSource(selectHD);
            if (dsHoaDon.Tables[0].Rows.Count > 0) return true;
            return false;
        }

        private bool KiemTraNhapHoaDonTonTai(string strMaHoaDon)
        {
            // Kiểm Tra Nhân Viên
            string selectHD = "SELECT* FROM tblChiTietHDN WHERE MaHD = '" + strMaHoaDon + "'";
            DataSet dsHoaDon = DataConn.GrdSource(selectHD);
            if (dsHoaDon.Tables[0].Rows.Count > 0) return true;
            return false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Thoát Ra ?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            else
            {
                if (!blHoaDonSua)
                    XoaHetHoaDon();
                this.Close();
            }
        }

        private void XoaHetHoaDon()
        {
            foreach (string strMaMH in listMatHangOld.Keys)
            {
                double soLuong = double.Parse(listMatHangOld[strMaMH].ToString());

                // Xoa Chi Tiet Hoa Don
                string delete = "DELETE tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + strMaMH + "'";
                DataConn.ThucHienCmd(delete);

                //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                string update = "UPDATE tblMatHang set SoLuong=SoLuong+" + soLuong + " WHERE MaMatH=N'" + strMaMH + "'";
                DataConn.ThucHienCmd(update);

            }
            // Xoa Hoa Don
            string deleteHD = "DELETE tblHoaDonXuat WHERE MaHD='" + txtMaHD.Text + "'";
            DataConn.ThucHienCmd(deleteHD);

            //----------------------------------------

            foreach (string strMaMH in listMatHangTra.Keys)
            {
                double soLuong = double.Parse(listMatHangTra[strMaMH].ToString());

                // Xoa Chi Tiet Hoa Don
                string delete = "DELETE tblChiTietHDN WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + strMaMH + "'";
                DataConn.ThucHienCmd(delete);

                //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                string update = "UPDATE tblMatHang set SoLuong=SoLuong-" + soLuong + " WHERE MaMatH=N'" + strMaMH + "'";
                DataConn.ThucHienCmd(update);

            }
            // Xoa Hoa Don
            string deleteHDN = "DELETE tblHoaDonNhap WHERE MaHD='" + txtMaHD.Text + "'";
            DataConn.ThucHienCmd(deleteHDN);

        }

        private void InsertTongTienGoc()
        {
            float tongTienGoc = 0;
            foreach (string strMaMH in listMatHangOld.Keys)
            {
                double soLuong = double.Parse(listMatHangOld[strMaMH].ToString());
                // Lay Tong Tien Goc
                string getTongTienGoc = "SELECT (DonGia*" + soLuong + ")AS TongGoc FROM tblMatHang WHERE MaMatH = N'" + strMaMH + "'";
                tongTienGoc = tongTienGoc + DataConn.Lay1GiaFloat_ExecuteScalar(getTongTienGoc);

            }
            // Xoa Hoa Don
            string updateTongTienGoc = "UPDATE [tblHoaDonXuat] SET TongTienGoc = @TongGoc WHERE MaHD='" + txtMaHD.Text + "'";
            DataConn.ThucHienInsertSqlParameter(updateTongTienGoc, "@TongGoc", tongTienGoc);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!cbxTraHang.Checked)
                GhiBanHang(sender, e);
            else
                GhiTraHang(sender, e);
        }

        private void GhiBanHang(object sender, EventArgs e)
        {
            string query_SQL;
            string strTongTienHoaDon = "";

            if (!KiemTraDuLieuNhapSo()) return;
            if (KiemTraMatHangDaCo(_strMaMatHang))
            {
                if (MessageBox.Show("Đã Có Mặt Hàng Này!\nBạn Muốn Sửa Lại Không?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    intSelectIntem = grdXuatHang.CurrentCell.RowIndex;
                    CapNhapMatHangDaBan(sender, e);

                    //Cập nhập giá mới cho khách hàng
                    query_SQL = "update [tblGiaBan] set [GiaBan]=" + txtDonGia.Text.Replace(",", ".") + " where [MaKH]=N'" + _strMaKhachHang + "' and [MaMatH] =N'" + cbxMaMatH.SelectedValue.ToString() + "'";
                    DataConn.ThucHienCmd(query_SQL);


                    // Update Tổng Tiền
                    strTongTienHoaDon = LayTongTienCuaMaHoaDon(txtMaHD.Text);
                    double tongtienAll = Convert.ToDouble(strTongTienHoaDon) + Convert.ToDouble(strNoCu);
                    if (grdTraHang.Rows.Count > 0)
                    {
                        string strTongTienHoaDonTra = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);
                        tongtienAll = Convert.ToDouble(strNoCu) + Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(strTongTienHoaDonTra);
                    }
                    lblAllTong.Text = "Tổng : " + tongtienAll.ToString();

                    LoadDuLieuDuocChonTuGridView(intSelectIntem, grdXuatHang);
                }
            }
            else
            {
                try
                {
                    //Exception khi không đủ thông tin
                    if (cbxMaMatH.Text == "")
                    {
                        MessageBox.Show("Hãy chọn mặt hàng xuất!", "Chú ý!");
                        cbxMaMatH.Select();
                        return;
                    }
                    if (txtSoLuong.Text == "")
                    {
                        MessageBox.Show("Hãy nhập số lượng!", "Chú ý!");
                        txtSoLuong.Select();
                        return;
                    }
                    if (txtDonGia.Text == "")
                    {
                        MessageBox.Show("Hãy nhập đơn giá!", "Chú ý!");
                        txtDonGia.Select();
                        return;
                    }

                    if (!KiemTraSoLuongTrongKhoTheoMaMH(_strMaMatHang))
                    {
                        MessageBox.Show("Số lượng hàng trong kho không đủ để xuất!");
                        return;
                    }

                    //Thêm vào bảng tblChiTietHDX
                    query_SQL = "insert into tblChiTietHDX(MaMatH,MaHD,SoLuong,DonGia) values(N'" + _strMaMatHang + "',N'" + txtMaHD.Text + "'," + txtSoLuong.Text + ",@DonGia)";
                    DataConn.ThucHienInsertSqlParameter(query_SQL, "@DonGia", float.Parse(txtDonGia.Text.Replace(",", ".")));

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (bớt số lượng mặt hàng)
                    query_SQL = "update tblMatHang set SoLuong=SoLuong-" + txtSoLuong.Text + " where MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienCmd(query_SQL);

                    //Cập nhập giá mới cho khách hàng
                    query_SQL = "update [tblGiaBan] set [GiaBan]=" + txtDonGia.Text.Replace(",", ".") + " where [MaKH]=N'" + _strMaKhachHang + "' and [MaMatH] =N'" + cbxMaMatH.SelectedValue.ToString() + "'";
                    DataConn.ThucHienCmd(query_SQL);

                    // Lấy Tổng Số Lượng
                    //string selectSL = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
                    lblTongSL.Text = LaySoLuongTheoMaLoaiHang();

                    listMatHangOld.Add(_strMaMatHang, (double.Parse(txtSoLuong.Text)));
                    strTongTienHoaDon = LayTongTienCuaMaHoaDon(txtMaHD.Text);
                    lblTongTien.Text = strTongTienHoaDon;
                    btnInHD.Enabled = true;
                    btnTinhTien_Click(sender, e);
                    double tongtienAll = Convert.ToDouble(strTongTienHoaDon) + Convert.ToDouble(strNoCu);
                    if (grdTraHang.Rows.Count > 0)
                    {
                        string strTongTienHoaDonTra = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);
                        tongtienAll = Convert.ToDouble(strNoCu) + Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(strTongTienHoaDonTra);
                    }
                    lblAllTong.Text = "Tổng : " + tongtienAll.ToString();
                    HienThi();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Hãy xem trợ giúp!");
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Hãy nhập đủ các dữ liệu trước khi nhấn nút ghi!");
                }
                catch (SameKeyException)
                {
                    MessageBox.Show("Đã xuất mặt hàng này! ", "Thông báo!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GhiTraHang(object sender, EventArgs e)
        {
            string query_SQL;
            string strTongTienHoaDonTra = "";

            if (!KiemTraDuLieuNhapSo()) return;
            if (KiemTraMatHangDaCo(_strMaMatHang))
            {
                MessageBox.Show("Đã Trả Mặt Hàng Này!\nBạn Cần Xóa Rồi Trả Lại.", "Thông Báo");
                return;
            }
            else
            {
                try
                {
                    //Exception khi không đủ thông tin
                    if (cbxMaMatH.Text == "")
                    {
                        MessageBox.Show("Hãy chọn mặt hàng trả!", "Chú ý!");
                        cbxMaMatH.Select();
                        return;
                    }
                    if (txtSoLuong.Text == "")
                    {
                        MessageBox.Show("Hãy nhập số lượng!", "Chú ý!");
                        txtSoLuong.Select();
                        return;
                    }
                    if (txtDonGia.Text == "")
                    {
                        MessageBox.Show("Hãy nhập đơn giá!", "Chú ý!");
                        txtDonGia.Select();
                        return;
                    }
                    if (KiemTraHangLayVoiHangTra(_strMaMatHang))
                    {
                        MessageBox.Show("Không Thể Trả Mặt Hàng Đang Lấy !", "Thông Báo");
                        return;
                    }
                    //Thêm vào bảng tblChiTietHDX
                    query_SQL = "insert into tblChiTietHDN(MaHD,MaMatH,SoLuong,DonGia) values(N'" + txtMaHD.Text + "',N'" + _strMaMatHang + "'," + txtSoLuong.Text + ",@DonGia)";
                    DataConn.ThucHienInsertSqlParameter(query_SQL, "@DonGia", float.Parse(txtDonGia.Text.Replace(",", ".")));

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (Thêm số lượng mặt hàng)
                    query_SQL = "update tblMatHang set SoLuong=SoLuong+" + txtSoLuong.Text + " where MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienCmd(query_SQL);

                    listMatHangTra.Add(_strMaMatHang, (double.Parse(txtSoLuong.Text)));

                    strTongTienHoaDonTra = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);
                    lblTongTra.Text = strTongTienHoaDonTra;

                    btnTinhTien_Click(sender, e);
                    double tongtienAll = Convert.ToDouble(strNoCu) + Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(strTongTienHoaDonTra);
                    lblAllTong.Text = "Tổng : " + tongtienAll.ToString();
                    HienThiTraHang();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Hãy xem trợ giúp!");
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Hãy nhập đủ các dữ liệu trước khi nhấn nút ghi!");
                }
                catch (SameKeyException)
                {
                    MessageBox.Show("Đã xuất mặt hàng này! ", "Thông báo!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (grdTraHang.RowCount <= 0)
            {
                lblTra.Visible = false;
                lblTongTra.Visible = false;
            }
            else
            {
                lblTra.Visible = true;
                lblTongTra.Visible = true;
            }
        }

        private void btnGhiMoi_Click(object sender, EventArgs e)
        {
            frmMatHang frmMH = new frmMatHang();
            frmMH.MyLoadDataBanHang = new frmMatHang.LoadDataMH(LoadCombobox);
            frmMH.ShowDialog();
        }

        private bool KiemTraSoLuongTrongKhoTheoMaMH(string _strMaMH)
        {
            bool _kiemTra = true;
            int _intSLDaXuat = 0;
            string selectSoLuong = "SELECT SoLuong FROM tblMatHang WHERE MaMatH='" + _strMaMH + "'";
            if (KiemTraTonTaiMatHangDaThem()) // Nếu Là Update
            {
                _intSLDaXuat = int.Parse(listMatHangOld[_strMaMatHang].ToString());
            }
            if (DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectSoLuong) + _intSLDaXuat < double.Parse(txtSoLuong.Text))
            {
                _kiemTra = false;
            }
            return _kiemTra;
        }

        private void CapNhapMatHangDaBan(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaMatH.Text == "" && txtSoLuong.Text == "" && txtDonGia.Text == "")
                    throw new NotEnoughInfoException();

                if (KiemTraTonTaiMatHangDaThem())
                {
                    //if (SoSanhSoLuongTrongListOld(_strMaMatHang, txtSoLuong.Text))

                    if (!KiemTraSoLuongTrongKhoTheoMaMH(_strMaMatHang))
                    {
                        MessageBox.Show("Số lượng hàng trong kho không đủ để xuất!");
                        return;
                    }
                    string updateQuery = "";

                    // Cộng thêm số lượng đã trừ đi trước đó. (thêm)
                    updateQuery = "UPDATE tblMatHang SET SoLuong=SoLuong+" + double.Parse(listMatHangOld[_strMaMatHang].ToString()) + " " +
                                  "WHERE MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienCmd(updateQuery);

                    // Cập Nhập Lại Chi Tiết Hóa Đơn
                    updateQuery = "UPDATE tblChiTietHDX SET SoLuong=" + txtSoLuong.Text + ",DonGia=@DonGia WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienInsertSqlParameter(updateQuery, "@DonGia", float.Parse(txtDonGia.Text.Replace(",", ".")));

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (bớt số lượng mặt hàng)
                    updateQuery = "UPDATE tblMatHang set SoLuong=SoLuong-" + txtSoLuong.Text + " WHERE MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienCmd(updateQuery);

                    // Lấy Tổng Số Lượng
                    //string selectSL = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
                    lblTongSL.Text = LaySoLuongTheoMaLoaiHang();

                    CapNhapLaiSoLuongTrongListOld(_strMaMatHang);
                    HienThi();
                    btnTinhTien_Click(sender, e);

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Không đúng định dạng dữ liệu!", "Thông báo!");
            }
            catch (NotEnoughInfoException)
            {
                MessageBox.Show("Hãy nhập dữ liệu để sửa!", "Thông báo!");
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

        private bool SoSanhSoLuongTrongListOld(string maMH, string sLuong)
        {
            foreach (string key in listMatHangOld.Keys)
                if (key == maMH && listMatHangOld[key].ToString() == sLuong)
                    return true;
            return false;
        }
        private bool KiemTraHangLayVoiHangTra(string maMH)
        {
            foreach (string key in listMatHangOld.Keys)
                if (key == maMH)
                    return true;
            return false;
        }

        private bool KiemTraTonTaiMatHangDaThem()
        {
            string select1 = "select MaMatH from tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
            SqlDataReader sqlData = DataConn.ThucHienReader(select1);
            try
            {
                while (sqlData.Read())
                {
                    if (sqlData.GetString(0) == _strMaMatHang)
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

        private bool KiemTraDuLieuNhapSo()
        {
            int int0 = 0;
            if (!int.TryParse(this.txtSoLuong.Text, out int0))
            {
                MessageBox.Show("Số lượng là số nguyên !");
                txtSoLuong.Select();
                return false;
            }
            if (double.Parse(txtSoLuong.Text) <= 0)
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
            return true;
        }

        private Boolean KiemTraMatHangDaCo(string _strMaMatHang)
        {
            string selectHDX = "select MaMatH from tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
            string selectHDN = "select MaMatH from tblChiTietHDN WHERE MaHD='" + txtMaHD.Text + "'";

            SqlDataReader sqlData = DataConn.ThucHienReader(cbxTraHang.Checked ? selectHDN : selectHDX);

            try
            {
                while (sqlData.Read())
                {
                    if (sqlData.GetString(0) == _strMaMatHang)
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

        private void grdXuatHang_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (grdXuatHang.RowCount > 0)
            //{
            //    btnXoa.Enabled = true;
            //}
            //else btnXoa.Enabled = false;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!cbxTraHang.Checked)
            {

                if (grdXuatHang.RowCount < 0)
                {
                    btnXoa.Enabled = false;
                    btnInHD.Enabled = false;
                }
                else
                {
                    btnXoa.Enabled = true;
                    btnInHD.Enabled = true;
                    try
                    {
                        if (txtMaHD.Text == "")
                            throw new NotEnoughInfoException();


                        if (KiemTraChiTietHoaDonTonTai(txtMaHD.Text)) // Không Tồn Tại Chi Tiết Hóa Đơn
                        {
                            lblTongTien.Text = LayTongTienCuaMaHoaDon(txtMaHD.Text);

                            string update = "UPDATE tblHoaDonXuat SET TongTien=@TongTien WHERE MaHD='" + txtMaHD.Text + "'";
                            DataConn.ThucHienInsertSqlParameter(update, "@TongTien", float.Parse(lblTongTien.Text));

                            btnInHD.Enabled = true;
                        }
                    }
                    catch (Exception se)
                    {
                        MessageBox.Show("1" + se.Message);
                    }
                }
            }
            else
            {
                if (grdTraHang.RowCount < 0)
                {
                    btnXoa.Enabled = false;
                    btnInHD.Enabled = false;
                }
                else
                {
                    btnXoa.Enabled = true;
                    btnInHD.Enabled = true;
                    try
                    {
                        if (txtMaHD.Text == "")
                            throw new NotEnoughInfoException();


                        if (KiemTraNhapHoaDonTonTai(txtMaHD.Text)) // Không Tồn Tại Chi Tiết Hóa Đơn
                        {
                            lblTongTra.Text = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);

                            string update = "UPDATE tblHoaDonNhap SET TongTien=@TongTien WHERE MaHD='" + txtMaHD.Text + "'";
                            DataConn.ThucHienInsertSqlParameter(update, "@TongTien", float.Parse(lblTongTra.Text));
                        }
                    }
                    catch (Exception se)
                    {
                        MessageBox.Show("1" + se.Message);
                    }
                }
            }
        }

        private string LayTongTienCuaMaHoaDon(string maHD)
        {
            string selectTongTien = "SELECT SUM(SoLuong*DonGia) AS TongTien FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
            DataSet dsTongTien = DataConn.GrdSource(selectTongTien);
            string getTongTien = dsTongTien.Tables[0].Rows[0]["TongTien"].ToString();
            if (getTongTien == "") return "0";
            return getTongTien;
        }

        private string LayTongTienCuaMaHoaDonTra(string maHD)
        {
            string selectTongTien = "SELECT SUM(SoLuong*DonGia) AS TongTien FROM tblChiTietHDN WHERE MaHD='" + txtMaHD.Text + "'";
            DataSet dsTongTien = DataConn.GrdSource(selectTongTien);
            string getTongTien = dsTongTien.Tables[0].Rows[0]["TongTien"].ToString();
            if (getTongTien == "") return "0";
            return getTongTien;
        }

        private string LaySoLuongTheoMaLoaiHang()
        {
            string strSoLuong = "";
            int intSanPham = 0;
            int intBop = 0;
            int intDay = 0;
            int intDau = 0;

            string selectSLSP = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND SUBSTRING(MaMatH,1,3) ='MSP' AND SUBSTRING(MaMatH,4,2) BETWEEN 20 AND 45";
            intSanPham = DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectSLSP);
            if (intSanPham > 0) strSoLuong = strSoLuong + intSanPham + " Dây\n";

            string selectSLBop = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND SUBSTRING(MaMatH,1,5) ='MSP50'";
            intBop = DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectSLBop);
            if (intBop > 0) strSoLuong = strSoLuong + intBop + " Bóp\n";

            string selectDay = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND SUBSTRING(MaMatH,1,3) ='DAY'";
            intDay = DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectDay);
            if (intDay > 0) strSoLuong = strSoLuong + intDay + " Dây Ko\n";

            string selectDau = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND SUBSTRING(MaMatH,1,3) ='DAU'";
            intDau = DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectDau);
            if (intDau > 0) strSoLuong = strSoLuong + intDau + " Đầu Ko\n";

            return strSoLuong;
        }

        // http://www.mikesdotnetting.com/article/86/itextsharp-introducing-tables
        // http://tutorials.jenkov.com/java-itext/table.html
        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc Đã Hoàn Thành Hóa Đơn Này ?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                //MessageBox.Show("Chỉnh Sửa Lại Hóa Đơn Trước Khi In !");
                return;
            }
            else
            {
                if (txtTraTien.Text == "")
                    txtTraTien.Text = "0";

                // Thêm Tổng Tiền Gốc
                InsertTongTienGoc();

                // Xuất Hóa Đơn PDF
                XuatHoaDonPDF();

                // Thoát Sau Khi In Hóa Đơn
                if (MessageBox.Show("Đã Xuất Thành Công Bạn Có Muốn Chỉnh Sửa ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    blHoaDonSua = true;
                    return;
                }
                else
                {
                    // Update Nợ Cũ
                    string strTongTienHoaDonTra = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);
                    double dbTongPhaiTra = Convert.ToDouble(strNoCu) + Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(strTongTienHoaDonTra);
                    double dbTraTien = Convert.ToDouble(txtTraTien.Text);
                    double dbNoCu = Convert.ToDouble(strNoCu);
                    if (dbTongPhaiTra - dbTraTien > 0)
                    {
                        dbNoCu = dbNoCu + Convert.ToDouble(LayTongTienCuaMaHoaDon(txtMaHD.Text)) - dbTraTien;
                        string updateNoCu = "UPDATE tblKhachHang SET NoCu = " + dbNoCu + " WHERE MaKH = N'" + _strMaKhachHang + "'";
                        DataConn.ThucHienCmd(updateNoCu);
                    }
                    this.Close();
                }
            }
        }

        private void XuatHoaDonPDF()
        {
            // Update Nợ Cũ
            double dbNoCu = Convert.ToDouble(strNoCu);
            double dbTraTien = Convert.ToDouble(txtTraTien.Text);
            double dbTongTienBan = double.Parse(lblTongTien.Text) * 1;
            string intTongTienBan = String.Format("{0:0,0}", dbTongTienBan);

            //BaseFont arialCustomer = BaseFont.CreateFont(System.IO.Directory.GetCurrentDirectory() + @"/Futura.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            string _timesBin = System.IO.Directory.GetCurrentDirectory() + @"/times.ttf";
            string __timesWinFonts = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";

            try
            {
                if (!File.Exists(__timesWinFonts))
                {
                    File.Copy(_timesBin, __timesWinFonts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thiếu Font Chữ Tiếng Việt ! times.ttf \nTải về và Copy vào thư mục \n" + __timesWinFonts + "" + ex);
            }

            BaseFont arialCustomer = BaseFont.CreateFont(__timesWinFonts, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            string ngayBan = pckNgayXuat.Value.Day.ToString("00") + "/" + pckNgayXuat.Value.Month.ToString("00") + "/" + pckNgayXuat.Value.Year.ToString();

            byte[] utf16String = Encoding.Unicode.GetBytes("");


            // Creating iTextSharp Table from title data
            PdfPTable pdfTableTitle = new PdfPTable(2);
            pdfTableTitle.WidthPercentage = 95;
            pdfTableTitle.DefaultCell.BorderWidth = 0;

            // Create Cell Title
            PdfPCell cellTitle;
            cellTitle = new PdfPCell(new Phrase("HÓA ĐƠN BÁN HÀNG \n", new iTextSharp.text.Font(arialCustomer, 22)));
            cellTitle.Colspan = 3;
            cellTitle.HorizontalAlignment = 1;
            cellTitle.Border = 0;
            pdfTableTitle.AddCell(cellTitle);

            cellTitle = new PdfPCell(new Paragraph("Người Bán  : " + cboMaNhanVien.Text + " (" + LaySoDienThoaiNhanVienTheoMa(strMaNhanVien) + ")" + "\n\nKhách Hàng : " + cbxKhachHang.Text + "\n\n", new iTextSharp.text.Font(arialCustomer)));
            cellTitle.Border = 0;
            pdfTableTitle.AddCell(cellTitle);
            //
            cellTitle = new PdfPCell(new Paragraph("Ngày :  " + ngayBan + "\n\n" + "" + "\n\n", new iTextSharp.text.Font(arialCustomer)));
            cellTitle.Border = 0;
            cellTitle.HorizontalAlignment = 2;
            pdfTableTitle.AddCell(cellTitle);
            //
            pdfTableTitle.AddCell(new Paragraph("", new iTextSharp.text.Font(arialCustomer)));

            //
            //Creating iTextSharp Table from the DataTable data  Table Bán Hàng
            //
            PdfPTable pdfTable = new PdfPTable(grdXuatHang.ColumnCount);
            float[] widths = new float[] { 1.5f, 5f, 1.5f, 2f, 2f };
            pdfTable.SetWidths(widths);
            pdfTable.WidthPercentage = 95;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.DefaultCell.BorderWidth = 1;
            pdfTable.DefaultCell.VerticalAlignment = iTextSharp.text.Rectangle.ALIGN_MIDDLE;

            //Adding Header row
            foreach (DataGridViewColumn column in grdXuatHang.Columns)
            {
                PdfPCell cellHeader = new PdfPCell(new Phrase(column.HeaderText, new iTextSharp.text.Font(arialCustomer)));
                cellHeader.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                cellHeader.HorizontalAlignment = 1;
                cellHeader.FixedHeight = 20f;
                pdfTable.AddCell(cellHeader);
            }
            int maSP = 0;
            //Adding DataRow
            foreach (DataGridViewRow row in grdXuatHang.Rows)
            {
                maSP = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    PdfPCell _cellPDF = new PdfPCell(new Phrase(maSP == 1 ? cell.Value.ToString().Substring(3) : cell.Value.ToString(), new iTextSharp.text.Font(arialCustomer)));
                    _cellPDF.FixedHeight = 20f;
                    _cellPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(_cellPDF);
                    maSP = 0;
                }
            }
            // Adding Row Tổng Tiền
            pdfTable.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
            pdfTable.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
            pdfTable.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
            pdfTable.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
            pdfTable.AddCell(new Phrase("Tổng: " + intTongTienBan, new iTextSharp.text.Font(arialCustomer, 16)));

            //
            // Add Table Trả Hàng vào PDF
            //
            PdfPTable pdfTableTra = null;
            if (grdTraHang.Rows.Count > 0)
            {
                double dbTienTraHang = Convert.ToDouble(lblTongTra.Text);
                //
                //Creating iTextSharp Table from the DataTable data  Table Trả Hàng
                //
                pdfTableTra = new PdfPTable(grdTraHang.ColumnCount);
                float[] widthsTra = new float[] { 2f, 5f, 2f, 2f, 2f };
                pdfTableTra.SetWidths(widthsTra);
                pdfTableTra.WidthPercentage = 95;
                pdfTableTra.DefaultCell.Padding = 3;
                pdfTableTra.DefaultCell.BorderWidth = 1;
                pdfTableTra.DefaultCell.VerticalAlignment = iTextSharp.text.Rectangle.ALIGN_MIDDLE;

                //Adding title Trả Hàng
                PdfPCell titleTraHang = new PdfPCell(new Phrase("Trả Hàng", new iTextSharp.text.Font(arialCustomer, 16))) { Colspan = 5 };
                titleTraHang.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTableTra.AddCell(titleTraHang);

                int maSP_Tra = 0;
                //Adding DataRow
                foreach (DataGridViewRow row in grdTraHang.Rows)
                {
                    maSP_Tra = 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        PdfPCell _cellPDF = new PdfPCell(new Phrase(maSP_Tra == 1 ? cell.Value.ToString().Substring(3) : cell.Value.ToString(), new iTextSharp.text.Font(arialCustomer)));
                        _cellPDF.FixedHeight = 20f;
                        _cellPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTableTra.AddCell(_cellPDF);
                        maSP_Tra = 0;
                    }
                }
                // Adding Row Tổng Tiền
                pdfTableTra.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
                pdfTableTra.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
                pdfTableTra.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
                pdfTableTra.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
                pdfTableTra.AddCell(new Phrase("Trừ -" + lblTongTra.Text, new iTextSharp.text.Font(arialCustomer, 16)));

                dbTongTienBan = dbTongTienBan - dbTienTraHang;
                intTongTienBan = String.Format("{0:0,0}", dbTongTienBan);

            }

            //
            // Table Tính Tiền
            //
            PdfPTable pdfTableTongTien = new PdfPTable(5);
            float[] widthsTT = new float[] { 1.5f, 5f, 1.5f, 2f, 2f };
            pdfTableTongTien.SetWidths(widthsTT);
            pdfTableTongTien.WidthPercentage = 95;
            pdfTableTongTien.DefaultCell.BorderWidth = 0;

            // Add Cell Tính Tiền
            pdfTableTongTien.AddCell(new Phrase("\nSố Loại: " + lblSoMatHang.Text, new iTextSharp.text.Font(arialCustomer, 14)));
            pdfTableTongTien.AddCell(new Phrase("", new iTextSharp.text.Font(arialCustomer, 16)));
            pdfTableTongTien.AddCell(new Phrase("\n" + lblTongSL.Text, new iTextSharp.text.Font(arialCustomer, 16)));

            if (dbNoCu > 0)
            {
                PdfPCell _cellPDFTT = new PdfPCell(new Phrase("\nTổng Toa : \nNợ Cũ      : \nTổng Tiền: \nTrả Tiền   : \n------------- \nCòn          :", new iTextSharp.text.Font(arialCustomer, 16)));
                _cellPDFTT.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cellPDFTT.Border = 0;
                pdfTableTongTien.AddCell(_cellPDFTT);
                pdfTableTongTien.AddCell(new Phrase("\n" + intTongTienBan + "\n" + dbNoCu + "\n" + (dbTongTienBan + dbNoCu) + "\n" + dbTraTien + "\n\n" + (dbTongTienBan + dbNoCu - dbTraTien), new iTextSharp.text.Font(arialCustomer, 16)));
            }
            else
            {
                PdfPCell _cellPDFTT = new PdfPCell(new Phrase("\nTổng Toa : \nTrả           : \n------------- \nCòn          :", new iTextSharp.text.Font(arialCustomer, 16)));
                _cellPDFTT.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cellPDFTT.Border = 0;
                pdfTableTongTien.AddCell(_cellPDFTT);
                pdfTableTongTien.AddCell(new Phrase("\n" + intTongTienBan + "\n" + dbTraTien + "\n\n" + (dbTongTienBan - dbTraTien), new iTextSharp.text.Font(arialCustomer, 16)));
            }

            //dbTongTienBan = dbTongTienBan * 1000;
            //// Create Cell Footter
            //PdfPCell cellTongTien;
            //cellTongTien = new PdfPCell(new Phrase("Cộng Thành Tiền (Viết bằng chữ) : " + ChuyenSoSangChu(dbTongTienBan.ToString()), new iTextSharp.text.Font(arialCustomer, 15)));
            //cellTongTien.Colspan = 3;
            //cellTongTien.HorizontalAlignment = 0;
            //cellTongTien.Border = 0;
            //pdfTableTongTien.AddCell(cellTongTien);

            //Exporting to PDF

            string folderPath = DataConn.folderLuuHoaDon;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string namePDF = folderPath + txtMaHD.Text + ".pdf";


            if (System.IO.File.Exists(namePDF))
            {
                try
                {
                    System.IO.File.Delete(namePDF);
                }
                catch
                {
                    MessageBox.Show("Tập Tin PDF Đã Có Và Đang Được Sử Dụng ! \nTắt Tập Tin Để Tạo Lại.");

                    return;
                }
            }

            using (FileStream stream = new FileStream(namePDF, FileMode.Create))
            {
                Document pdfDoc = new Document();

                pdfDoc = new Document(PageSize.A5, 10f, 10f, 15f, 30f);
                pdfDoc.SetPageSize(PageSize.LETTER);  // A5 Dọc
                //pdfDoc.SetPageSize(PageSize.LETTER.Rotate()); A5 Ngang
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.AddAuthor("Anh Tuan");
                pdfDoc.Add(pdfTableTitle);
                pdfDoc.Add(pdfTable);
                if (grdTraHang.Rows.Count > 0)
                    pdfDoc.Add(pdfTableTra);
                pdfDoc.Add(pdfTableTongTien);

                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process.Start(@"" + namePDF);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!cbxTraHang.Checked)
            {
                try
                {
                    string delete = "DELETE tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienCmd(delete);

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (thêm số lượng mặt hàng)
                    string update = "UPDATE tblMatHang set SoLuong=SoLuong+" + txtSoLuong.Text + " WHERE MaMatH=N'" + _strMaMatHang + "'";
                    DataConn.ThucHienCmd(update);

                    listMatHangOld.Remove(_strMaMatHang);
                    // Lấy hàng được chọn để xóa
                    intSelectIntem = grdXuatHang.CurrentCell.RowIndex;
                    // Đưa con trỏ lên 1 hàng sau khi xóa
                    intSelectIntem = intSelectIntem > 0 ? intSelectIntem - 1 : 0;

                    // Lấy Tổng Số Lượng
                    //string selectSL = "SELECT SUM(SoLuong) FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
                    lblTongSL.Text = LaySoLuongTheoMaLoaiHang();

                    string strTongTienHoaDon = LayTongTienCuaMaHoaDon(txtMaHD.Text);
                    lblTongTien.Text = strTongTienHoaDon;
                    double tongtienAll = Convert.ToDouble(strTongTienHoaDon) + Convert.ToDouble(strNoCu);
                    if (grdTraHang.Rows.Count > 0)
                    {
                        string strTongTienHoaDonTra = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);
                        tongtienAll = Convert.ToDouble(strNoCu) + Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(strTongTienHoaDonTra);
                    }
                    lblAllTong.Text = "Tổng : " + tongtienAll.ToString();
                    HienThi();
                    btnTinhTien_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (grdXuatHang.RowCount <= 0)
                {
                    btnXoa.Enabled = false;
                    btnInHD.Enabled = false;
                }
            }
            else
            {
                string delete = "DELETE tblChiTietHDN WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + _strMaMatHang + "'";
                DataConn.ThucHienCmd(delete);

                //Cập nhật lại Số Lượng cho bảng tblMatHang (Trừ số lượng mặt hàng)
                string update = "UPDATE tblMatHang set SoLuong=SoLuong-" + txtSoLuong.Text + " WHERE MaMatH=N'" + _strMaMatHang + "'";
                DataConn.ThucHienCmd(update);


                listMatHangTra.Remove(_strMaMatHang);
                // Lấy hàng được chọn để xóa
                intSelectIntem = grdTraHang.CurrentCell.RowIndex;
                // Đưa con trỏ lên 1 hàng sau khi xóa
                intSelectIntem = intSelectIntem > 0 ? intSelectIntem - 1 : 0;


                string strTongTienHoaDonTra = LayTongTienCuaMaHoaDonTra(txtMaHD.Text);
                lblTongTra.Text = strTongTienHoaDonTra;
                double tongtienTra = Convert.ToDouble(strNoCu) + Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(strTongTienHoaDonTra);
                lblAllTong.Text = "Tổng : " + tongtienTra.ToString();
                HienThiTraHang();
                btnTinhTien_Click(sender, e);
                if (grdTraHang.RowCount <= 0)
                {
                    btnXoa.Enabled = false;
                    btnInHD.Enabled = false;
                }
            }
            if (grdTraHang.RowCount <= 0)
            {
                lblTra.Visible = false;
                lblTongTra.Visible = false;
            }
            else
            {
                lblTra.Visible = true;
                lblTongTra.Visible = true;
            }

        }

        private void pckNgayXuat_ValueChanged(object sender, EventArgs e)
        {
            // DateTime.Today.Day.ToString() 
            txtMaHD.Text = LayMaHoaDonTheoNgay(pckNgayXuat.Value.Day.ToString() + pckNgayXuat.Value.Month.ToString() + pckNgayXuat.Value.Year.ToString());

        }

        private void grdXuatHang_SelectionChanged(object sender, EventArgs e)
        {
            int intChon;
            try
            {
                intChon = grdXuatHang.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            string maMatHangSelect = grdXuatHang.Rows[intChon].Cells[0].Value.ToString();
            if (cbxTenMatHang.SelectedValue.ToString().Substring(0, 3) != maMatHangSelect.Substring(0, 3))
                LoadComboboxMatHang(maMatHangSelect.Substring(0, 3));
            LoadDuLieuDuocChonTuGridView(intChon, grdXuatHang);
        }

        private void grdTraHang_SelectionChanged(object sender, EventArgs e)
        {
            int intChon;
            try
            {
                intChon = grdTraHang.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            string maMatHangSelect = grdTraHang.Rows[intChon].Cells[0].Value.ToString();
            if (cbxTenMatHang.SelectedValue.ToString().Substring(0, 3) != maMatHangSelect.Substring(0, 3))
                LoadComboboxMatHang(maMatHangSelect.Substring(0, 3));
            LoadDuLieuDuocChonTuGridView(intChon, grdTraHang);
        }

        private void LoadDuLieuDuocChonTuGridView(int intHangChon, DataGridView grView)
        {
            try
            {
                cbxTenMatHang.Text = grView.Rows[intHangChon].Cells[1].Value.ToString();
                txtSoLuong.Text = grView.Rows[intHangChon].Cells[2].Value.ToString();
                txtDonGia.Text = grView.Rows[intHangChon].Cells[3].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        private void rdbSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSanPham.Checked)
            {
                maLoaiHang = lblMaMatH.Text = "MSP";
            }
            if (rdbDay.Checked)
            {
                maLoaiHang = lblMaMatH.Text = "DAY";
            }
            if (rdbDau.Checked)
            {
                maLoaiHang = lblMaMatH.Text = "DAU";
            }
            if (rdbDai.Checked)
            {
                maLoaiHang = lblMaMatH.Text = "DAI";
            }
            LoadComboboxMatHang(maLoaiHang);
        }

        // By Puss on http:// diendan.congdongcviet.com/threads/t58649::code-chuyen-tien-so-sang-chu-tren-csharp.cpphttp://diendan.congdongcviet.com/threads/t58649::code-chuyen-tien-so-sang-chu-tren-csharp.cpp
        private string ChuyenSoSangChu(string number)
        {
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string strChuoiKetQua;
            int i, j, k, n, len, found, ddv, rd;
            len = number.Length;
            number += "ss";
            strChuoiKetQua = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }
                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) strChuoiKetQua += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') strChuoiKetQua += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) strChuoiKetQua += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    strChuoiKetQua += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        strChuoiKetQua += "mốt ";
                                    else
                                        strChuoiKetQua += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    strChuoiKetQua += "lăm ";
                                else
                                    strChuoiKetQua += cs[5] + " ";
                                break;
                            default:
                                strChuoiKetQua += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }
                        //strChuoiKetQua don vi nho
                        if (ddv == 1)
                        {
                            strChuoiKetQua += dv[n - j - 1] + " ";
                        }
                    }
                }
                //strChuoiKetQua don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                strChuoiKetQua += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) strChuoiKetQua += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }
            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];
            /* Admin add 
                //Viết hoa chữ đầu:
            */
            if (strChuoiKetQua.Length > 0)
            {
                strChuoiKetQua = strChuoiKetQua.Substring(0, 1).ToUpper() + strChuoiKetQua.Substring(1).ToLower();
                // Xóa khoảng trắng thừa.
                strChuoiKetQua = strChuoiKetQua.Replace("  ", " ");
                // Đổi Năm thành Lăm
                strChuoiKetQua = strChuoiKetQua.Replace("i năm", "i lăm");
                // Thêm đơn vị tiền tệ.
                strChuoiKetQua = strChuoiKetQua + "đồng.";
            }
            return strChuoiKetQua;
        }

        private void cbxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            string decimalString = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char decimalChar = Convert.ToChar(decimalString);

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            { }
            else if (e.KeyChar == decimalChar && txtDonGia.Text.IndexOf(decimalString) == -1)
            { }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTraNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }


        // Sử Lý Trả Hàng = Nhập Hàng Mới
        private void cbxTraHang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTraHang.Checked)
            {
                if (!KiemTraHoaDonTonTai(txtMaHD.Text))
                {
                    // Thêm Hóa Đơn Nhập Khi Trả Lại
                    string sqlInsert = "insert into tblHoaDonNhap(MaHD,NgayNhap,GhiChu) values(N'" + txtMaHD.Text + "',N'" + pckNgayXuat.Value.ToString("MM/dd/yyyy") + "',N'" + txtGhiChu.Text + "')";
                    DataConn.ThucHienCmd(sqlInsert);
                }

                if (grdTraHang.RowCount <= 0)
                {
                    btnXoa.Enabled = false;
                    btnInHD.Enabled = false;
                }
                else
                {
                    btnXoa.Enabled = true;
                    btnInHD.Enabled = true;
                }

                grdTraHang.Visible = true;
                HienThiTraHang();
            }
            else
            {
                if (grdXuatHang.RowCount <= 0)
                {
                    btnXoa.Enabled = false;
                    btnInHD.Enabled = false;
                }
                else
                {
                    btnXoa.Enabled = true;
                    btnInHD.Enabled = true;
                }

                grdTraHang.Visible = false;
                HienThi();
            }
            if (grdTraHang.RowCount <= 0)
            {
                lblTra.Visible = false;
                lblTongTra.Visible = false;
            }
            else
            {
                lblTra.Visible = true;
                lblTongTra.Visible = true;
            }
        }

        private void lblTongTra_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(lblTongTra.Text) > 0)
                lblConLai.Text = "Còn: " + (Convert.ToDouble(lblTongTien.Text) - Convert.ToDouble(lblTongTra.Text));
            else
                lblConLai.Text = "";
        }

    }
}