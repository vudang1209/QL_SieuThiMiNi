using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetN2_MiniSup
{
    internal class Danhmuc
    {
        Ketnoi Ketnoi;
    public Danhmuc() {
            Ketnoi = new Ketnoi();
    }
        public DataTable GetAllDanhMuc()
        {
            string sql = "SELECT * FROM DanhMucSanPham";
            return Ketnoi.ReadData(sql);
        }
        //Thêm
        public void ThemDM(string maDanhMuc, string tenDanhMuc )
        {
            string sql = "Insert into DanhMucSanPham(MaDanhMuc,TenDanhMuc) Values(@maDanhMuc,@tenDanhMuc) ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maDanhMuc",maDanhMuc),
                new SqlParameter("@tenDanhMuc",tenDanhMuc),
            };
            Ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void DeleteDM(string maDanhMuc)
        {
            string sql = "Delete from DanhMucSanPham where MaDanhMuc = @maDanhMuc";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maDanhMuc",maDanhMuc),
            };
            Ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void UpdateDM(string maDanhMuc, string tenDanhMuc)
        {
            string sql = "Update DanhMucSanPham set TenDanhMuc = @tenDanhMuc where  MaDanhMuc = @maDanhMuc  ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maDanhMuc",maDanhMuc),
                new SqlParameter("@tenDanhMuc",tenDanhMuc),
            };
             Ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public DataTable SearchMDM(string maDanhMuc)
        {
            string sql = "SELECT * FROM DanhMucSanPham where MaDanhMuc = @maDanhMuc";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@maDanhMuc",maDanhMuc) };
            return Ketnoi.SearchData(sql, sqlParameters);
        }
        public DataTable SearchTDM(string tenDanhMuc)
        {
            string sql = "SELECT * FROM DanhMucSanPham where TenDanhMuc = @tenDanhMuc";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@tenDanhMuc",tenDanhMuc) };
            return Ketnoi.SearchData(sql, sqlParameters);
        }

    }
}
