using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetN2_MiniSup
{
    internal class SanPham
    {
        Ketnoi ketnoi;
        public SanPham()
        {
            ketnoi = new Ketnoi();
        }
        public DataTable GetAllSanPham()
        {
            string sql = "SELECT * FROM SanPham";
            return ketnoi.ReadData(sql);
        }
        public DataTable GetAllMaDanhMuc()
        {
            string sql = "SELECT MaDanhMuc FROM DanhMucSanPham";
            return ketnoi.ReadData(sql);
        }
        public void ThemSanPham(string maSanPham, string tenSanPham, string maDanhMuc, string Gia, string soLuong, DateTime hanSuDung)
        {
            string sql = "Insert into SanPham(MaSanPham,TenSanPham,MaDanhMuc,Gia,SoLuong,HanSuDung) Values(@maSanPham,@tenSanPham,@maDanhMuc,@Gia,@soLuong,@hanSuDung) ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maSanPham",maSanPham),
                new SqlParameter("@tenSanPham",tenSanPham),
                new SqlParameter("@maDanhMuc",maDanhMuc),
                new SqlParameter("@Gia",Gia),
                new SqlParameter("@soLuong",soLuong),
                new SqlParameter("@hanSuDung",hanSuDung)

            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void DeleteSanPham(string maSanPham)
        {
            string sql = "Delete from SanPham where MaSanPham = @maSanPham";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maSanPham",maSanPham),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void UpdateSanPham(string maSanPham, string tenSanPham, string maDanhMuc, string Gia, string soLuong, DateTime hanSuDung)
        {
            string sql = "Update SanPham " +
                "set TenSanPham = @tenSanPham, MaDanhMuc = @maDanhMuc,Gia=@Gia,SoLuong = @soLuong,HanSuDung = @hanSuDung where MaSanPham = @maSanPham  ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                 new SqlParameter("@maSanPham",maSanPham),
                new SqlParameter("@tenSanPham",tenSanPham),
                new SqlParameter("@maDanhMuc",maDanhMuc),
                new SqlParameter("@Gia",Gia),
                new SqlParameter("@soLuong",soLuong),
                new SqlParameter("@hanSuDung",hanSuDung)
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public DataTable SearchSanPham(string maSanPham)
        {
            string sql = "SELECT * FROM SanPham where MaSanPham = @maSanPham";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@maSanPham",maSanPham) };
            return ketnoi.SearchData(sql, sqlParameters);
        }
    }
}
