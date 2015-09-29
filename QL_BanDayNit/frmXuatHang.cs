using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
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

namespace QL_BanDayNit
{
    public partial class frmXuatHang : Form
    {
        public frmXuatHang()
        {
            InitializeComponent();
        }

        private int intSelectIntem = 0;
        private string maLoaiHang = "MSP";

        private void frmXuatHang_Load(object sender, EventArgs e)
        {
            pckNgayXuat.Text = DateTime.Today.TimeOfDay.ToString();

            txtMaHD.Text = LayMaHoaDonTheoNgay(DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString());

            cboMaNhanVien.Text = "";
            txtGhiChu.Text = "";

            groupChiTietHDX.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = false;
            btnInHD.Enabled = false;

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
            if (cboMaNhanVien.ValueMember != null)
                values2 = dsNhanVien.Tables[0].Rows[cboMaNhanVien.SelectedIndex][0].ToString();
            HienThi();
        }

        private void LoadComboboxMatHang(string maHang)
        {
            // Load cbx Mã Mặt Hàng
            string selectMatHang = "SELECT * FROM tblMatHang WHERE SUBSTRING(MaMatH,1,3) ='" + maHang + "'";
            DataSet dsMatHang = DataConn.GrdSource(selectMatHang);
            cbxMaMatH.DataSource = dsMatHang.Tables[0];
            cbxMaMatH.DisplayMember = "MaMatH";
            cbxMaMatH.ValueMember = "TenMatH";
            if (cbxMaMatH.ValueMember != null)
            {
                values1 = dsMatHang.Tables[0].Rows[cbxMaMatH.SelectedIndex][0].ToString();
                cbxTenMatHang.Text = cbxMaMatH.SelectedValue.ToString();
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

        string values1 = "";
        private void cboMaMatH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaMatH.ValueMember != null)
            {
                values1 = cbxMaMatH.Text;
                cbxTenMatHang.Text = cbxMaMatH.SelectedValue.ToString();
            }

            string strDonGia = LayDonGiaTheoMaKhachHang(cbxMaMatH.Text, cbxKhachHang.SelectedValue.ToString());
            txtDonGia.Text = strDonGia;

        }

