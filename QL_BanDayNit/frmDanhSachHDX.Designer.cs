namespace QL_BanDayNit
{
    partial class frmDanhSachHDX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachHDX));
            this.grdView = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.chkListBox = new System.Windows.Forms.CheckedListBox();
            this.btnInHD = new System.Windows.Forms.Button();
            this.cbxChiTiet = new System.Windows.Forms.CheckBox();
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grbKH = new System.Windows.Forms.GroupBox();
            this.cbxTenKH = new System.Windows.Forms.ComboBox();
            this.cbxKH = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.grbKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToResizeRows = false;
            this.grdView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Location = new System.Drawing.Point(225, 56);
            this.grdView.Margin = new System.Windows.Forms.Padding(4);
            this.grdView.MultiSelect = false;
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(978, 362);
            this.grdView.TabIndex = 5;
            this.grdView.CurrentCellChanged += new System.EventHandler(this.grdView_CurrentCellChanged);
            this.grdView.SelectionChanged += new System.EventHandler(this.grdView_SelectionChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.Location = new System.Drawing.Point(508, 438);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(125, 32);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa (&X)";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(225, 18);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(148, 26);
            this.txtMa.TabIndex = 4;
            // 
            // chkListBox
            // 
            this.chkListBox.CheckOnClick = true;
            this.chkListBox.FormattingEnabled = true;
            this.chkListBox.Location = new System.Drawing.Point(18, 18);
            this.chkListBox.Margin = new System.Windows.Forms.Padding(4);
            this.chkListBox.Name = "chkListBox";
            this.chkListBox.Size = new System.Drawing.Size(196, 319);
            this.chkListBox.TabIndex = 3;
            this.chkListBox.SelectedIndexChanged += new System.EventHandler(this.chkListBox_SelectedIndexChanged);
            // 
            // btnInHD
            // 
            this.btnInHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHD.Image = ((System.Drawing.Image)(resources.GetObject("btnInHD.Image")));
            this.btnInHD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInHD.Location = new System.Drawing.Point(715, 438);
            this.btnInHD.Margin = new System.Windows.Forms.Padding(6);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(141, 32);
            this.btnInHD.TabIndex = 2;
            this.btnInHD.Text = "Xem Lại HĐ (&I)";
            this.btnInHD.UseVisualStyleBackColor = true;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // cbxChiTiet
            // 
            this.cbxChiTiet.AutoSize = true;
            this.cbxChiTiet.Checked = true;
            this.cbxChiTiet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxChiTiet.Location = new System.Drawing.Point(517, 20);
            this.cbxChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.cbxChiTiet.Name = "cbxChiTiet";
            this.cbxChiTiet.Size = new System.Drawing.Size(130, 23);
            this.cbxChiTiet.TabIndex = 6;
            this.cbxChiTiet.Text = "Hiển Thị Chi Tiết";
            this.cbxChiTiet.UseVisualStyleBackColor = true;
            this.cbxChiTiet.CheckedChanged += new System.EventHandler(this.cbxChiTiet_CheckedChanged);
            // 
            // btnXemHoaDon
            // 
            this.btnXemHoaDon.Location = new System.Drawing.Point(380, 18);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(75, 26);
            this.btnXemHoaDon.TabIndex = 7;
            this.btnXemHoaDon.Text = "Xem Hóa Đơn";
            this.btnXemHoaDon.UseVisualStyleBackColor = true;
            this.btnXemHoaDon.Click += new System.EventHandler(this.btnXemHoaDon_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(945, 438);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(125, 32);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grbKH
            // 
            this.grbKH.Controls.Add(this.cbxTenKH);
            this.grbKH.Controls.Add(this.cbxKH);
            this.grbKH.Location = new System.Drawing.Point(698, 1);
            this.grbKH.Name = "grbKH";
            this.grbKH.Size = new System.Drawing.Size(227, 53);
            this.grbKH.TabIndex = 11;
            this.grbKH.TabStop = false;
            this.grbKH.Text = "Xem Theo KH";
            // 
            // cbxTenKH
            // 
            this.cbxTenKH.FormattingEnabled = true;
            this.cbxTenKH.Location = new System.Drawing.Point(27, 19);
            this.cbxTenKH.Name = "cbxTenKH";
            this.cbxTenKH.Size = new System.Drawing.Size(193, 27);
            this.cbxTenKH.TabIndex = 1;
            this.cbxTenKH.SelectedIndexChanged += new System.EventHandler(this.cbxTenKH_SelectedIndexChanged);
            // 
            // cbxKH
            // 
            this.cbxKH.AutoSize = true;
            this.cbxKH.Location = new System.Drawing.Point(6, 26);
            this.cbxKH.Name = "cbxKH";
            this.cbxKH.Size = new System.Drawing.Size(15, 14);
            this.cbxKH.TabIndex = 0;
            this.cbxKH.UseVisualStyleBackColor = true;
            this.cbxKH.CheckedChanged += new System.EventHandler(this.cbxKH_CheckedChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(292, 438);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 32);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa HĐ";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmDanhSachHDX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1221, 514);
            this.Controls.Add(this.grbKH);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXemHoaDon);
            this.Controls.Add(this.cbxChiTiet);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.chkListBox);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.grdView);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmDanhSachHDX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách hóa đơn xuất";
            this.Load += new System.EventHandler(this.frmDanhSachHDX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.grbKH.ResumeLayout(false);
            this.grbKH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.CheckedListBox chkListBox;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.CheckBox cbxChiTiet;
        private System.Windows.Forms.Button btnXemHoaDon;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox grbKH;
        private System.Windows.Forms.ComboBox cbxTenKH;
        private System.Windows.Forms.CheckBox cbxKH;
        private System.Windows.Forms.Button btnEdit;
    }
}