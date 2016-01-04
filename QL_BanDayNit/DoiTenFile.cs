using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QL_BanDayNit
{
    public partial class frmDoiTenFile : Form
    {
        public frmDoiTenFile()
        {
            InitializeComponent();
        }      

        private void frmDoiTenFile_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "c:\\";//đường dẫn mặc định thư mục lúc mở ra
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)//gọi thư mục
            {
                ShowFile(fl.SelectedPath);//duyệt thư mục
            }
        }

        //Lấy Danh Sách File Trong Thư Mục Và Đổi Tên
        //System.IO.File.Move((string)oldFileName, (string)newFileName) // đổi tên cho file.
        //System.IO.Directory.Move((string)oldFolderName, (string)newFolderName) // đổi tên cho thư mục.

        public void ShowFile(string path)
        {
            if (File.Exists(path))
            {
                ProcessFile(path, "");//nếu file không tồn tại
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path); // nếu file tồn tại
            }
            else
            {
                Console.WriteLine("{0} : Không đọc được file.", path);
            }
        }

        public void ProcessDirectory(string pathfile)
        {
            string[] fileList = Directory.GetFiles(pathfile);//lay danh sách file cho vao mảng
            string strFileName = "";
            //duyet mang file trong thư mục

            foreach (string fileName in fileList)
            {
                strFileName = "";
                strFileName = Path.GetFileName(fileName).Trim();
                ProcessFile(fileName, strFileName);
            }

            string[] directorylist = Directory.GetDirectories(pathfile);//lấy danh sách target file cho vào mảng

            //duyệt mảng target
            foreach (string directory in directorylist)
            {
                ProcessDirectory(directory);
            }
        }

        public void ProcessFile(string path, string strfileName)
        {
            //MessageBox.Show(""+ path + "\n" + strfileName);
            //System.IO.File.Move((string)oldFileName, (string)newFileName);                      
        }

        private void btnChoiseFolder_Click(object sender, EventArgs e)// nút click vào sẽ hiển thị chọn folder
        {
           
        }
    }
}