        private void cbxTenMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxTenMatHang.ValueMember != null && !cbxKhachHang.Enabled)
            {
                cbxMaMatH.Text = cbxTenMatHang.SelectedValue.ToString();
            }
            string strDonGia = LayDonGiaTheoMaKhachHang(cbxMaMatH.Text, cbxKhachHang.SelectedValue.ToString());
            txtDonGia.Text = strDonGia;
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
                    DonGia = sqlData.GetDouble(0).ToString();
                }
            }
            finally
            {
                sqlData.Close();
                sqlData.Dispose();
            }
            return DonGia;
        }

        string values2 = "";
        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.ValueMember != null)
            {
                values2 = cboMaNhanVien.SelectedValue.ToString();
            }
        }

        private void HienThi()
        {
            // SQL Select data
            string select = " SELECT tblMatHang.TenMatH [Mặt hàng],tblChiTietHDX.SoLuong [Số lượng],tblChiTietHDX.DonGia [Đơn giá],tblChiTietHDX.SoLuong * tblChiTietHDX.DonGia as [Thành Tiền]," +
                            " tblMatHang.MaMatH [Mã MH] FROM tblChiTietHDX INNER JOIN tblHoaDonXuat ON tblHoaDonXuat.MaHD=tblChiTietHDX.MaHD" +
                            " INNER JOIN tblMatHang ON tblMatHang.MaMatH=tblChiTietHDX.MaMatH" +
                            " WHERE tblHoaDonXuat.MaHD='" + txtMaHD.Text + "'";

            DataSet ds = DataConn.GrdSource(select);
            grdXuatHang.DataSource = ds.Tables[0];
            grdXuatHang.Refresh();
            lblSoMatHang.Text = ds.Tables[0].Rows.Count.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdXuatHang.Columns[4].Visible = false;
                grdXuatHang.CurrentCell = grdXuatHang.Rows[intSelectIntem].Cells[0];
                grdXuatHang.FirstDisplayedScrollingRowIndex = intSelectIntem;
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
                // Khóa Combobox Chọn Khách Hàng
                cbxKhachHang.Enabled = false;
                // Khóa Combobox Chọn Nhân Viên
                cboMaNhanVien.Enabled = false;


                string select1 = "select MaHD FROM tblHoaDonXuat";
                SqlDataReader sqlData = DataConn.ThucHienReader(select1);
                try
                {
                    while (sqlData.Read())
                    {
                        if (sqlData.GetString(0) == txtMaHD.Text)
                        {
                            //MessageBox.Show("2");
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
                string select = "insert into tblHoaDonXuat(MaHD,MaNhanVien,NgayXuat,GhiChu) values(N'" + txtMaHD.Text + "',N'" + values2 + "',N'" + pckNgayXuat.Text + "',N'" + txtGhiChu.Text + "')";
                DataConn.ThucHienCmd(select);
                HienThi();
                groupChiTietHDX.Enabled = true;
                btnGhi.Enabled = true;
            }
            catch (SameKeyException)
            {
                MessageBox.Show("Đã có hóa đơn với mã này!", "Chú ý!");
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string selectSQL;
            if (!KiemTraDuLieuNhapSo()) return;
            if (KiemTraMatHangDaCo(values1))
            {
                if (MessageBox.Show("Đã Có Mặt Hàng Này!\nBạn Muốn Sửa Lại Không?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    intSelectIntem = grdXuatHang.CurrentCell.RowIndex;
                    CapNhapMatHangDaBan(sender, e);
                    LoadDuLieuDuocChonTuGridView(intSelectIntem);
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

                    try
                    {
                        string selectMatHang = "SELECT SoLuong FROM tblMatHang WHERE MaMatH='" + values1 + "'";
                        SqlDataReader sqlData1 = DataConn.ThucHienReader(selectMatHang);
                        try
                        {
                            while (sqlData1.Read())
                            {
                                if (sqlData1.GetDouble(0) < double.Parse(txtSoLuong.Text))
                                {
                                    sqlData1.Close();
                                    sqlData1.Dispose();
                                    throw new OutOfQuantityException();
                                }
                            }
                        }
                        finally
                        {
                            sqlData1.Close();
                            sqlData1.Dispose();
                        }
                    }
                    catch (OutOfQuantityException)
                    {
                        MessageBox.Show("Số lượng hàng trong kho không đủ để xuất!");
                        return;
                    }

                    //Thêm vào bảng tblChiTietHDX
                    selectSQL = "insert into tblChiTietHDX(MaMatH,MaHD,SoLuong,DonGia) values(N'" + values1 + "',N'" + txtMaHD.Text + "'," + txtSoLuong.Text + "," + txtDonGia.Text + ")";
                    DataConn.ThucHienCmd(selectSQL);

                    //Cập nhật lại Số Lượng cho bảng tblMatHang (bớt số lượng mặt hàng)
                    selectSQL = "update tblMatHang set SoLuong=SoLuong-" + txtSoLuong.Text + " where MaMatH=N'" + values1 + "'";
                    DataConn.ThucHienCmd(selectSQL);

                    lblTongTien.Text = LayTongTienCuaMaHoaDon(txtMaHD.Text);
                    btnInHD.Enabled = true;
                    btnTinhTien_Click(sender, e);
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
                string selectSL = "SELECT SoLuong FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";

                SqlDataReader sqlDataSL = DataConn.ThucHienReader(selectSL);
                double tongsoluong = 0;
                double so_luong = 0;

                try
                {
                    while (sqlDataSL.Read())
                    {
                        so_luong = sqlDataSL.GetDouble(0);
                        tongsoluong += so_luong;
                    }
                }
                finally
                {
                    sqlDataSL.Close();
                    sqlDataSL.Dispose();
                }

                lblTongSL.Text = tongsoluong.ToString();
            }
        }

        private void CapNhapMatHangDaBan(object sender, EventArgs e)
        {
            string update = "";
            try
            {
                if (cbxMaMatH.Text == "" && txtSoLuong.Text == "" && txtDonGia.Text == "")
                    throw new NotEnoughInfoException();

                string select1 = "select MaMatH from tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
                SqlDataReader sqlData = DataConn.ThucHienReader(select1);
                try
                {
                    while (sqlData.Read())
                    {
                        string aaa = sqlData.GetString(0);
                        if (sqlData.GetString(0) == values1)
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
                try
                {
                    string selectMatHang = "SELECT SoLuong FROM tblMatHang WHERE MaMatH='" + values1 + "'";
                    SqlDataReader sqlData1 = DataConn.ThucHienReader(selectMatHang);
                    while (sqlData1.Read())
                    {
                        if (sqlData1.GetDouble(0) < double.Parse(txtSoLuong.Text))
                        {
                            sqlData1.Close();
                            sqlData1.Dispose();
                            throw new OutOfQuantityException();
                        }
                    }
                    sqlData1.Close();
                    sqlData1.Dispose();
                }
                catch (OutOfQuantityException)
                {
                    MessageBox.Show("Số lượng hàng trong kho không đủ để xuất!");
                    return;
                }

                update = "UPDATE tblChiTietHDX SET MaMatH='" + values1 + "' WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH='" + txtMaH.Text + "'";
                DataConn.ThucHienCmd(update);
                HienThi();
                btnTinhTien_Click(sender, e);
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
                update = "UPDATE tblChiTietHDX SET SoLuong=" + txtSoLuong.Text + ",DonGia=" + txtDonGia.Text + " WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + values1 + "'";
                DataConn.ThucHienCmd(update);
                HienThi();
                //MessageBox.Show("Đã xuất mặt hàng này! ", "Thông báo!");
                btnTinhTien_Click(sender, e);
            }
        }

        private bool KiemTraDuLieuNhapSo()
        {
            if (double.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                txtSoLuong.Select();
                return false;
            }
            if (double.Parse(txtDonGia.Text) <= 0)
            {
                MessageBox.Show("Đơn giá không được nhỏ hơn 0!");
                txtSoLuong.Select();
                return false;
            }
            int int0 = 0;
            if (!int.TryParse(this.txtSoLuong.Text, out int0))
            {
                MessageBox.Show("Số lượng là số nguyên !");
                txtSoLuong.Select();
                return false;
            }
            return true;
        }

        private Boolean KiemTraMatHangDaCo(string values1)
        {
            string select1 = "select MaMatH from tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
            SqlDataReader sqlData = DataConn.ThucHienReader(select1);

            try
            {
                while (sqlData.Read())
                {
                    if (sqlData.GetString(0) == values1)
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
            if (grdXuatHang.RowCount <= 0)
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
                    string sql = "SELECT MaHD FROM tblChiTietHDX";
                    SqlDataReader sqlData = DataConn.ThucHienReader(sql);
                    int c = 0;

                    while (sqlData.Read())
                    {
                        if (sqlData.GetString(0) == txtMaHD.Text)
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

                        lblTongTien.Text = LayTongTienCuaMaHoaDon(txtMaHD.Text);

                        string update = "UPDATE tblHoaDonXuat SET TongTien=" + lblTongTien.Text + " WHERE MaHD='" + txtMaHD.Text + "'";
                        DataConn.ThucHienCmd(update);

                        btnInHD.Enabled = true;
                    }
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Bạn chưa nhập mã hóa đơn hoặc chưa có hóa đơn với mã này!", "Thông báo");
                }
                catch (Exception se)
                {
                    MessageBox.Show("1" + se.Message);
                }
            }
        }

        private string LayTongTienCuaMaHoaDon(string maHD)
        {
            string selectTongTien = "SELECT SUM(SoLuong*DonGia) AS TongTien FROM tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "'";
            DataSet dsTongTien = DataConn.GrdSource(selectTongTien);
            return dsTongTien.Tables[0].Rows[0]["TongTien"].ToString();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            BaseFont arialCustomer = BaseFont.CreateFont(System.IO.Directory.GetCurrentDirectory() + @"/Futura.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            string ngayBan = pckNgayXuat.Value.Day.ToString() + "/" + pckNgayXuat.Value.Month.ToString() + "/" + pckNgayXuat.Value.Year.ToString();

            // Creating iTextSharp Table from title data
            PdfPTable pdfTableTitle = new PdfPTable(2);
            pdfTableTitle.WidthPercentage = 95;
            pdfTableTitle.DefaultCell.Border = 0;
            // Create Cell
            PdfPCell cellTitle = new PdfPCell(new Phrase("HÓA ĐƠN BÁN HÀNG \n", new iTextSharp.text.Font(arialCustomer, 22)));
            cellTitle.Colspan = 3;
            cellTitle.HorizontalAlignment = 1;

            pdfTableTitle.AddCell(cellTitle);
            pdfTableTitle.AddCell(new Paragraph("Người Bán  : " + cboMaNhanVien.Text, new iTextSharp.text.Font(arialCustomer)));
            pdfTableTitle.AddCell(new Paragraph("Ngày :  " + ngayBan + "\n\n", new iTextSharp.text.Font(arialCustomer)));
            pdfTableTitle.AddCell(new Paragraph("Khách Hàng : " + cbxKhachHang.Text, new iTextSharp.text.Font(arialCustomer)));

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(grdXuatHang.ColumnCount);
            float[] widths = new float[] { 5f, 2f, 2f, 2f, 0f };
            pdfTable.SetWidths(widths);
            pdfTable.WidthPercentage = 90;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.DefaultCell.BorderWidth = 1;
            pdfTable.DefaultCell.VerticalAlignment = iTextSharp.text.Rectangle.ALIGN_MIDDLE;

            //Adding Header row
            foreach (DataGridViewColumn column in grdXuatHang.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, new iTextSharp.text.Font(arialCustomer)));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            //Adding DataRow
            foreach (DataGridViewRow row in grdXuatHang.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(cell.Value.ToString(), new iTextSharp.text.Font(arialCustomer))));
                }
            }
            //Exporting to PDF
            //string folderPath = "C:\\LuuHoaDon\\";
            string folderPath = System.IO.Directory.GetCurrentDirectory() + "\\LuuHoaDon\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string namePDF = folderPath + txtMaHD.Text + ".pdf";            
            double dbTongTienBan = double.Parse(lblTongTien.Text) * 1000;
            string intTongTienBan = String.Format("{0:0,0}", dbTongTienBan);

            using (FileStream stream = new FileStream(namePDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A5, 10f, 10f, 10f, 0f);
                pdfDoc.SetPageSize(PageSize.LETTER.Rotate());
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                //pdfDoc.Add(new Paragraph("                                     HÓA ĐƠN BÁN HÀNG \n", new iTextSharp.text.Font(arialCustomer, 22)));
                //pdfDoc.Add(new Paragraph("Người Bán  : " + cboMaNhanVien.Text, new iTextSharp.text.Font(arialCustomer)));
                //pdfDoc.Add(new Paragraph("Khách Hàng : " + cbxKhachHang.Text, new iTextSharp.text.Font(arialCustomer)));
                //pdfDoc.Add(new Paragraph("Ngày :  " + ngayBan + "\n\n", new iTextSharp.text.Font(arialCustomer)));
                pdfDoc.AddAuthor("Anh Tuan");
                pdfDoc.Add(pdfTableTitle);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(new Paragraph("    Số Mặt Hàng: " + lblSoMatHang.Text + "                                      Tổng SL: " + lblTongSL.Text + "       Tổng Tiền: " + intTongTienBan, new iTextSharp.text.Font(arialCustomer, 16)));
                pdfDoc.Add(new Paragraph("\n    Cộng Thành Tiền (Viết bằng chữ) :" + ChuyenSoSangChu(dbTongTienBan.ToString()) + ".", new iTextSharp.text.Font(arialCustomer, 15)));
                pdfDoc.Close();
                stream.Close();
            }

            if (Directory.Exists(namePDF))
            {
                Directory.Delete(namePDF);
            }
            System.Diagnostics.Process.Start(@"" + namePDF);

        }

        private void lblDonGia_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "DELETE tblChiTietHDX WHERE MaHD='" + txtMaHD.Text + "' AND MaMatH=N'" + values1 + "'";
                DataConn.ThucHienCmd(delete);
                HienThi();
                btnTinhTien_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pckNgayXuat_ValueChanged(object sender, EventArgs e)
        {
            // DateTime.Today.Day.ToString() 
            txtMaHD.Text = LayMaHoaDonTheoNgay(pckNgayXuat.Value.Day.ToString() + pckNgayXuat.Value.Month.ToString() + pckNgayXuat.Value.Year.ToString());

        }

        private void grdXuatHang_SelectionChanged(object sender, EventArgs e)
        {
            int intChon = grdXuatHang.CurrentCell.RowIndex;
            string maMatHangSelect = grdXuatHang.Rows[intChon].Cells[4].Value.ToString();
            if (cbxTenMatHang.SelectedValue.ToString().Substring(0, 3) != maMatHangSelect.Substring(0, 3))
                LoadComboboxMatHang(maMatHangSelect.Substring(0, 3));
            LoadDuLieuDuocChonTuGridView(intChon);
        }

        private void LoadDuLieuDuocChonTuGridView(int intHangChon)
        {
            try
            {
                cbxTenMatHang.Text = grdXuatHang.Rows[intHangChon].Cells[0].Value.ToString();
                txtSoLuong.Text = grdXuatHang.Rows[intHangChon].Cells[1].Value.ToString();
                txtDonGia.Text = grdXuatHang.Rows[intHangChon].Cells[2].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        private void rdbSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSanPham.Checked) maLoaiHang = "MSP";
            if (rdbDay.Checked) maLoaiHang = "DAY";
            if (rdbDau.Checked) maLoaiHang = "DAU";
            if (rdbDai.Checked) maLoaiHang = "DAI";
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
            //Viết hoa chữ đầu:
            if (strChuoiKetQua.Length > 0)
            {
                strChuoiKetQua = strChuoiKetQua.Substring(0, 1).ToUpper() + strChuoiKetQua.Substring(1).ToLower();
                strChuoiKetQua.Replace("  ", " ");
            }
            return strChuoiKetQua;
        }

    }
}