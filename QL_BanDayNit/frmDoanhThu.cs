using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        string thangXuatHang = "";
        string namXuatHang = "";
        public frmDoanhThu(string THANG, string NAM)
        {
            InitializeComponent();
            thangXuatHang = THANG;
            namXuatHang = NAM;
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            cbxHienThi.Checked = true;
            HienThiToanBo();
        }

        private void HienThiToanBo()
        {
            // SQL Select data
            string sqlGetLoiNhuan = "SELECT CONCAT(MONTH(NgayXuat),'/',YEAR(NgayXuat)) [Tháng/Năm], SUM(TongTien) [Tổng Tiền],SUM(TongTienGoc) [Tiền Gốc],SUM(TongTien-TongTienGoc) [Lợi Nhuận] FROM tblHoaDonXuat GROUP BY MONTH(NgayXuat),YEAR(NgayXuat)";

            DataSet ds = DataConn.GrdSource(sqlGetLoiNhuan);
            grvLoiNhuan.DataSource = ds.Tables[0];
            grvLoiNhuan.Refresh();
        }

        private void HienThiTheoThangNam(string strThang, string strNam)
        {

            // SQL Select data
            string sqlGetLoiNhuan = "SELECT CONCAT(MONTH(NgayXuat),'/',YEAR(NgayXuat)) [Tháng/Năm], SUM(TongTien) [Tổng Tiền],SUM(TongTienGoc) [Tiền Gốc],SUM(TongTien-TongTienGoc) [Lợi Nhuận] FROM tblHoaDonXuat " +
                                    "WHERE MONTH(NgayXuat) = " + strThang + " AND YEAR(NgayXuat) = " + strNam + " GROUP BY MONTH(NgayXuat),YEAR(NgayXuat)";

            DataSet ds = DataConn.GrdSource(sqlGetLoiNhuan);
            grvLoiNhuan.DataSource = ds.Tables[0];
            grvLoiNhuan.Refresh();

        }

        private void cbxHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHienThi.Checked == true)
                HienThiToanBo();
            else
                HienThiTheoThangNam("0", "0");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            cbxHienThi.Checked = false;
            HienThiTheoThangNam(dtpThangNam.Value.Month.ToString("00"), dtpThangNam.Value.Year.ToString());
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string. 
            dtpThangNam.Format = DateTimePickerFormat.Custom;
            dtpThangNam.CustomFormat = "MM/yyyy";
            dtpThangNam.ShowUpDown = true;

            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.CustomFormat = "yyyy";
            dtpNam.ShowUpDown = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemNam_Click(object sender, EventArgs e)
        {
            cbxHienThi.Checked = false;
            // SQL Select data
            string sqlGetLoiNhuan = "SELECT YEAR(NgayXuat) [Năm], SUM(TongTien) [Tổng Tiền],SUM(TongTienGoc) [Tiền Gốc],SUM(TongTien-TongTienGoc) [Lợi Nhuận] FROM tblHoaDonXuat " +
                                    "WHERE YEAR(NgayXuat) = " + dtpNam.Value.Year.ToString() + " GROUP BY YEAR(NgayXuat)";

            DataSet ds = DataConn.GrdSource(sqlGetLoiNhuan);
            grvLoiNhuan.DataSource = ds.Tables[0];
            grvLoiNhuan.Refresh();
        }
    }
}