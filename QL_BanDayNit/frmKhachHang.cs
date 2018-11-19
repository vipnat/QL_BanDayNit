using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private int LayMaKH()
        {
            int mKH = 1;
            string select1 = "select MaKH from tblKhachHang";
            SqlDataReader sqlData = DataConn.ThucHienReader(select1);
            try
            {
                while (sqlData.Read())
                {
                    string aa = sqlData.GetString(0);
                    int getMaKH = Convert.ToInt32(sqlData.GetString(0).Remove(0, 2));
                    if (getMaKH == mKH)
                    {
                        mKH = getMaKH + 1;
                    }
                }
                sqlData.Close();
                sqlData.Dispose();
            }
            finally
            {
                sqlData.Close();
                sqlData.Dispose();
            }

            return mKH;
        }

        private void HienThi()
        {
            string select = "SELECT [MaKH] [Mã Khách Hàng],[TenKH] [Tên Khách Hàng],[DiaChi] [Địa Chỉ],[SoDT] [Điện thoại] FROM tblKhachHang";
            DataSet ds = DataConn.GrdSource(select);
            grdKhachHang.DataSource = ds.Tables[0];
            grdKhachHang.Refresh();
            if (grdKhachHang.RowCount <= 0)
                txtMaKH.Text = LayMaKH().ToString("000");
        }

        private void grdKhachHang_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdKhachHang.RowCount > 0)
            {
                if (grdKhachHang.CurrentCell == null)
                    return;
                if (grdKhachHang.CurrentCell.RowIndex < grdKhachHang.RowCount)
                {
                    int hang = grdKhachHang.CurrentCell.RowIndex;
                    string ma = grdKhachHang.Rows[hang].Cells[0].Value.ToString();
                    string select = "SELECT [MaKH],[TenKH],[DiaChi],[SoDT],[NoCu] FROM [tblKhachHang] WHERE [MaKH]=N'" + ma + "'";

                    DataSet ds = DataConn.GrdSource(select);
                    txtMaKH.Text = ds.Tables[0].Rows[0]["MaKH"].ToString().Remove(0, 2);
                    txtTenKH.Text = ds.Tables[0].Rows[0]["TenKH"].ToString();
                    txtDiaChiKH.Text = ds.Tables[0].Rows[0]["DiaChi"].ToString();
                    txtDienThoaiKH.Text = ds.Tables[0].Rows[0]["SoDT"].ToString();
                    txtNoCu.Text = ds.Tables[0].Rows[0]["NoCu"].ToString();
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            //Exception khi không đủ dữ liệu
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Hãy Nhập Mã KH!", "Chú ý");
                txtMaKH.Select();
                return;
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Hãy Nhập Tên KH!", "Chú ý");
                txtTenKH.Select();
                return;
            }
            if (txtDiaChiKH.Text == "")
            {
                MessageBox.Show("Hãy Nhập Địa Chỉ KH!", "Chú ý");
                txtDiaChiKH.Select();
                return;
            }
            if (txtDienThoaiKH.Text == "")
            {
                MessageBox.Show("Hãy Nhập SĐT KH!", "Chú ý");
                txtTenKH.Select();
                return;
            }
            if (txtNoCu.Text == "")
            {
                txtNoCu.Text = "0";
            }
            string query_SQL = "";
            query_SQL = "SELECT COUNT(*)FROM tblKhachHang WHERE MaKH = N'" + lblMaKH.Text + txtMaKH.Text + "' ";
            if (DataConn.Lay1GiaTriSoDung_ExecuteScalar(query_SQL) <= 0)
            {
                query_SQL = "INSERT INTO [tblKhachHang]([MaKH],[TenKH],[DiaChi],[SoDT],[NoCu])VALUES (N'" + lblMaKH.Text + txtMaKH.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChiKH.Text + "' ," + txtDienThoaiKH.Text + "," + txtNoCu.Text + ")";
                DataConn.ThucHienCmd(query_SQL);
                MessageBox.Show("Thêm Khách Hàng Thành Công !", "Thông Báo");
            }
            else
            {
                if (MessageBox.Show("Cập Nhập Thông Tin Khách Hàng: "+ txtTenKH.Text + " ?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                
                query_SQL = "UPDATE tblKhachHang SET TenKH = N'" + txtTenKH.Text + "', DiaChi = N'" + txtDiaChiKH.Text + "', SoDT = " + txtDienThoaiKH.Text + ", NoCu = " + txtNoCu.Text + "" +
                            "WHERE MaKH = N'" + lblMaKH.Text + txtMaKH.Text + "' ";
                DataConn.ThucHienCmd(query_SQL);
                MessageBox.Show("Cập Nhập Thông Tin Thành Công !", "Thông Báo");
            }



            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = LayMaKH().ToString("000");
            txtDiaChiKH.Clear();
            txtTenKH.Clear();
            txtNoCu.Clear();
            txtDienThoaiKH.Clear();
            txtTenKH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Thông Tin Khách Hàng: " + txtTenKH.Text + " ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            else
                try
                {
                    // Xóa Thông Tin Khách Hàng Trong Bảng Giá Bán
                    string sqlDeleteGiaBan = "DELETE FROM tblGiaBan WHERE [MaKH]=N'" + lblMaKH.Text + txtMaKH.Text + "'";
                    DataConn.ThucHienCmd(sqlDeleteGiaBan);
                    // Xóa Thông Tin
                    string query_SQL = "DELETE FROM [tblKhachHang] WHERE [MaKH]=N'" + lblMaKH.Text + txtMaKH.Text + "'";
                    DataConn.ThucHienCmd(query_SQL);
                    MessageBox.Show("Xóa Khách Hàng Thành Công !");
                    HienThi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa Không Thành Công !" + ex);
                }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Thoát Khỏi Bảng Khách Hàng?", "Thông Báo !", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void txtDienThoaiKH_Leave(object sender, EventArgs e)
        {
            IsValidPhone(txtDienThoaiKH.Text);
        }

        public static bool IsValidEmail(string email)
        {
            Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }
        public static bool IsValidPhone(string value)
        {
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }

        private void txtMaHang_Leave(object sender, EventArgs e)
        {
            int int0 = 0;
            if (!int.TryParse(this.txtMaKH.Text, out int0))
            {
                MessageBox.Show("Nhập Số Nguyên Cho Mã KH !");
                txtMaKH.Select();
                return;
            }
            txtMaKH.Text = String.Format("{0:000}", double.Parse(txtMaKH.Text));
        }

        private void txtMaKH_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
        }

        private void txtNoCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
