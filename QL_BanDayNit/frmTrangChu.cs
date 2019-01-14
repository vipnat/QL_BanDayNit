using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoTroThongBaoDoanhThu_Load(object sender, EventArgs e)
        {
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKH = new frmKhachHang();
            frmKH.ShowDialog();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNV = new frmNhanVien();
            frmNV.ShowDialog();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmMatHang frmSPham = new frmMatHang();
            frmSPham.ShowDialog();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmXuatHang frmXuat = new frmXuatHang();
            frmXuat.ShowDialog();
        }

        private void btnDSHD_Click(object sender, EventArgs e)
        {
            frmDanhSachHDX frmHDX = new frmDanhSachHDX();
            frmHDX.ShowDialog();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmDoanhThu frmDT = new frmDoanhThu();
            frmDT.ShowDialog();
        }

        private void bntNhapHang_Click(object sender, EventArgs e)
        {
            frmNhap frmDT = new frmNhap();
            frmDT.ShowDialog();
        }

        private void btnDoiTen_Click(object sender, EventArgs e)
        {
            frmDoiTenFile doiten = new frmDoiTenFile();
            doiten.ShowDialog();
        }
    }
}