using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetN2_MiniSup
{
    internal class Ketnoi
    {
        SqlConnection conn;
        private string sql;

        public void openConnection()
        {
            //Chưa sửa
            string ckn = @"Server=DESKTOP-70UH8BO;Database= QuanLyBanHang ;Integrated Security = True";
            conn = new SqlConnection(ckn);
            conn.Open();
        }
        public void closeConnection()
        {
            conn.Close();
        }
        //CRUD
        public DataTable ReadData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            
            return dt;
        }
        
        public void CreateUpdateDelete(string sql, SqlParameter[] sqlParameters = null)
        {
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (sqlParameters != null) cmd.Parameters.AddRange(sqlParameters);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        // Tìm kiếm trên database
        public DataTable SearchData(string sql, SqlParameter[] sqlParameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (sqlParameters != null) cmd.Parameters.AddRange(sqlParameters);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }
    }
}
