using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace QL_BanDayNit
{
    class DataConn
    {
        private static string source;
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataAdapter da;
        private static DataSet ds;
        // Tên Database trong CSDL  // Thư Mục Lưu Hóa Đơn
        private static string strTenDB = "BanHang"; public static string folderLuuHoaDon = System.IO.Directory.GetCurrentDirectory() + "\\LuuHoaDon\\";
        //private static string strTenDB = "BanHangTest"; public static string folderLuuHoaDon = "C:\\LuuHoaDon\\";

        // Add Tên Computer của bạn ở đây.
        private static string strPC_Name = Environment.MachineName;

        private static string fileDB_bak = System.IO.Directory.GetCurrentDirectory() + @"\DB_BanHang_Default_26-10-18.bak";
        private static string fileDB_sql = System.IO.Directory.GetCurrentDirectory() + @"\DB_BanHang_Default_26-10-18.sql";

        private static string strKetNoiAdmin = "Data Source=" + strPC_Name + ";Integrated Security=True;";
        private static SqlConnection adConn = new SqlConnection(strKetNoiAdmin);
        private static string strBackup = "USE MASTER RESTORE DATABASE " + strTenDB + " FROM DISK=N'" + fileDB_bak + "' WITH REPLACE";

        static DataConn()
        {
            // Kiểm Tra Database
            KiemTraTonTaiDatabase(strTenDB);

            source = strKetNoiAdmin + "database=" + strTenDB;
            con = new SqlConnection(source);
            try
            {
                con.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu! Hãy xem trợ giúp!");
            }
        }

        public static bool KiemTraTonTaiDatabase(string strDbName)
        {
            string sqlSelectIdDB;
            bool result = false;
            try
            {
                sqlSelectIdDB = string.Format("SELECT database_id FROM sys.databases WHERE Name = '" + strDbName + "'");
                using (adConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlSelectIdDB, adConn))
                    {
                        adConn.Open();
                        object resultObj = sqlCmd.ExecuteScalar();
                        int databaseID = 0;
                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }
                        if (databaseID <= 0)
                        {
                            if (MessageBox.Show("Chưa có Database tên " + strTenDB + " trong CSDL!.\nBạn muốn thêm vào không?.", "Lỗi Database", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                string getLocationFileDB = "";
                                if (!System.IO.File.Exists(fileDB_bak))  // Nếu Không Tìm Thấy File Backup .bak
                                {
                                    if (!System.IO.File.Exists(fileDB_sql))  // Nếu Không Tìm Thấy File Scrip .spl
                                    {
                                        MessageBox.Show("Không Tìm Thấy File Database\nHãy Chọn File Database.");
                                        // Lấy File Use Select
                                        getLocationFileDB = LayFileDBTuOpenShowdialog();
                                        if (Path.GetExtension(getLocationFileDB) == ".sql") // Kiểm Tra Nếu Là .sql
                                        {
                                            FileInfo getFileDB = new FileInfo(getLocationFileDB);
                                            strBackup = getFileDB.OpenText().ReadToEnd();
                                            strBackup = strBackup.Replace("GO", "");  // Xóa GO Trong Scrip
                                        }
                                        else // Kiểm Tra Nếu Là .bak
                                        {
                                            strBackup = "USE MASTER RESTORE DATABASE " + strTenDB + " FROM DISK=N'" + getLocationFileDB + "' WITH REPLACE";
                                        }
                                    }
                                    else  // Tìm Thấy File Scrip .sql
                                    {
                                        FileInfo getFileDB = new FileInfo(fileDB_sql);
                                        strBackup = getFileDB.OpenText().ReadToEnd();
                                        strBackup = strBackup.Replace("GO", "");  // Xóa GO Trong Scrip
                                    }
                                }
                                SqlCommand sqlCmdBackup = new SqlCommand(strBackup, adConn);
                                try
                                {
                                    sqlCmdBackup.ExecuteNonQuery();
                                    MessageBox.Show("Thêm Thành Công Database Mới !\nThêm Dữ Liệu Trước Khi Sử Dụng.");
                                    //if (!System.IO.File.Exists(strBackup))
                                    //{
                                    //    // Tạo 1 bản backup Database vào thư mục ...\bin\Debug
                                    //    // USE MASTER BACKUP DATABASE BanHang TO DISK = 'C:\DB_BanHang.bak' WITH INIT
                                    //}
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Không Add Được Database!\nHãy Thêm Từ MS-SQL.\nError: " + ex);
                                    Environment.Exit(1);
                                }
                            }
                            else  // Không Add Database
                            {
                                Environment.Exit(1);
                            }
                        }
                        adConn.Close();
                        result = (databaseID > 0);
                    }
                }
            }
            catch
            {
                return false;
            }
            return result;
        }

        public static int Lay1GiaTriSoDung_ExecuteScalar(string sqlQuery)
        {
            int _number = 0;
            try
            {
                cmd = new SqlCommand(sqlQuery, con);
                object resultObj = cmd.ExecuteScalar();

                if (resultObj != null)
                {
                    int.TryParse(resultObj.ToString(), out _number);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
            if (_number > 0)
                return _number;
            else
                return 0;
        }

        public static float Lay1GiaFloat_ExecuteScalar(string sqlQuery)
        {
            float _number = 0;
            try
            {
                cmd = new SqlCommand(sqlQuery, con);
                object resultObj = cmd.ExecuteScalar();

                if (resultObj != null)
                {
                    float.TryParse(resultObj.ToString(), out _number);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
            if (_number > 0)
                return _number;
            else
                return 0;
        }

        public static string Lay1GiaTriSelect_ExecuteScalar(string sqlQuery)
        {
            string getData = "";
            try
            {
                cmd = new SqlCommand(sqlQuery, con);
                object resultObj = cmd.ExecuteScalar();

                if (resultObj != null)
                {
                    getData = resultObj.ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
            return getData;
        }

        private static string LayFileDBTuOpenShowdialog()
        {
            OpenFileDialog openD = new OpenFileDialog();
            //Filter lọc ra các file để bạn dễ dàng lựa chọn (ví dụ các fiel MP3, hay WMA,....) 
            openD.Filter = "Database File|*.bak|Scrip File|*.sql";
            //Tên của hộp thoại hiện lên - Không có thì sẽ là mặc định 
            openD.Title = "Chọn Database";
            //Không phép chọn nhiều file cùng lúc - Mặc định là false 
            openD.Multiselect = false;
            //Mở hộp thoại 
            openD.ShowDialog();
            return openD.FileName;
        }

        public static void DongKetNoi()
        {
            cmd.Dispose();
            try
            {
                con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu! Hãy xem trợ giúp!");
            }
            finally
            {
                con.Dispose();
            }
        }

        public static void ThucHienCmd(string select)
        {
            cmd = new SqlCommand(select, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!");
                MessageBox.Show("" + se.Message);
            }
        }

        public static DataSet GrdSource(string select)
        {
            da = new SqlDataAdapter(select, con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static SqlDataReader ThucHienReader(string select)
        {
            cmd = new SqlCommand(select, con);
            try
            {
                return cmd.ExecuteReader();
            }
            catch (SqlException)
            {
                return null;
            }
        }

        internal static void ThucHienCmd_Backup()
        {
            cmd = new SqlCommand(strBackup, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!");
                MessageBox.Show("" + se.Message);
            }
        }

        public static string ChinhSuaScript(string filePath)
        {
            StringBuilder sql = new StringBuilder();
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                bool demCreateDb = false; // Tạo biến kiểm tra Lệnh CREATE DATABASE
                while ((line = file.ReadLine()) != null)
                {
                    // replace GO with semi-colon
                    if (line == "GO")
                    {
                        if (line.IndexOf("CREATE DATABASE") > -1)  // Kiểm Tra GO sau câu lệnh SQL
                            demCreateDb = true;
                        if (!demCreateDb)
                        {
                            sql.Append(";");
                        }
                        else
                        {
                            demCreateDb = false;
                        }
                    }
                    else
                        sql.AppendFormat(" {0} ", line);
                }
            }
            return sql.ToString();
        }

        internal static void ThucHienInsertSqlParameter(string sqlQuery, string prName, float parameter)
        {
            cmd = new SqlCommand(sqlQuery, con);
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = prName;
            sqlParameter.Value = parameter;
            cmd.Parameters.Add(sqlParameter);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!");
                MessageBox.Show("" + se.Message);
            }
        }
        
        internal static void ThucHienInserPDFFile(string sqlQuery, string prName, byte[] contents)
        {
            cmd = new SqlCommand(sqlQuery, con);
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = prName;
            sqlParameter.Value = contents;
            cmd.Parameters.Add(sqlParameter);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!");
                MessageBox.Show("" + se.Message);
            }
        }
        internal static void LuuHoaDonPDFVaoDB(string localHoaDon)
        {
            string nameFile = System.IO.Path.GetFileNameWithoutExtension(localHoaDon);
            if (nameFile.Equals("View") || nameFile.Equals("print_rotation")) return;
            try
            {
                FileStream fStream = File.OpenRead(localHoaDon);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                fStream.Close();
                DataConn.ThucHienInserPDFFile("INSERT INTO SavePDFTable values('" + nameFile + "',@data)", "@data", contents);
            }
            catch (Exception)
            {
                MessageBox.Show("Không Lưu Được File PDF Vao Database");
                throw;
            }
        }
        internal static void XemLaiHoaDonTheoMaHD(string MaHD)
        {
            string ToSaveFileTo = folderLuuHoaDon + "View.pdf";
            if (System.IO.File.Exists(ToSaveFileTo))
            {
                try
                {
                    System.IO.File.Delete(ToSaveFileTo);
                }
                catch
                {
                    MessageBox.Show("Tập Tin PDF Đã Có Và Đang Được Sử Dụng ! \nTắt Tập Tin Để Tạo Lại.");
                    return;
                }
            }

            using (SqlCommand cmd = new SqlCommand("Select PDFFile from SavePDFTable  where [MaHD]='" + MaHD + "' ", con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        byte[] fileData = (byte[])dr.GetValue(0);

                        using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                        {
                            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                            {
                                bw.Write(fileData);
                                bw.Close();
                            }
                        }
                    }
                    dr.Close();
                }
            }
            System.Diagnostics.Process.Start(@"" + ToSaveFileTo);
        }

        internal static string LayNoCuTheoMaHoaDon(string MaHD)
        {
            string ToSaveFileTo = folderLuuHoaDon + "View.pdf";
            if (System.IO.File.Exists(ToSaveFileTo))
            {
                try
                {
                    System.IO.File.Delete(ToSaveFileTo);
                }
                catch
                {
                    MessageBox.Show("Tập Tin PDF Đã Có Và Đang Được Sử Dụng ! \nTắt Tập Tin Để Tạo Lại.");
                    return "";
                }
            }
            using (SqlCommand cmd = new SqlCommand("Select PDFFile from SavePDFTable  where [MaHD]='" + MaHD + "' ", con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        byte[] fileData = (byte[])dr.GetValue(0);

                        using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                        {
                            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                            {
                                bw.Write(fileData);
                                bw.Close();
                            }
                        }
                    }
                    dr.Close();
                }
            }
            return LayNoCuTuFilePDF(ToSaveFileTo);
        }

        private static string LayNoCuTuFilePDF(string strFile)
        {
            try
            {
                PdfReader reader = new PdfReader(strFile);
                int intPageNum = reader.NumberOfPages;
                string[] words;
                string line;
                string textNoCu = "";
                int vitri;

                for (int i = 1; i <= intPageNum; i++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                    words = text.Split('\n');
                    for (int j = 0, len = words.Length; j < len; j++)
                    {
                        line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                        if (line.Contains("Nợ"))
                        {
                            vitri = line.IndexOf(":");
                            string strNo = line.Substring(vitri + 1).Trim();
                            textNoCu = (strNo.Length <= 0 ? "0" : strNo.Replace(".", "")); ; 
                        }
                        else
                        if (line.Contains("Trả"))
                        {
                            vitri = line.IndexOf(":");
                            string strTra = line.Substring(vitri + 1).Trim();
                            textNoCu += "-" + (strTra.Length <= 0 ? "0": strTra.Replace(".", ""));
                        }
                        else
                        if (line.Contains("Còn"))
                        {
                            vitri = line.IndexOf(":");
                            string strCon = line.Substring(vitri + 1).Trim();
                            textNoCu += "-" + (strCon.Length <= 0 ? "0" : strCon.Replace(".",""));
                        }
                    }
                }
                return textNoCu;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool KiemTraFilePDFTonTai(string strMaHoaDon)
        {
            // Kiểm Tra File PDF Tôm Tại
            string selectHD = "SELECT * FROM SavePDFTable WHERE MaHD = '" + strMaHoaDon + "'";
            DataSet dsHoaDon = DataConn.GrdSource(selectHD);
            if (dsHoaDon.Tables[0].Rows.Count > 0) return true;
            return false;
        }
        internal static void XoaHoaDonPDFTrongDBTheoMa(string strMaHD)
        {
            string sqlDelete = "DELETE FROM SavePDFTable WHERE MaHD = '" + strMaHD + "'";
            ThucHienCmd(sqlDelete);
        }
        internal static void XoaAllHoaDonXuatNull()
        {
            string sqlQuery = "SELECT MaHD FROM tblHoaDonXuat WHERE NOT EXISTS (SELECT MaHD FROM tblChiTietHDX WHERE " +
                     "tblHoaDonXuat.MaHD = tblChiTietHDX.MaHD)";  // Có Trong Hóa Đơn Mà Không Có Chi Tiết. (HĐ Ảo)
            DataSet dsMaHang = DataConn.GrdSource(sqlQuery);
            foreach (DataRow row in dsMaHang.Tables[0].Rows)
            {
                string deleteHDX = "DELETE FROM tblHoaDonXuat WHERE MaHD ='" + row["MaHD"] + "'";
                ThucHienCmd(deleteHDX);
                string sqlDeleteThuChi = "DELETE FROM tblThuChi WHERE MaHD= '" + row["MaHD"] + "'";
                ThucHienCmd(sqlDeleteThuChi);
                XoaHoaDonPDFTrongDBTheoMa(row["MaHD"].ToString());
            }
        }

        public static float LayTienTrongNhaMoiNhat()
        {
            string sqlSelect = "SELECT TOP(1) TienTrongNha FROM tblThuChi ORDER BY Ngay DESC,Id DESC";
            return Lay1GiaFloat_ExecuteScalar(sqlSelect);
        }

        public static int LayIdThuChiMoiNhat()
        {
            string sqlSelect = "SELECT TOP(1) Id FROM tblThuChi ORDER BY Ngay DESC,Id DESC";
            return Lay1GiaTriSoDung_ExecuteScalar(sqlSelect);
        }

    }
    }
