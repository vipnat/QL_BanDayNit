using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QL_BanDayNit
{
    class DataConn
    {
        private static string source;
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataAdapter da;
        private static DataSet ds;
        // Tên Database trong CSDL
        private static string strTenDB = "BanHang";
        // Add Tên Computer của bạn ở đây.
        private static string strPC_Name = Environment.MachineName;
        //private static string strPC_Name = "ANHTUAN-PC";
        //private static string strPC_Name = "MINHTU-PC";
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
    }
}
