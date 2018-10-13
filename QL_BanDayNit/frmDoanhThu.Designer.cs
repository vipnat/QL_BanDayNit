namespace QL_BanDayNit
{
    partial class frmDoanhThu
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
            this.grvLoiNhuan = new System.Windows.Forms.DataGridView();
            this.cbxHienThi = new System.Windows.Forms.CheckBox();
            this.dtpThangNam = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dtpNam = new System.Windows.Forms.DateTimePicker();
            this.btnXemNam = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoiNhuan)).BeginInit();
            this.SuspendLayout();
            // 
            // grvLoiNhuan
            // 
            this.grvLoiNhuan.BackgroundColor = System.Drawing.Color.White;
            this.grvLoiNhuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvLoiNhuan.Location = new System.Drawing.Point(19, 84);
            this.grvLoiNhuan.Name = "grvLoiNhuan";
            this.grvLoiNhuan.Size = new System.Drawing.Size(522, 245);
            this.grvLoiNhuan.TabIndex = 0;
            // 
            // cbxHienThi
            // 
            this.cbxHienThi.AutoSize = true;
            this.cbxHienThi.Location = new System.Drawing.Point(406, 12);
            this.cbxHienThi.Name = "cbxHienThi";
            this.cbxHienThi.Size = new System.Drawing.Size(135, 23);
            this.cbxHienThi.TabIndex = 1;
            this.cbxHienThi.Text = "Hiển Thị Toàn Bộ";
            this.cbxHienThi.UseVisualStyleBackColor = true;
            this.cbxHienThi.CheckedChanged += new System.EventHandler(this.cbxHienThi_CheckedChanged);
            // 
            // dtpThangNam
            // 
            this.dtpThangNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpThangNam.Location = new System.Drawing.Point(21, 35);
            this.dtpThangNam.MinDate = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            this.dtpThangNam.Name = "dtpThangNam";
            this.dtpThangNam.Size = new System.Drawing.Size(100, 26);
            this.dtpThangNam.TabIndex = 7;
            this.dtpThangNam.Value = new System.DateTime(2018, 11, 1, 0, 0, 0, 0);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(127, 35);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 26);
            this.btnXem.TabIndex = 8;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Xem Doanh Thu Theo Tháng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(466, 51);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 27);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dtpNam
            // 
            this.dtpNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNam.Location = new System.Drawing.Point(212, 35);
            this.dtpNam.MinDate = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            this.dtpNam.Name = "dtpNam";
            this.dtpNam.Size = new System.Drawing.Size(100, 26);
            this.dtpNam.TabIndex = 7;
            this.dtpNam.Value = new System.DateTime(2018, 11, 1, 0, 0, 0, 0);
            // 
            // btnXemNam
            // 
            this.btnXemNam.Location = new System.Drawing.Point(318, 35);
            this.btnXemNam.Name = "btnXemNam";
            this.btnXemNam.Size = new System.Drawing.Size(75, 26);
            this.btnXemNam.TabIndex = 8;
            this.btnXemNam.Text = "Xem";
            this.btnXemNam.UseVisualStyleBackColor = true;
            this.btnXemNam.Click += new System.EventHandler(this.btnXemNam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Xem Doanh Thu Theo Năm";
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 341);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXemNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNam);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dtpThangNam);
            this.Controls.Add(this.cbxHienThi);
            this.Controls.Add(this.grvLoiNhuan);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doanh thu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvLoiNhuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView grvLoiNhuan;
        private System.Windows.Forms.CheckBox cbxHienThi;
        private System.Windows.Forms.DateTimePicker dtpThangNam;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DateTimePicker dtpNam;
        private System.Windows.Forms.Button btnXemNam;
        private System.Windows.Forms.Label label2;

        #endregion

        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        //private DoanhthuReport DoanhthuReport1;
        //private CachedTonkhoReport cachedTonkhoReport1;

    }
}