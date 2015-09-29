using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                    

        public frmNhapGiaBan(string Message): this()
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
                MyLoadData();
            }
            catch (FormatException)
            {
                MessageBox.Show("Không đúng định dạng dữ liệu cần thiết! Hãy xem trợ giúp!");
            }
        }

        private void UpdateGiaBanKhachHangChung(string makhachhang,string mahang, string giaban)
        {
            string selectKH = "select* from tblKhachHang";
            DataSet dsKH = DataConn.GrdSource(selectKH);
            DataTable dtTable = dsKH.Tables[0];
            foreach (DataRow row in dtTable.Rows)
            {
                string maKH = row["MaKH"].ToString();
                if (maKH == makhachhang)
                {
                    string insertGia = "UPDATE tblGiaBan SET GiaBan='" + giaban + "' WHERE MaMatH='" + mahang + "' AND MaKH='" + maKH + "'";
                    DataConn.ThucHienCmd(insertGia);
                    MessageBox.Show("Cập Nhập Thành Công !");
                }
            }
        }

        private void cbxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKhachHang.ValueMember != "")
            {
                txtGiaBan.Text = LayGiaBanTheoTenMaKH(cbxKhachHang.SelectedValue.ToString(),_maMatHang); ;
            }
        }

        private string LayGiaBanTheoTenMaKH(string maKH,string maMH)
        {
            string selectSQL = "SELECT GiaBan FROM tblGiaBan WHERE MaKH = '"+ maKH +"' AND MaMatH = '"+ maMH +"'";
            DataSet dsKH = DataConn.GrdSource(selectSQL);            
            return dsKH.Tables[0].Rows[0]["GiaBan"].ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
