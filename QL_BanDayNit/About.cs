using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pea)
        { 
            Graphics grfx = pea.Graphics;
            Brush brush = new SolidBrush(ForeColor);
            int y = 20;
            grfx.DrawString("     Chương trình quản lý bán hàng được", Font, brush, 5, y);
            grfx.DrawString("     viết bằng ngôn ngữ C#",Font,brush,5,y+=Font.Height);
            grfx.DrawString("     Tác giả: Nguyễn Anh Tuấn",Font,brush,5,y+=Font.Height);
            grfx.DrawString("     ĐT : 0909399534 - 0915458345",Font,brush,5,y+=Font.Height);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
