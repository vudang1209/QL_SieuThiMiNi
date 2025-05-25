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
    internal class Khachhang
    {
        Ketnoi ketnoi;
        public Khachhang() {
            ketnoi = new Ketnoi();
        }
        public DataTable GetAllKH()
        {
            string sql = "SELECT * FROM KhachHang";
            return ketnoi.ReadData(sql);
        }
        //Thêm
        public void ThemKH(string maKhachHang, string tenKhachHang, string soDienThoai, string email, string diaChi)
        {
            string sql = "Insert into KhachHang(MaKhachHang,TenKhachHang,SoDienThoai,Email,DiaChi) Values(@maKhachHang,@tenKhachHang,@soDienThoai,@email,@diaChi) ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maKhachHang",maKhachHang),
                new SqlParameter("@tenKhachHang",tenKhachHang),
                new SqlParameter("@soDienThoai",soDienThoai),
                new SqlParameter("@email",email),
                new SqlParameter("@diaChi",diaChi),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void DeleteKH(string maKhachHang)
        {
            string sql = "Delete from KhachHang where MaKhachHang = @maKhachHang";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maKhachHang",maKhachHang),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void UpdateKH(string maKhachHang, string tenKhachHang, string soDienThoai, string email, string diaChi)
        {
            string sql = "Update KhachHang " +
                "set TenKhachHang = @tenKhachHang,SoDienThoai = @soDienThoai,Email = @email ,DiaChi= @diaChi where  MaKhachHang = @MaKhachHang  ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maKhachHang",maKhachHang),
                new SqlParameter("@tenKhachHang",tenKhachHang),
                new SqlParameter("@soDienThoai",soDienThoai),
                new SqlParameter("@email",email),
                new SqlParameter("@diaChi",diaChi),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public DataTable SearchKH(string maKhachHang)
        {
            string sql = "SELECT * FROM KhachHang where MaKhachHang = @maKhachHang";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@maKhachHang",maKhachHang) };
            return ketnoi.SearchData(sql, sqlParameters);
        }
    }
}
