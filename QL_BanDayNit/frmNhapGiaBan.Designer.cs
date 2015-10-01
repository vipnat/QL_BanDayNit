namespace QL_BanDayNit
{
    partial class frmNhapGiaBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapGiaBan));
            this.btnNhapGia = new System.Windows.Forms.Button();
            this.cbxKhachHang = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNhapGia
            // 
            this.btnNhapGia.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapGia.Image")));
            this.btnNhapGia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhapGia.Location = new System.Drawing.Point(160, 68);
            this.btnNhapGia.Name = "btnNhapGia";
            this.btnNhapGia.Size = new System.Drawing.Size(86, 35);
            this.btnNhapGia.TabIndex = 0;
            this.btnNhapGia.Text = "Nhập";
            this.btnNhapGia.UseVisualStyleBackColor = true;
            this.btnNhapGia.Click += new System.EventHandler(this.btnNhapGia_Click);
            // 
            // cbxKhachHang
            // 
            this.cbxKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxKhachHang.FormattingEnabled = true;
            this.cbxKhachHang.Location = new System.Drawing.Point(113, 23);
            this.cbxKhachHang.Name = "cbxKhachHang";
            this.cbxKhachHang.Size = new System.Drawing.Size(121, 29);
            this.cbxKhachHang.TabIndex = 2;
            this.cbxKhachHang.SelectedIndexChanged += new System.EventHandler(this.cbxKhachHang_SelectedIndexChanged);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(5, 27);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(102, 21);
            this.lblKhachHang.TabIndex = 3;
            this.lblKhachHang.Text = "Khách Hàng";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(311, 23);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(100, 29);
            this.txtGiaBan.TabIndex = 4;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(242, 28);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(70, 21);
            this.lblGiaBan.TabIndex = 5;
            this.lblGiaBan.Text = "Giá Bán";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(261, 68);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 35);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmNhapGiaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(578, 115);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.cbxKhachHang);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnNhapGia);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmNhapGiaBan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNhapGiaBan";
            this.Load += new System.EventHandler(this.frmNhapGiaBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNhapGia;
        private System.Windows.Forms.ComboBox cbxKhachHang;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Button btnThoat;
    }
}