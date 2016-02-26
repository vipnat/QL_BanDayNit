namespace QL_BanDayNit
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblMaMatH = new System.Windows.Forms.Label();
            this.cboMaMatH = new System.Windows.Forms.ComboBox();
            this.grdKetQua = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoiPhuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThemNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhSachHoaDonNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXuatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhSachHDXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCXuatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBCTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCachSuDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.DoiTenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtHàngToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.đặtHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbxKhachHang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdKetQua)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaMatH
            // 
            this.lblMaMatH.AutoSize = true;
            this.lblMaMatH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMatH.Location = new System.Drawing.Point(61, 65);
            this.lblMaMatH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaMatH.Name = "lblMaMatH";
            this.lblMaMatH.Size = new System.Drawing.Size(96, 19);
            this.lblMaMatH.TabIndex = 0;
            this.lblMaMatH.Text = "Mặt hàng (*)";
            // 
            // cboMaMatH
            // 
            this.cboMaMatH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaMatH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMaMatH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMaMatH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaMatH.FormattingEnabled = true;
            this.cboMaMatH.Location = new System.Drawing.Point(165, 62);
            this.cboMaMatH.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaMatH.Name = "cboMaMatH";
            this.cboMaMatH.Size = new System.Drawing.Size(441, 27);
            this.cboMaMatH.TabIndex = 2;
            this.cboMaMatH.SelectedIndexChanged += new System.EventHandler(this.cboMaMatH_SelectedIndexChanged);
            // 
            // grdKetQua
            // 
            this.grdKetQua.AllowUserToAddRows = false;
            this.grdKetQua.AllowUserToDeleteRows = false;
            this.grdKetQua.AllowUserToResizeRows = false;
            this.grdKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKetQua.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdKetQua.Location = new System.Drawing.Point(77, 123);
            this.grdKetQua.Margin = new System.Windows.Forms.Padding(4);
            this.grdKetQua.MultiSelect = false;
            this.grdKetQua.Name = "grdKetQua";
            this.grdKetQua.ReadOnly = true;
            this.grdKetQua.Size = new System.Drawing.Size(751, 204);
            this.grdKetQua.TabIndex = 4;
            this.grdKetQua.CurrentCellChanged += new System.EventHandler(this.grdKetQua_CurrentCellChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quảnLýToolStripMenuItem,
            this.mnuDanhMuc,
            this.mnuBaoCao,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(915, 26);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhoiPhuc,
            this.mnuThoat});
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // mnuKhoiPhuc
            // 
            this.mnuKhoiPhuc.Name = "mnuKhoiPhuc";
            this.mnuKhoiPhuc.Size = new System.Drawing.Size(167, 22);
            this.mnuKhoiPhuc.Text = "&Khôi phục dữ liệu";
            this.mnuKhoiPhuc.Click += new System.EventHandler(this.KhoiPhucToolStripMenuItem_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnuThoat.Image")));
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.mnuThoat.Size = new System.Drawing.Size(167, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDoiMatKhau,
            this.mnuDangXuat,
            this.mnuThemNguoiDung});
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(99, 20);
            this.toolStripMenuItem2.Text = "&Người dùng";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("mnuDangNhap.Image")));
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(170, 22);
            this.mnuDangNhap.Text = "Đăng &nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(170, 22);
            this.mnuDoiMatKhau.Text = "Đổi &mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("mnuDangXuat.Image")));
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(170, 22);
            this.mnuDangXuat.Text = "Đăng &xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // mnuThemNguoiDung
            // 
            this.mnuThemNguoiDung.Name = "mnuThemNguoiDung";
            this.mnuThemNguoiDung.Size = new System.Drawing.Size(170, 22);
            this.mnuThemNguoiDung.Text = "&Thêm người dùng";
            this.mnuThemNguoiDung.Click += new System.EventHandler(this.thêmNgườiDùngToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhapHang,
            this.mnuXuatHang});
            this.quảnLýToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quảnLýToolStripMenuItem.Image")));
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.quảnLýToolStripMenuItem.Text = "Nghiệp &vụ";
            // 
            // mnuNhapHang
            // 
            this.mnuNhapHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoaDonNhap,
            this.mnuDanhSachHoaDonNhap});
            this.mnuNhapHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuNhapHang.Image")));
            this.mnuNhapHang.Name = "mnuNhapHang";
            this.mnuNhapHang.Size = new System.Drawing.Size(133, 22);
            this.mnuNhapHang.Text = "&Nhập hàng";
            // 
            // mnuHoaDonNhap
            // 
            this.mnuHoaDonNhap.Name = "mnuHoaDonNhap";
            this.mnuHoaDonNhap.Size = new System.Drawing.Size(176, 22);
            this.mnuHoaDonNhap.Text = "Hóa đơn nhập";
            this.mnuHoaDonNhap.Click += new System.EventHandler(this.hóaĐơnNhậpToolStripMenuItem_Click_1);
            // 
            // mnuDanhSachHoaDonNhap
            // 
            this.mnuDanhSachHoaDonNhap.Name = "mnuDanhSachHoaDonNhap";
            this.mnuDanhSachHoaDonNhap.Size = new System.Drawing.Size(176, 22);
            this.mnuDanhSachHoaDonNhap.Text = "Danh sách hóa đơn";
            this.mnuDanhSachHoaDonNhap.Click += new System.EventHandler(this.danhSáchHóaĐơnToolStripMenuItem_Click);
            // 
            // mnuXuatHang
            // 
            this.mnuXuatHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoaDonXuat,
            this.mnuDanhSachHDXuat});
            this.mnuXuatHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuXuatHang.Image")));
            this.mnuXuatHang.Name = "mnuXuatHang";
            this.mnuXuatHang.Size = new System.Drawing.Size(133, 22);
            this.mnuXuatHang.Text = "&Xuất hàng";
            // 
            // mnuHoaDonXuat
            // 
            this.mnuHoaDonXuat.Name = "mnuHoaDonXuat";
            this.mnuHoaDonXuat.Size = new System.Drawing.Size(176, 22);
            this.mnuHoaDonXuat.Text = "Hóa đơn xuất";
            this.mnuHoaDonXuat.Click += new System.EventHandler(this.hóaĐơnXuấtToolStripMenuItem_Click);
            // 
            // mnuDanhSachHDXuat
            // 
            this.mnuDanhSachHDXuat.Name = "mnuDanhSachHDXuat";
            this.mnuDanhSachHDXuat.Size = new System.Drawing.Size(176, 22);
            this.mnuDanhSachHDXuat.Text = "Danh sách hóa đơn";
            this.mnuDanhSachHDXuat.Click += new System.EventHandler(this.danhSáchHóađơnToolStripMenuItem1_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMatHang,
            this.toolStripMenuItem1,
            this.mnuNhanVien,
            this.toolStripMenuItem3,
            this.mnuKhachHang});
            this.mnuDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("mnuDanhMuc.Image")));
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(90, 20);
            this.mnuDanhMuc.Text = "&Danh mục";
            // 
            // mnuMatHang
            // 
            this.mnuMatHang.Name = "mnuMatHang";
            this.mnuMatHang.Size = new System.Drawing.Size(139, 22);
            this.mnuMatHang.Text = "&Mặt hàng";
            this.mnuMatHang.Click += new System.EventHandler(this.mặtHàngToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(139, 22);
            this.mnuNhanVien.Text = "N&hân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.nhânVienToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 6);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(139, 22);
            this.mnuKhachHang.Text = "&Khách Hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBCNhapHang,
            this.mnuBCXuatHang,
            this.toolStripMenuItem4,
            this.mnuBCTonKho,
            this.toolStripMenuItem5,
            this.mnuDoanhThu});
            this.mnuBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("mnuBaoCao.Image")));
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(77, 20);
            this.mnuBaoCao.Text = "&Báo cáo";
            // 
            // mnuBCNhapHang
            // 
            this.mnuBCNhapHang.Name = "mnuBCNhapHang";
            this.mnuBCNhapHang.Size = new System.Drawing.Size(133, 22);
            this.mnuBCNhapHang.Text = "Nh&ập hàng";
            // 
            // mnuBCXuatHang
            // 
            this.mnuBCXuatHang.Name = "mnuBCXuatHang";
            this.mnuBCXuatHang.Size = new System.Drawing.Size(133, 22);
            this.mnuBCXuatHang.Text = "Xuất hàn&g";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(130, 6);
            // 
            // mnuBCTonKho
            // 
            this.mnuBCTonKho.Name = "mnuBCTonKho";
            this.mnuBCTonKho.Size = new System.Drawing.Size(133, 22);
            this.mnuBCTonKho.Text = "&Tồn kho";
            this.mnuBCTonKho.Click += new System.EventHandler(this.tồnKhoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(130, 6);
            // 
            // mnuDoanhThu
            // 
            this.mnuDoanhThu.Name = "mnuDoanhThu";
            this.mnuDoanhThu.Size = new System.Drawing.Size(133, 22);
            this.mnuDoanhThu.Text = "&Doanh thu";
            this.mnuDoanhThu.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCachSuDung,
            this.mnuAbout,
            this.DoiTenFileToolStripMenuItem});
            this.mnuTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("mnuTroGiup.Image")));
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(80, 20);
            this.mnuTroGiup.Text = "T&rợ giúp";
            // 
            // mnuCachSuDung
            // 
            this.mnuCachSuDung.Image = ((System.Drawing.Image)(resources.GetObject("mnuCachSuDung.Image")));
            this.mnuCachSuDung.Name = "mnuCachSuDung";
            this.mnuCachSuDung.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuCachSuDung.Size = new System.Drawing.Size(222, 22);
            this.mnuCachSuDung.Text = "&Cách sử dụng";
            this.mnuCachSuDung.Click += new System.EventHandler(this.cáchSửDụngToolStripMenuItem_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(222, 22);
            this.mnuAbout.Text = "&Giới thiệu chương trình";
            this.mnuAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // DoiTenFileToolStripMenuItem
            // 
            this.DoiTenFileToolStripMenuItem.Name = "DoiTenFileToolStripMenuItem";
            this.DoiTenFileToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.DoiTenFileToolStripMenuItem.Text = "&Đổi Tên File Trong Thư Mục";
            this.DoiTenFileToolStripMenuItem.Click += new System.EventHandler(this.DoiTenFileToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhToolStripMenuItem,
            this.xuấtHàngToolStripMenuItem2,
            this.đặtHàngToolStripMenuItem1,
            this.trợGiúpToolStripMenuItem1,
            this.thoátToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 114);
            // 
            // nhToolStripMenuItem
            // 
            this.nhToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhToolStripMenuItem.Image")));
            this.nhToolStripMenuItem.Name = "nhToolStripMenuItem";
            this.nhToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.nhToolStripMenuItem.Text = "Nhập hàng";
            this.nhToolStripMenuItem.Click += new System.EventHandler(this.nhToolStripMenuItem_Click);
            // 
            // xuấtHàngToolStripMenuItem2
            // 
            this.xuấtHàngToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("xuấtHàngToolStripMenuItem2.Image")));
            this.xuấtHàngToolStripMenuItem2.Name = "xuấtHàngToolStripMenuItem2";
            this.xuấtHàngToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.xuấtHàngToolStripMenuItem2.Text = "Xuất hàng";
            this.xuấtHàngToolStripMenuItem2.Click += new System.EventHandler(this.xuấtHàngToolStripMenuItem2_Click);
            // 
            // đặtHàngToolStripMenuItem1
            // 
            this.đặtHàngToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("đặtHàngToolStripMenuItem1.Image")));
            this.đặtHàngToolStripMenuItem1.Name = "đặtHàngToolStripMenuItem1";
            this.đặtHàngToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.đặtHàngToolStripMenuItem1.Text = "Đặt hàng";
            // 
            // trợGiúpToolStripMenuItem1
            // 
            this.trợGiúpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("trợGiúpToolStripMenuItem1.Image")));
            this.trợGiúpToolStripMenuItem1.Name = "trợGiúpToolStripMenuItem1";
            this.trợGiúpToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.trợGiúpToolStripMenuItem1.Text = "Trợ giúp";
            this.trợGiúpToolStripMenuItem1.Click += new System.EventHandler(this.trợGiúpToolStripMenuItem1_Click);
            // 
            // thoátToolStripMenuItem1
            // 
            this.thoátToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("thoátToolStripMenuItem1.Image")));
            this.thoátToolStripMenuItem1.Name = "thoátToolStripMenuItem1";
            this.thoátToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.thoátToolStripMenuItem1.Text = "Thoát";
            this.thoátToolStripMenuItem1.Click += new System.EventHandler(this.thoátToolStripMenuItem1_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(771, 60);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 28);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbxKhachHang
            // 
            this.cbxKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxKhachHang.FormattingEnabled = true;
            this.cbxKhachHang.Items.AddRange(new object[] {
            "Bán Lẻ",
            "100-500",
            "Bán Sỉ"});
            this.cbxKhachHang.Location = new System.Drawing.Point(651, 62);
            this.cbxKhachHang.Name = "cbxKhachHang";
            this.cbxKhachHang.Size = new System.Drawing.Size(114, 27);
            this.cbxKhachHang.TabIndex = 7;
            this.cbxKhachHang.SelectedIndexChanged += new System.EventHandler(this.cbxKhachHang_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 357);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.cbxKhachHang);
            this.Controls.Add(this.grdKetQua);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cboMaMatH);
            this.Controls.Add(this.lblMaMatH);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bán Dây Nịt";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdKetQua)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaMatH;
        private System.Windows.Forms.ComboBox cboMaMatH;
        private System.Windows.Forms.DataGridView grdKetQua;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapHang;
        private System.Windows.Forms.ToolStripMenuItem mnuXuatHang;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuMatHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuCachSuDung;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuBCNhapHang;
        private System.Windows.Forms.ToolStripMenuItem mnuBCXuatHang;
        private System.Windows.Forms.ToolStripMenuItem mnuBCTonKho;
        private System.Windows.Forms.ToolStripMenuItem mnuDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuThemNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnuKhoiPhuc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtHàngToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem đặtHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDonNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhSachHoaDonNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDonXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhSachHDXuat;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cbxKhachHang;
        private System.Windows.Forms.ToolStripMenuItem DoiTenFileToolStripMenuItem;
    }
}

