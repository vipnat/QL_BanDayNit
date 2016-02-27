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

        string[] files = null;

        private void frmDoiTenFile_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.RootFolder = Environment.SpecialFolder.MyComputer;
            fld.ShowDialog();
            txtDirectory.Text = fld.SelectedPath;
            files = System.IO.Directory.GetFiles(txtDirectory.Text.Trim());
            txtTotalFile.Text = files.Length.ToString();
        }

        private void btnDoiTen_Click(object sender, EventArgs e)
        {
            // Lấy tất cả các tập tin trong thư mục truyền vào
            if (files == null)
                return;
            string originalFile = "", renamedFile = "";
            int countSuccess = 0, startedNumber = Convert.ToInt16(txtFirstNumber.Text);

            for (int i = 0; i < files.Length; i++)
            {
                originalFile = files[i];

                // cắt chuỗi bởi dấu '.' -> lấy phần mở rộng của tập tin, ví dụ .jpg, .doc, ...
                string[] fileParts = originalFile.Split(new char[] { '.' });

                // Tạo Số Đồng Bộ
                string strNumber = "";
                if(files.Length < 100)
                    strNumber = startedNumber++.ToString("00");
                if(files.Length >= 100)
                    strNumber = startedNumber++.ToString("000");

                // Tạo đường dẫn và tập tin đích
                renamedFile = txtDirectory.Text.Trim() + @"\\" + txtFileName.Text.Trim() + strNumber + "." + fileParts[fileParts.Length - 1];

                // Kiểm tra tập tin nguồn & đích
                // Nếu tập tin nguồn không tồn tại hoặc tập tin đích đã tồn tại rồi thì bỏ qua, không đổi tên
                if (!System.IO.File.Exists(originalFile) && System.IO.File.Exists(renamedFile))
                    continue;

                // Đổi tên sau khi kiểm tra hợp lệ
                System.IO.File.Move(originalFile, renamedFile);
                countSuccess++; // biến đếm tăng lên 1 khi đổi tên thành công
            }
            MessageBox.Show("Đổi Tên Thành Công " + countSuccess + " File.");
            files = null;
            txtDirectory.Clear();
            txtTotalFile.Text = "0";
            txtFileName.Clear();
            txtFirstNumber.Text = "0";
        }

        //private void btnOk_Click(object sender, EventArgs e)
        //{

        //    FolderBrowserDialog fl = new FolderBrowserDialog();
        //    fl.SelectedPath = "D:\\";//đường dẫn mặc định thư mục lúc mở ra
        //    fl.ShowNewFolderButton = true;
        //    if (fl.ShowDialog() == DialogResult.OK)//gọi thư mục
        //    {
        //        ShowFile(fl.SelectedPath);//duyệt thư mục
        //    }
        //}

        ////Lấy Danh Sách File Trong Thư Mục Và Đổi Tên
        ////System.IO.File.Move((string)oldFileName, (string)newFileName) // đổi tên cho file.
        ////System.IO.Directory.Move((string)oldFolderName, (string)newFolderName) // đổi tên cho thư mục.

        //public void ShowFile(string path)
        //{
        //    if (File.Exists(path))
        //    {
        //        ProcessFile(path, "");//nếu file không tồn tại
        //    }
        //    else if (Directory.Exists(path))
        //    {
        //        ProcessDirectory(path); // nếu file tồn tại
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} : Không đọc được file.", path);
        //    }
        //}

        //public void ProcessDirectory(string pathfile)
        //{
        //    string[] fileList = Directory.GetFiles(pathfile);//lay danh sách file cho vao mảng
        //    string strFileName = "";
        //    //duyet mang file trong thư mục

        //    foreach (string fileName in fileList)
        //    {
        //        strFileName = "";
        //        strFileName = Path.GetFileName(fileName).Trim();
        //        ProcessFile(fileName, strFileName);
        //    }

        //    string[] directorylist = Directory.GetDirectories(pathfile);//lấy danh sách target file cho vào mảng

        //    //duyệt mảng target
        //    foreach (string directory in directorylist)
        //    {
        //        ProcessDirectory(directory);
        //    }
        //}

        //public void ProcessFile(string path, string strfileName)
        //{
        //    MessageBox.Show(""+ path + "\n" + strfileName);
        //    //System.IO.File.Move((string)oldFileName, (string)newFileName);                      
        //}

        //private void btnChoiseFolder_Click(object sender, EventArgs e)// nút click vào sẽ hiển thị chọn folder
        //{

        //}
    }
}
