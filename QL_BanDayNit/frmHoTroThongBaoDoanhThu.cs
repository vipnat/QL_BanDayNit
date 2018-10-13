using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmHoTroThongBaoDoanhThu : Form
    {
        public frmHoTroThongBaoDoanhThu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDoanhThu dt = new frmDoanhThu(dtpThangNam.Value.Month.ToString("00"), dtpThangNam.Value.Year.ToString());
            dt.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoTroThongBaoDoanhThu_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
        }
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string. 
            dtpThangNam.Format = DateTimePickerFormat.Custom;
            dtpThangNam.CustomFormat = "MM/yyyy";
            dtpThangNam.ShowUpDown = true;
        }

    }
}