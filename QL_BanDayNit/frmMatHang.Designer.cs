namespace QL_BanDayNit
{
    partial class frmMatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatHang));
            this.grvHienThiList = new System.Windows.Forms.DataGridView();
            this.lblMatHang = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtMaHang = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.rdbDay = new System.Windows.Forms.RadioButton();
            this.rdbSanPham = new System.Windows.Forms.RadioButton();
            this.rdbDau = new System.Windows.Forms.RadioButton();
            this.rdbDai = new System.Windows.Forms.RadioButton();
            this.lblMaHang = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbxHienThi = new System.Windows.Forms.CheckBox();
            this.cbbSize = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grvHienThiList)).BeginInit();
            this.SuspendLayout();
            // 
            // grvHienThiList
            // 
            this.grvHienThiList.AllowUserToAddRows = false;
            this.grvHienThiList.AllowUserToDeleteRows = false;
            this.grvHienThiList.AllowUserToResizeRows = false;
            this.grvHienThiList.BackgroundColor = System.Drawing.Color.LightCyan;
            this.grvHienThiList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvHienThiList.Location = new System.Drawing.Point(19, 111);
            this.grvHienThiList.Margin = new System.Windows.Forms.Padding(4);
            this.grvHienThiList.MultiSelect = false;
            this.grvHienThiList.Name = "grvHienThiList";
            this.grvHienThiList.ReadOnly = true;
            this.grvHienThiList.Size = new System.Drawing.Size(784, 200);
            this.grvHienThiList.TabIndex = 11;
            this.grvHienThiList.CurrentCellChanged += new System.EventHandler(this.grvHienThiList_CurrentCellChanged);
            // 
            // lblMatHang
            // 
            this.lblMatHang.AutoSize = true;
            this.lblMatHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatHang.Location = new System.Drawing.Point(121, 45);
            this.lblMatHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.Size = new System.Drawing.Size(69, 19);
            this.lblMatHang.TabIndex = 17;
            this.lblMatHang.Text = "Mã hàng";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(587, 44);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 26);
            this.txtDonGia.TabIndex = 2;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 23;
            this.label1.Text = "Đơn giá";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(432, 44);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(77, 26);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Số lượng";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.Location = new System.Drawing.Point(290, 323);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 30);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa (&X)";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.Image")));
            this.btnGhi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGhi.Location = new System.Drawing.Point(395, 323);
            this.btnGhi.Margin = new System.Windows.Forms.Padding(4);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "Ghi (&G)";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(507, 323);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(124, 30);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát (&T)";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMaHang
            // 
            this.txtMaHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHang.Location = new System.Drawing.Point(236, 44);
            this.txtMaHang.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.ReadOnly = true;
            this.txtMaHang.Size = new System.Drawing.Size(107, 26);
            this.txtMaHang.TabIndex = 1;
            this.txtMaHang.Text = "0";
            this.txtMaHang.Leave += new System.EventHandler(this.txtMaHang_Leave);
            // 
            // txtTenHang
            // 
            this.txtTenHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenHang.Location = new System.Drawing.Point(190, 77);
            this.txtTenHang.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(251, 26);
            this.txtTenHang.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(117, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tên hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Giá Bán Chung";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(564, 77);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(122, 26);
            this.txtGiaBan.TabIndex = 3;
            this.txtGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // rdbDay
            // 
            this.rdbDay.AutoSize = true;
            this.rdbDay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDay.Location = new System.Drawing.Point(321, 11);
            this.rdbDay.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDay.Name = "rdbDay";
            this.rdbDay.Size = new System.Drawing.Size(58, 25);
            this.rdbDay.TabIndex = 36;
            this.rdbDay.Text = "Dây";
            this.rdbDay.UseVisualStyleBackColor = true;
            this.rdbDay.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // rdbSanPham
            // 
            this.rdbSanPham.AutoSize = true;
            this.rdbSanPham.Checked = true;
            this.rdbSanPham.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSanPham.Location = new System.Drawing.Point(208, 11);
            this.rdbSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSanPham.Name = "rdbSanPham";
            this.rdbSanPham.Size = new System.Drawing.Size(103, 25);
            this.rdbSanPham.TabIndex = 37;
            this.rdbSanPham.TabStop = true;
            this.rdbSanPham.Text = "Sản Phẩm";
            this.rdbSanPham.UseVisualStyleBackColor = true;
            this.rdbSanPham.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // rdbDau
            // 
            this.rdbDau.AutoSize = true;
            this.rdbDau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDau.Location = new System.Drawing.Point(409, 11);
            this.rdbDau.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDau.Name = "rdbDau";
            this.rdbDau.Size = new System.Drawing.Size(59, 25);
            this.rdbDau.TabIndex = 36;
            this.rdbDau.Text = "Đầu";
            this.rdbDau.UseVisualStyleBackColor = true;
            this.rdbDau.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // rdbDai
            // 
            this.rdbDai.AutoSize = true;
            this.rdbDai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDai.Location = new System.Drawing.Point(493, 11);
            this.rdbDai.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDai.Name = "rdbDai";
            this.rdbDai.Size = new System.Drawing.Size(54, 25);
            this.rdbDai.TabIndex = 36;
            this.rdbDai.Text = "Đai";
            this.rdbDai.UseVisualStyleBackColor = true;
            this.rdbDai.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // lblMaHang
            // 
            this.lblMaHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaHang.ForeColor = System.Drawing.Color.Red;
            this.lblMaHang.Location = new System.Drawing.Point(194, 45);
            this.lblMaHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(46, 22);
            this.lblMaHang.TabIndex = 17;
            this.lblMaHang.Text = "MSP";
            this.lblMaHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.Location = new System.Drawing.Point(185, 323);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(97, 30);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbxHienThi
            // 
            this.cbxHienThi.AutoSize = true;
            this.cbxHienThi.Location = new System.Drawing.Point(587, 11);
            this.cbxHienThi.Name = "cbxHienThi";
            this.cbxHienThi.Size = new System.Drawing.Size(213, 25);
            this.cbxHienThi.TabIndex = 38;
            this.cbxHienThi.Text = "Hiển Thị Theo Từng KH";
            this.cbxHienThi.UseVisualStyleBackColor = true;
            this.cbxHienThi.CheckedChanged += new System.EventHandler(this.cbxHienThi_CheckedChanged);
            // 
            // cbbSize
            // 
            this.cbbSize.FormattingEnabled = true;
            this.cbbSize.Items.AddRange(new object[] {
            "",
            "2F",
            "2F5",
            "3F",
            "3F5",
            "4F",
            "Da",
            "Bóp",
            "PK"});
            this.cbbSize.Location = new System.Drawing.Point(121, 323);
            this.cbbSize.Name = "cbbSize";
            this.cbbSize.Size = new System.Drawing.Size(57, 29);
            this.cbbSize.TabIndex = 39;
            // 
            // frmMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(820, 371);
            this.Controls.Add(this.cbbSize);
            this.Controls.Add(this.cbxHienThi);
            this.Controls.Add(this.rdbSanPham);
            this.Controls.Add(this.rdbDai);
            this.Controls.Add(this.rdbDau);
            this.Controls.Add(this.rdbDay);
            this.Controls.Add(this.txtTenHang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaHang);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grvHienThiList);
            this.Controls.Add(this.lblMaHang);
            this.Controls.Add(this.lblMatHang);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mặt hàng";
            this.Load += new System.EventHandler(this.frmMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvHienThiList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grvHienThiList;
        private System.Windows.Forms.Label lblMatHang;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMaHang;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.RadioButton rdbDay;
        private System.Windows.Forms.RadioButton rdbSanPham;
        private System.Windows.Forms.RadioButton rdbDau;
        private System.Windows.Forms.RadioButton rdbDai;
        private System.Windows.Forms.Label lblMaHang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox cbxHienThi;
        private System.Windows.Forms.ComboBox cbbSize;
    }
}