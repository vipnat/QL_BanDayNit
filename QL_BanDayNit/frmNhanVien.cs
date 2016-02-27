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
    public partial class frmNhanVien : Form
    {
        private bool kt;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //Đưa vào các list cho checklistbox
            chkListBox.Items.Insert(0, "Mã nhân viên");
            chkListBox.Items.Insert(1, "Tên nhân viên");
            chkListBox.Items.Insert(2, "Địa chỉ");
            chkListBox.Items.Insert(3, "Điện thoại");

            HienThi();
            //Gọi đến nút thêm
            btnThem_Click(sender, e);
        }

        //Load từ grid lên các ô textbox
        private void grdKq_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grdKq.RowCount > 0)
            {
                if (grdKq.CurrentCell == null)
                    return;
                if (grdKq.CurrentCell.RowIndex < grdKq.RowCount)
                {
                    int hang = grdKq.CurrentCell.RowIndex;
                    string ma = grdKq.Rows[hang].Cells[0].Value.ToString();
                    string select = "SELECT MaNhanVien,TenNhanVien,DiaChi,DienThoai FROM tblNhanVien WHERE MaNhanVien=N'"+ma+"'";

                    DataSet ds = DataConn.GrdSource(select);
                    txtMaNV.Text = ds.Tables[0].Rows[0]["MaNhanVien"].ToString().Remove(0,2);
                    txtTenNV.Text = ds.Tables[0].Rows[0]["TenNhanVien"].ToString();
                    txtDiaChi.Text = ds.Tables[0].Rows[0]["DiaChi"].ToString();
                    txtDienThoai.Text = ds.Tables[0].Rows[0]["DienThoai"].ToString();
                }
            }
        }

        private int LayMaNV()
        {
            int mNV = 1;
            string select1 = "SELECT [MaNhanVien] from [tblNhanVien]";
            SqlDataReader sqlData = DataConn.ThucHienReader(select1);
            try
            {
                while (sqlData.Read())
                {
                    string aa = sqlData.GetString(0);
                    int getMaKH = Convert.ToInt32(sqlData.GetString(0).Remove(0, 2));
                    if (getMaKH >= mNV)
                    {
                        mNV = getMaKH + 1;
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

            return mNV;
        }

        private void HienThi()
        {
            string select = "select MaNhanVien [Mã nhân viên],TenNhanVien [Tên nhân viên],DiaChi [Địa chỉ],DienThoai [Điện thoại] from tblNhanVien";
            DataSet ds = DataConn.GrdSource(select);
            grdKq.DataSource = ds.Tables[0];
            grdKq.Refresh();
            if (grdKq.RowCount <= 0)
                txtMaNV.Text = LayMaNV().ToString("000");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = true;
            btnHoan.Enabled = true;
            btnThoat.Enabled = true;
            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = false;
            txtDienThoai.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string strMaNhanVien = lblMaNV.Text + txtMaNV.Text;
            if (kt == true)//Thêm
            {
                string select = "";
                try
                {
                    //Thiếu thông tin - > báo lỗi
                    if (txtMaNV.Text == "")
                    {
                        MessageBox.Show("Hãy nhập mã nhân viên!","Chú ý!");
                        txtMaNV.Select();
                        return;
                    }
                    if (txtTenNV.Text == "")
                    {
                        MessageBox.Show("Hãy nhập tên nhân viên!", "Chú ý!");
                        txtTenNV.Select();
                        return;
                    }
                    if (txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Hãy nhập địa chỉ nhân viên!", "Chú ý!");
                        txtDiaChi.Select();
                        return;
                    }
                    //Bắt lỗi nếu trùng mã nhân viên
                    string select1 = "select MaNhanVien from tblNhanVien";
                    SqlDataReader sqlData = DataConn.ThucHienReader(select1);

                    
                    try
                    {
                        while (sqlData.Read())
                        {
                            if (sqlData.GetString(0) == strMaNhanVien)
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

                    //select1 = "select TenNhanVien from tblNhanVien";
                    //SqlDataReader sqlData1 = DataConn.ThucHienReader(select1);
                    //if (dr1 != null)
                    //{
                    //    while (dr1.Read())
                    //    {
                    //        if (dr1.GetString(0) == txtTenNV.Text)
                    //        {
                    //            dr1.Close();
                    //            dr1.Dispose();
                    //            throw new SameKeyException();
                    //        }
                    //    }
                    //}
                    //dr1.Close();
                    //dr1.Dispose();

                    select = "insert into tblNhanVien values(N'" + strMaNhanVien + "',N'" + txtTenNV.Text + "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "')";
                    DataConn.ThucHienCmd(select);
                    HienThi();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Bạn hãy xem lại hoặc nhấn F1 để vào trợ giúp!");
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Không có đủ dữ liệu để thêm!");
                }
                catch (SameKeyException)
                {
                    MessageBox.Show("Đã có nhân viên với mã này! Hãy nhập mã nhân viên khác!","Thông báo!");
                }
            }
            else//Sửa
            {
                try
                {
                    if (txtMaNV.Text == "" && txtTenNV.Text == "" && txtDienThoai.Text == "" && txtDiaChi.Text == "")
                        throw new NotEnoughInfoException();
                    string update = "UPDATE tblNhanVien SET TenNhanVien=N'"+txtTenNV.Text+"',DiaChi=N'" + txtDiaChi.Text + "',DienThoai=N'" + txtDienThoai.Text + "' WHERE MaNhanVien=N'" + strMaNhanVien + "'";
                    DataConn.ThucHienCmd(update);

                    HienThi();
                }
                catch (NotEnoughInfoException)
                {
                    MessageBox.Show("Không có đủ dữ liệu để sửa");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = true;
            btnHoan.Enabled = true;
            btnThoat.Enabled = true;
            txtTenNV.ReadOnly = false;
            txtDienThoai.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTenNV.Text = "";
            txtMaNV.Text = LayMaNV().ToString("000");

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHoan_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
            btnGhi.Enabled = false;
            btnHoan.Enabled = false;
            txtTenNV.ReadOnly = true;
            txtMaNV.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //Nếu ko có đủ dữ liệu->thông báo thiếu dữ liệu
                if (txtMaNV.Text == "" && txtTenNV.Text == "" && txtDienThoai.Text == "" && txtDiaChi.Text == "")
                    throw new NotEnoughInfoException();
                //Nếu trong hóa đơn xuất có nhân viên này lập -> thông báo phải xóa hóa đơn trước khi xóa nhân viên
                string select1 = "select MaNhanVien from tblHoaDonXuat";
                SqlDataReader sqlData = DataConn.ThucHienReader(select1);

                string strMaNhanVien = lblMaNV.Text + txtMaNV.Text;
                try
                {
                    while (sqlData.Read())
                    {
                        if (sqlData.GetString(0) == strMaNhanVien)
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
                //Thực hiện xóa nhân viên
                string delete = "DELETE tblNhanVien WHERE MaNhanVien=N'" + strMaNhanVien + "'";
                DataConn.ThucHienCmd(delete);
                HienThi();
            }
            catch (NotEnoughInfoException)
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu trước khi nhấn nút xóa!");
            }
            catch (SameKeyException)
            {
                MessageBox.Show("Đang có hóa đơn xuất nhân viên này lập! Hãy xóa hóa đơn trước khi xóa nhân viên!","Chú ý!");
            }
        }

        private void chkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkListBox.GetItemChecked(0) == true)
                grdKq.Columns[0].Visible = true;
            else
                grdKq.Columns[0].Visible = false;

            if (chkListBox.GetItemChecked(1) == true)
                grdKq.Columns[1].Visible = true;
            else
                grdKq.Columns[1].Visible = false;

            if (chkListBox.GetItemChecked(2) == true)
                grdKq.Columns[2].Visible = true;
            else
                grdKq.Columns[2].Visible = false;

            if (chkListBox.GetItemChecked(3) == true)
                grdKq.Columns[3].Visible = true;
            else
                grdKq.Columns[3].Visible = false;
        }
    }
}