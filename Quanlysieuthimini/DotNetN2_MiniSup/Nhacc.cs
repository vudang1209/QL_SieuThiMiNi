using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DotNetN2_MiniSup
{
    internal class Nhacc
    {
        Ketnoi ketnoi;
        public Nhacc()
        {
            ketnoi = new Ketnoi();
        }
        // Lấy dữ liệu bảng nhà cung cấp
        public DataTable GetAllNhaCC()
        {
            string sql = "SELECT * FROM NhaCungCap";
            return ketnoi.ReadData(sql);
        }
        //Thêm
        public void ThemNhaCC(string maNhaCungCap,string tenNhaCungCap,string soDienThoai,string email,string diaChi)
        {
            string sql = "Insert into NhaCungCap(MaNhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email) Values(@maNhaCungCap,@tenNhaCungCap,@diaChi,@soDienThoai,@email) ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maNhaCungCap",maNhaCungCap),
                new SqlParameter("@tenNhaCungCap",tenNhaCungCap),
                new SqlParameter("@diaChi",diaChi),
                new SqlParameter("@soDienThoai",soDienThoai),
                new SqlParameter("@email",email)
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void DeleteNhaCC(string maNhaCungCap)
        {
            string sql = "Delete from NhaCungCap where MaNhaCungCap = @maNhaCungCap";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maNhaCungCap",maNhaCungCap),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void UpdateNhaCC(string maNhaCungCap, string tenNhaCungCap, string soDienThoai, string email, string diaChi)
        {
            string sql = "Update NhaCungCap " +
                "set TenNhaCungCap = @tenNhaCungCap,SoDienThoai = @soDienThoai,Email = @email ,DiaChi= @diaChi where  MaNhaCungCap = @maNhaCungCap  ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maNhaCungCap",maNhaCungCap),
                new SqlParameter("@tenNhaCungCap",tenNhaCungCap),
                new SqlParameter("@soDienThoai",soDienThoai),
                new SqlParameter("@email",email),
                new SqlParameter("@diaChi",diaChi),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public DataTable SearchNhaCC(string maNhaCungCap)
        {
            string sql = "SELECT * FROM NhaCungCap where MaNhaCungCap = @maNhaCungCap";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@maNhaCungCap",maNhaCungCap) };
            return ketnoi.SearchData(sql, sqlParameters);
        }
    }
}
