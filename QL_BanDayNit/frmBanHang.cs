using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_BanDayNit
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            string select = "select mh.MaMatH Mã_hàng,TenMatH Tên_hàng,SoLuong Số_lượng,DonGia Đơn_giá,gb.GiaBan Giá_bán from tblMatHang mh, tblGiaBan gb where mh.MaMatH = gb.MaMatH and mh.MaMatH=N'" + values + "' and gb.MaKH = N'" + maKH + "'";
            //string select = "select MaMatH Mã_hàng,TenMatH Tên_hàng,SoLuong Số_lượng,DonGia Đơn_giá from tblMatHang";
            //string select = "select * from v_GiaBan where [Tên mặt hàng]=N'" + cboMaMatH.Text + "'";
            try
            {
                if (cboMaMatH.Text == "")
                {
                    throw new NotEnoughInfoException();
                }
                DataSet ds = DataConn.GrdSource(select);
                grdKetQua.DataSource = ds.Tables[0];
                grdKetQua.Refresh();
            }
            catch (FormatException)
            {
                MessageBox.Show("Không đúng định dạng cần thiết! Hãy xem trợ giúp!");
            }
            catch (NotEnoughInfoException)
            {
                MessageBox.Show("Bạn hãy chọn một mặt hàng nào đó!");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string select = "select* from tblMatHang";
            DataSet ds = DataConn.GrdSource(select);
            cboMaMatH.DataSource = ds.Tables[0];
            cboMaMatH.DisplayMember = "TenMatH";
            cboMaMatH.ValueMember = "MaMatH";

            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            cbxKhachHang.DataSource = dsKH.Tables[0];
            cbxKhachHang.DisplayMember = "TenKH";
            cbxKhachHang.ValueMember = "MaKH";

            //Ẩn 1 số Menu khi không phải admin
            mnuMatHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuDangNhap.Enabled = true;
            mnuBCNhapHang.Enabled = false;
            mnuBCXuatHang.Enabled = false;
            mnuDoanhThu.Enabled = false;
            mnuBCTonKho.Enabled = false;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;
            mnuThemNguoiDung.Enabled = false;
            mnuKhoiPhuc.Enabled = false;

            mnuHoaDonNhap.Enabled = true;
            mnuDanhSachHoaDonNhap.Enabled = false;
            mnuHoaDonXuat.Enabled = true;
            mnuDanhSachHDXuat.Enabled = false;
        }

        string values = "";
        private void cboMaMatH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaMatH.ValueMember != null)
            {
                values = cboMaMatH.SelectedValue.ToString();
                btnThongTin_Click(sender, e);
            }
        }

        string maKH = "KH001";
        private void cbxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKhachHang.ValueMember != null)
            {
                maKH = cbxKhachHang.SelectedValue.ToString();
                btnThongTin_Click(sender, e);
            }
        }
        //private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmNhap nhaphang = new frmNhap();
        //    nhaphang.ShowDialog();
        //}

        //private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmXuatHang xuathang = new frmXuatHang();
        //    xuathang.ShowDialog();
        //}

        //private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmDatHang dathang = new frmDatHang();
        //    dathang.ShowDialog();
        //}

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatHang mathang = new frmMatHang();
            mathang.ShowDialog();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmHDN hoadonnhap = new frmHDN();
            //hoadonnhap.ShowDialog();
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmHDX hoadonxuat = new frmHDX();
            //hoadonxuat.ShowDialog();
        }

        private void nhânVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nhanvien = new frmNhanVien();
            nhanvien.ShowDialog();
        }

        private void cáchSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
            path = path.Substring(0, path.LastIndexOf(@"\")) + @"\BanHang-Help.chm";
            Help.ShowHelp(this, path);
        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDoanhThu dt = new frmDoanhThu();
            //dt.ShowDialog();
            frmHoTroThongBaoDoanhThu ht = new frmHoTroThongBaoDoanhThu();
            ht.ShowDialog();
        }

        private void grdKetQua_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.grdKetQua.RowCount > 0)
            {
                if (this.grdKetQua.CurrentCell == null)
                {
                    return;
                }
                if (this.grdKetQua.CurrentCell.RowIndex < this.grdKetQua.RowCount)
                {
                    int hang = this.grdKetQua.CurrentCell.RowIndex;
                    string select = "select TenMatH from tblMatHang where MaMatH=N'" + this.grdKetQua.Rows[hang].Cells[0].Value.ToString() + "'";
                    DataSet ds = DataConn.GrdSource(select);
                    cboMaMatH.Text = ds.Tables[0].Rows[0]["TenMatH"].ToString();
                }
                else
                    return;
            }
        }

        public void DisplayAll()
        {
            mnuMatHang.Enabled = true;
            //hóaĐơnNhậpToolStripMenuItem.Enabled = true;
            //hoáĐơnToolStripMenuItem.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuDangNhap.Enabled = true;
            mnuBCNhapHang.Enabled = true;
            mnuBCXuatHang.Enabled = true;
            mnuDoanhThu.Enabled = true;
            mnuBCTonKho.Enabled = true;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuThemNguoiDung.Enabled = true;
            mnuKhoiPhuc.Enabled = true;

            mnuHoaDonNhap.Enabled = true;
            mnuDanhSachHoaDonNhap.Enabled = true;
            mnuHoaDonXuat.Enabled = true;
            mnuDanhSachHDXuat.Enabled = true;
        }

        public void NotDisplayAll()
        {
            mnuMatHang.Enabled = false;
            //hóaĐơnNhậpToolStripMenuItem.Enabled = false;
            //hoáĐơnToolStripMenuItem.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuDangNhap.Enabled = true;
            mnuBCNhapHang.Enabled = false;
            mnuBCXuatHang.Enabled = false;
            mnuDoanhThu.Enabled = false;
            mnuBCTonKho.Enabled = false;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;
            mnuThemNguoiDung.Enabled = false;
            mnuKhoiPhuc.Enabled = false;

            mnuHoaDonNhap.Enabled = true;
            mnuDanhSachHoaDonNhap.Enabled = false;
            mnuHoaDonXuat.Enabled = true;
            mnuDanhSachHDXuat.Enabled = false;
        }

        private void DangNhaptoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap(this);
            dangnhap.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap(this);
            dangnhap.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap(this);
            dangnhap.btnThoatDN_Click(sender, e);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiPass doipass = new frmDoiPass();
            doipass.ShowDialog();
        }

        private void thêmNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemNguoiDung themuser = new frmThemNguoiDung();
            themuser.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhap nhaphang = new frmNhap();
            nhaphang.ShowDialog();
        }

        private void xuấtHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmXuatHang xuathang = new frmXuatHang();
            xuathang.ShowDialog();
        }


        private void trợGiúpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
            path = path.Substring(0, path.LastIndexOf(@"\")) + @"\BanHang-Help.chm";      
            Help.ShowHelp(this, path);
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmNhap nhaphang = new frmNhap();
            nhaphang.ShowDialog();
        }

        private void hóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatHang xuathang = new frmXuatHang();
            xuathang.ShowDialog();
        }

        private void danhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachHDN ds = new frmDanhSachHDN();
            ds.ShowDialog();
        }

        private void danhSáchHóađơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDanhSachHDX ds = new frmDanhSachHDX();
            ds.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }

        private void KhoiPhucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Khi khôi phục dữ liệu, tất cả các dữ liệu đã bị thay đổi sẽ trở lại như cũ. Bạn có chắc chắn muốn khôi phục dữ liệu không?", "Chú ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataConn.ThucHienCmd_Backup();
                    MessageBox.Show("Đã khôi phục dữ liệu!", "Thông báo");
                }
                frmMain_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {

        }
    }
    public class NotEnoughInfoException : ApplicationException
    {
        public NotEnoughInfoException()
            : base()
        {
        }
    }
    public class SameKeyException : ApplicationException
    {
        public SameKeyException()
            : base()
        {
        }
    }
    public class OutOfQuantityException : ApplicationException
    {
        public OutOfQuantityException()
            : base()
        {
        }
    }
    public class TimeLogicException : ApplicationException
    {
        public TimeLogicException()
            : base()
        {
        }
    }
    public class SameProductKey : ApplicationException
    {
        public SameProductKey()
            : base()
        {
        }
    }
}
