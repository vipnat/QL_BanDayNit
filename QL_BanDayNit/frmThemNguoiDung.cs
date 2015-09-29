using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmThemNguoiDung : Form
    {
        public frmThemNguoiDung()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //Thông báo khi thiếu dữ liệu
                if (txtTenDN.Text == "")
                {
                    MessageBox.Show("Nhập vào tên đăng nhập!", "Thông báo!");
                    txtTenDN.Select();
                    return;
                }
                if (txtMatKhau.Text == "")
                {
                    MessageBox.Show("Nhập vào mật khẩu!", "Thông báo!");
                    txtMatKhau.Select();
                    return;
                }
                if (txtNhacLai.Text == "")
                {
                    MessageBox.Show("Nhắc lại mật khẩu đăng nhập!", "Thông báo!");
                    txtNhacLai.Select();
                    return;
                }
                if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Nhập vào địa chỉ!", "Thông báo!");
                    txtDiaChi.Select();
                    return;
                }
                if (txtDienThoai.Text == "")
                {
                    MessageBox.Show("Nhập vào điện thoại!", "Thông báo!");
                    txtDienThoai.Select();
                    return;
                }
                if (txtMatKhau.Text != txtNhacLai.Text)
                {
                    MessageBox.Show("Mật khẩu và mật khẩu nhắc lại chưa khớp nhau!", "Chú ý!");
                    txtNhacLai.Select();
                    return;
                }
                //Exception khi trùng tên đăng nhập
                string select = "SELECT TaiKhoan FROM tblDangNhap";
                SqlDataReader sqlData = DataConn.ThucHienReader(select);
                try
                {
                    while (sqlData.Read())
                    {
                        if (sqlData.GetString(0) == txtTenDN.Text)
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

                string insert = "INSERT INTO tblDangNhap VALUES(N'"+txtTenDN.Text.Trim()+"',N'"+txtMatKhau.Text.Trim()+"',N'"+txtDiaChi.Text.Trim()+"',N'"+txtDienThoai.Text.Trim()+"')";
                DataConn.ThucHienCmd(insert);
                MessageBox.Show("Đã thêm "+txtTenDN.Text+" vào danh sách người dùng!");
                this.Close();
            }
            catch (SameKeyException)
            {
                MessageBox.Show("Đã có tài khoản đăng nhập với tên này!","Thông báo!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}