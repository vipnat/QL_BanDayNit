using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmNhapGiaBan : Form
    {
        public frmNhapGiaBan()
        {
            InitializeComponent();
        }

        public delegate void LoadData();
        public LoadData MyLoadData;
        private string _maMatHang;


        public frmNhapGiaBan(string Message) : this()
        {
            _maMatHang = Message;
        }

        private void frmNhapGiaBan_Load(object sender, EventArgs e)
        {
            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            cbxKhachHang.DataSource = dsKH.Tables[0];
            cbxKhachHang.DisplayMember = "TenKH";
            cbxKhachHang.ValueMember = "MaKH";

            txtGiaBan.Text = LayGiaBanTheoTenMaKH(dsKH.Tables[0].Rows[0]["MaKH"].ToString(), _maMatHang);
        }

        private void btnNhapGia_Click(object sender, EventArgs e)
        {
            string tenKH = cbxKhachHang.Text;
            string maKH = cbxKhachHang.SelectedValue.ToString();
            string giaban = txtGiaBan.Text;
            try
            {
                if (double.Parse(txtGiaBan.Text) <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0!");
                    txtGiaBan.Select();
                    return;
                }
                UpdateGiaBanKhachHangChung(maKH, _maMatHang, giaban);
            }
            catch (FormatException)
            {
                MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Hãy xem trợ giúp!");
            }
        }

        private void UpdateGiaBanKhachHangChung(string makhachhang, string mahang, string giaban)
        {
            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            DataTable dtTable = dsKH.Tables[0];
            foreach (DataRow row in dtTable.Rows)
            {
                string maKH = row["MaKH"].ToString();
                if (maKH == makhachhang)
                {
                    string strGiaBan = giaban.Replace(",", ".");
                    string selectGiaBan = "SELECT Count(*)FROM tblGiaBan WHERE MaKH = '" + makhachhang + "' AND MaMatH = '" + mahang + "'";
                    if(DataConn.Lay1GiaTriSoDung_ExecuteScalar(selectGiaBan) != 0)
                    {
                        string updateGia = "UPDATE tblGiaBan SET GiaBan='" + strGiaBan + "' WHERE MaMatH='" + mahang + "' AND MaKH='" + maKH + "'";
                        DataConn.ThucHienCmd(updateGia);
                    }
                    else
                    {
                        string insertGiaBan = "INSERT INTO tblGiaBan VALUES('" + mahang + "','"+ makhachhang + "',"+ strGiaBan + ")";
                        DataConn.ThucHienCmd(insertGiaBan);
                    }
                    MessageBox.Show("Cập Nhập Thành Công !");
                }
            }
        }

        string strGiaBanTruoc = "0";
        private void cbxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKhachHang.ValueMember != "")
            {
                strGiaBanTruoc = txtGiaBan.Text;
                txtGiaBan.Text = LayGiaBanTheoTenMaKH(cbxKhachHang.SelectedValue.ToString(), _maMatHang); ;
            }
        }

        private string LayGiaBanTheoTenMaKH(string maKH, string maMH)
        {
            string selectSQL = "SELECT GiaBan FROM tblGiaBan WHERE MaKH = '" + maKH + "' AND MaMatH = '" + maMH + "'";
            DataSet dsKH = DataConn.GrdSource(selectSQL);
            try
            {
                return dsKH.Tables[0].Rows[0]["GiaBan"].ToString();
            }
            catch
            {
                return strGiaBanTruoc;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MyLoadData();
            this.Close();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string decimalString = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char decimalChar = Convert.ToChar(decimalString);

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            { }
            else if (e.KeyChar == decimalChar && txtGiaBan.Text.IndexOf(decimalString) == -1)
            { }
            else
            {
                e.Handled = true;
            }
        }
    }
}
