namespace QL_BanDayNit
{
    partial class frmXuatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatHang));
            this.lblMaMatH = new System.Windows.Forms.Label();
            this.cbxMaMatH = new System.Windows.Forms.ComboBox();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.btnXuatHang = new System.Windows.Forms.Button();
            this.pckNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdXuatHang = new System.Windows.Forms.DataGridView();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtMaH = new System.Windows.Forms.TextBox();
            this.groupHoaDonXuat = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxKhachHang = new System.Windows.Forms.ComboBox();
            this.groupChiTietHDX = new System.Windows.Forms.GroupBox();
            this.cbxTenMatHang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bntTinhTien = new System.Windows.Forms.Button();
            this.rdbSanPham = new System.Windows.Forms.RadioButton();
            this.rdbDai = new System.Windows.Forms.RadioButton();
            this.rdbDau = new System.Windows.Forms.RadioButton();
            this.rdbDay = new System.Windows.Forms.RadioButton();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongSL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoMatHang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdXuatHang)).BeginInit();
            this.groupHoaDonXuat.SuspendLayout();
            this.groupChiTietHDX.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaMatH
            // 
            this.lblMaMatH.AutoSize = true;
            this.lblMaMatH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMatH.Location = new System.Drawing.Point(23, 22);
            this.lblMaMatH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaMatH.Name = "lblMaMatH";
            this.lblMaMatH.Size = new System.Drawing.Size(66, 19);
            this.lblMaMatH.TabIndex = 0;
            this.lblMaMatH.Text = "Mặt hàng";
            // 
            // cbxMaMatH
            // 
            this.cbxMaMatH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMaMatH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMaMatH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaMatH.FormattingEnabled = true;
            this.cbxMaMatH.Location = new System.Drawing.Point(86, 19);
            this.cbxMaMatH.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMaMatH.Name = "cbxMaMatH";
            this.cbxMaMatH.Size = new System.Drawing.Size(84, 27);
            this.cbxMaMatH.TabIndex = 6;
            this.cbxMaMatH.SelectedIndexChanged += new System.EventHandler(this.cboMaMatH_SelectedIndexChanged);
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNhanVien.Location = new System.Drawing.Point(39, 73);
            this.lblMaNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(70, 19);
            this.lblMaNhanVien.TabIndex = 3;
            this.lblMaNhanVien.Text = "Nhân viên";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHD.Location = new System.Drawing.Point(121, 19);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(178, 26);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.Location = new System.Drawing.Point(26, 21);
            this.lblMaHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(83, 19);
            this.lblMaHD.TabIndex = 5;
            this.lblMaHD.Text = "Mã hóa đơn";
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayXuat.Location = new System.Drawing.Point(423, 21);
            this.lblNgayXuat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(71, 19);
            this.lblNgayXuat.TabIndex = 7;
            this.lblNgayXuat.Text = "Ngày xuất";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(469, 20);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(95, 26);
            this.txtSoLuong.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(407, 22);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 19);
            this.lblSoLuong.TabIndex = 9;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(626, 20);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(95, 26);
            this.txtDonGia.TabIndex = 8;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(569, 23);
            this.lblDonGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(56, 19);
            this.lblDonGia.TabIndex = 11;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(121, 69);
            this.cboMaNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(178, 27);
            this.cboMaNhanVien.TabIndex = 2;
            this.cboMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboMaNhanVien_SelectedIndexChanged);
            // 
            // btnXuatHang
            // 
            this.btnXuatHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHang.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatHang.Image")));
            this.btnXuatHang.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatHang.Location = new System.Drawing.Point(503, 98);
            this.btnXuatHang.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatHang.Name = "btnXuatHang";
            this.btnXuatHang.Size = new System.Drawing.Size(149, 32);
            this.btnXuatHang.TabIndex = 5;
            this.btnXuatHang.Text = "Xuất hàng (&X)";
            this.btnXuatHang.UseVisualStyleBackColor = true;
            this.btnXuatHang.Click += new System.EventHandler(this.btnXuatHang_Click);
            // 
            // pckNgayXuat
            // 
            this.pckNgayXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pckNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pckNgayXuat.Location = new System.Drawing.Point(503, 19);
            this.pckNgayXuat.Margin = new System.Windows.Forms.Padding(4);
            this.pckNgayXuat.Name = "pckNgayXuat";
            this.pckNgayXuat.Size = new System.Drawing.Size(182, 26);
            this.pckNgayXuat.TabIndex = 3;
            this.pckNgayXuat.Value = new System.DateTime(2008, 4, 15, 14, 46, 2, 0);
            this.pckNgayXuat.ValueChanged += new System.EventHandler(this.pckNgayXuat_ValueChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(503, 66);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(182, 26);
            this.txtGhiChu.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(437, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ghi chú";
            // 
            // grdXuatHang
            // 
            this.grdXuatHang.AllowUserToAddRows = false;
            this.grdXuatHang.AllowUserToDeleteRows = false;
            this.grdXuatHang.AllowUserToResizeRows = false;
            this.grdXuatHang.BackgroundColor = System.Drawing.Color.LightCyan;
            this.grdXuatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdXuatHang.Location = new System.Drawing.Point(48, 240);
            this.grdXuatHang.Margin = new System.Windows.Forms.Padding(4);
            this.grdXuatHang.MultiSelect = false;
            this.grdXuatHang.Name = "grdXuatHang";
            this.grdXuatHang.ReadOnly = true;
            this.grdXuatHang.Size = new System.Drawing.Size(715, 146);
            this.grdXuatHang.TabIndex = 19;
            this.grdXuatHang.CurrentCellChanged += new System.EventHandler(this.grdXuatHang_CurrentCellChanged);
            this.grdXuatHang.SelectionChanged += new System.EventHandler(this.grdXuatHang_SelectionChanged);
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.Image")));
            this.btnGhi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGhi.Location = new System.Drawing.Point(283, 435);
            this.btnGhi.Margin = new System.Windows.Forms.Padding(4);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(84, 32);
            this.btnGhi.TabIndex = 15;
            this.btnGhi.Text = "Ghi (&G)";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(517, 435);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 32);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát (&T)";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 398);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tổng Tiền :";
            // 
            // btnInHD
            // 
            this.btnInHD.Enabled = false;
            this.btnInHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHD.Image = ((System.Drawing.Image)(resources.GetObject("btnInHD.Image")));
            this.btnInHD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInHD.Location = new System.Drawing.Point(378, 435);
            this.btnInHD.Margin = new System.Windows.Forms.Padding(4);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(132, 32);
            this.btnInHD.TabIndex = 17;
            this.btnInHD.Text = "In hóa đơn (&I)";
            this.btnInHD.UseVisualStyleBackColor = true;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.Location = new System.Drawing.Point(181, 435);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 32);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa (&X)";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMaH
            // 
            this.txtMaH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaH.Location = new System.Drawing.Point(855, 173);
            this.txtMaH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaH.Name = "txtMaH";
            this.txtMaH.Size = new System.Drawing.Size(42, 26);
            this.txtMaH.TabIndex = 27;
            this.txtMaH.Visible = false;
            // 
            // groupHoaDonXuat
            // 
            this.groupHoaDonXuat.Controls.Add(this.label5);
            this.groupHoaDonXuat.Controls.Add(this.cbxKhachHang);
            this.groupHoaDonXuat.Controls.Add(this.txtGhiChu);
            this.groupHoaDonXuat.Controls.Add(this.label1);
            this.groupHoaDonXuat.Controls.Add(this.pckNgayXuat);
            this.groupHoaDonXuat.Controls.Add(this.btnXuatHang);
            this.groupHoaDonXuat.Controls.Add(this.cboMaNhanVien);
            this.groupHoaDonXuat.Controls.Add(this.lblNgayXuat);
            this.groupHoaDonXuat.Controls.Add(this.txtMaHD);
            this.groupHoaDonXuat.Controls.Add(this.lblMaHD);
            this.groupHoaDonXuat.Controls.Add(this.lblMaNhanVien);
            this.groupHoaDonXuat.Location = new System.Drawing.Point(40, 7);
            this.groupHoaDonXuat.Name = "groupHoaDonXuat";
            this.groupHoaDonXuat.Size = new System.Drawing.Size(735, 142);
            this.groupHoaDonXuat.TabIndex = 28;
            this.groupHoaDonXuat.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 32;
            this.label5.Text = "Khách Hàng";
            // 
            // cbxKhachHang
            // 
            this.cbxKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKhachHang.FormattingEnabled = true;
            this.cbxKhachHang.Items.AddRange(new object[] {
            "Bán Lẻ",
            "100-500",
            "Bán Sỉ"});
            this.cbxKhachHang.Location = new System.Drawing.Point(121, 103);
            this.cbxKhachHang.Name = "cbxKhachHang";
            this.cbxKhachHang.Size = new System.Drawing.Size(178, 27);
            this.cbxKhachHang.TabIndex = 31;
            // 
            // groupChiTietHDX
            // 
            this.groupChiTietHDX.Controls.Add(this.cbxTenMatHang);
            this.groupChiTietHDX.Controls.Add(this.txtDonGia);
            this.groupChiTietHDX.Controls.Add(this.lblDonGia);
            this.groupChiTietHDX.Controls.Add(this.txtSoLuong);
            this.groupChiTietHDX.Controls.Add(this.lblSoLuong);
            this.groupChiTietHDX.Controls.Add(this.cbxMaMatH);
            this.groupChiTietHDX.Controls.Add(this.lblMaMatH);
            this.groupChiTietHDX.Location = new System.Drawing.Point(40, 174);
            this.groupChiTietHDX.Name = "groupChiTietHDX";
            this.groupChiTietHDX.Size = new System.Drawing.Size(736, 61);
            this.groupChiTietHDX.TabIndex = 29;
            this.groupChiTietHDX.TabStop = false;
            // 
            // cbxTenMatHang
            // 
            this.cbxTenMatHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTenMatHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTenMatHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTenMatHang.FormattingEnabled = true;
            this.cbxTenMatHang.Location = new System.Drawing.Point(173, 19);
            this.cbxTenMatHang.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTenMatHang.Name = "cbxTenMatHang";
            this.cbxTenMatHang.Size = new System.Drawing.Size(232, 27);
            this.cbxTenMatHang.TabIndex = 12;
            this.cbxTenMatHang.SelectedIndexChanged += new System.EventHandler(this.cbxTenMatHang_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(516, 398);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tổng SL :";
            // 
            // bntTinhTien
            // 
            this.bntTinhTien.Location = new System.Drawing.Point(771, 275);
            this.bntTinhTien.Name = "bntTinhTien";
            this.bntTinhTien.Size = new System.Drawing.Size(62, 71);
            this.bntTinhTien.TabIndex = 30;
            this.bntTinhTien.Text = "Tinh Tiền";
            this.bntTinhTien.UseVisualStyleBackColor = true;
            this.bntTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // rdbSanPham
            // 
            this.rdbSanPham.AutoSize = true;
            this.rdbSanPham.Checked = true;
            this.rdbSanPham.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSanPham.Location = new System.Drawing.Point(202, 154);
            this.rdbSanPham.Name = "rdbSanPham";
            this.rdbSanPham.Size = new System.Drawing.Size(103, 25);
            this.rdbSanPham.TabIndex = 41;
            this.rdbSanPham.TabStop = true;
            this.rdbSanPham.Text = "Sản Phẩm";
            this.rdbSanPham.UseVisualStyleBackColor = true;
            this.rdbSanPham.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // rdbDai
            // 
            this.rdbDai.AutoSize = true;
            this.rdbDai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDai.Location = new System.Drawing.Point(524, 154);
            this.rdbDai.Name = "rdbDai";
            this.rdbDai.Size = new System.Drawing.Size(54, 25);
            this.rdbDai.TabIndex = 38;
            this.rdbDai.Text = "Đai";
            this.rdbDai.UseVisualStyleBackColor = true;
            this.rdbDai.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // rdbDau
            // 
            this.rdbDau.AutoSize = true;
            this.rdbDau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDau.Location = new System.Drawing.Point(417, 154);
            this.rdbDau.Name = "rdbDau";
            this.rdbDau.Size = new System.Drawing.Size(59, 25);
            this.rdbDau.TabIndex = 39;
            this.rdbDau.Text = "Đầu";
            this.rdbDau.UseVisualStyleBackColor = true;
            this.rdbDau.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // rdbDay
            // 
            this.rdbDay.AutoSize = true;
            this.rdbDay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDay.Location = new System.Drawing.Point(310, 154);
            this.rdbDay.Name = "rdbDay";
            this.rdbDay.Size = new System.Drawing.Size(58, 25);
            this.rdbDay.TabIndex = 40;
            this.rdbDay.Text = "Dây";
            this.rdbDay.UseVisualStyleBackColor = true;
            this.rdbDay.CheckedChanged += new System.EventHandler(this.rdbSanPham_CheckedChanged);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(349, 397);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(20, 22);
            this.lblTongTien.TabIndex = 42;
            this.lblTongTien.Text = "0";
            // 
            // lblTongSL
            // 
            this.lblTongSL.AutoSize = true;
            this.lblTongSL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSL.ForeColor = System.Drawing.Color.Red;
            this.lblTongSL.Location = new System.Drawing.Point(584, 397);
            this.lblTongSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongSL.Name = "lblTongSL";
            this.lblTongSL.Size = new System.Drawing.Size(20, 22);
            this.lblTongSL.TabIndex = 22;
            this.lblTongSL.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 398);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Số Mặt Hàng:";
            // 
            // lblSoMatHang
            // 
            this.lblSoMatHang.AutoSize = true;
            this.lblSoMatHang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoMatHang.ForeColor = System.Drawing.Color.Red;
            this.lblSoMatHang.Location = new System.Drawing.Point(165, 397);
            this.lblSoMatHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoMatHang.Name = "lblSoMatHang";
            this.lblSoMatHang.Size = new System.Drawing.Size(20, 22);
            this.lblSoMatHang.TabIndex = 42;
            this.lblSoMatHang.Text = "0";
            // 
            // frmXuatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(845, 484);
            this.ControlBox = false;
            this.Controls.Add(this.lblSoMatHang);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.rdbSanPham);
            this.Controls.Add(this.rdbDai);
            this.Controls.Add(this.rdbDau);
            this.Controls.Add(this.rdbDay);
            this.Controls.Add(this.lblTongSL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bntTinhTien);
            this.Controls.Add(this.groupChiTietHDX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupHoaDonXuat);
            this.Controls.Add(this.txtMaH);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.grdXuatHang);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmXuatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất Hàng";
            this.Load += new System.EventHandler(this.frmXuatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdXuatHang)).EndInit();
            this.groupHoaDonXuat.ResumeLayout(false);
            this.groupHoaDonXuat.PerformLayout();
            this.groupChiTietHDX.ResumeLayout(false);
            this.groupChiTietHDX.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaMatH;
        private System.Windows.Forms.ComboBox cbxMaMatH;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblNgayXuat;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.ComboBox cboMaNhanVien;

        private System.Windows.Forms.Button btnXuatHang;
        private System.Windows.Forms.DateTimePicker pckNgayXuat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdXuatHang;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtMaH;
        private System.Windows.Forms.GroupBox groupHoaDonXuat;
        private System.Windows.Forms.GroupBox groupChiTietHDX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bntTinhTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxKhachHang;
        private System.Windows.Forms.ComboBox cbxTenMatHang;
        private System.Windows.Forms.RadioButton rdbSanPham;
        private System.Windows.Forms.RadioButton rdbDai;
        private System.Windows.Forms.RadioButton rdbDau;
        private System.Windows.Forms.RadioButton rdbDay;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoMatHang;
    }
}