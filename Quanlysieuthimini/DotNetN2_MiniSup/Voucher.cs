using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetN2_MiniSup
{
   
    internal class Voucher
    {
        Ketnoi Ketnoi;
        public Voucher()
        {
            Ketnoi = new Ketnoi();
        }

        public DataTable GetAllVoucher()
        {
            string sql = "SELECT * FROM Voucher";
            return Ketnoi.ReadData(sql);
        }
        //Thêm
        public void ThemVoucher(string maVoucher, string giaTri, DateTime ngayHetHan)
        {
            string sql = "Insert into Voucher(MaVoucher,GiaTri,NgayHetHan) Values(@maVoucher,@giaTri,@ngayHetHan) ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maVoucher",maVoucher),
                new SqlParameter("@giaTri",giaTri),
                new SqlParameter("@ngayHetHan",ngayHetHan),
            };
            Ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void DeleteVoucher(string maVoucher)
        {
            string sql = "Delete from Voucher where MaVoucher = @maVoucher";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maVoucher",maVoucher),
            };
            Ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public void UpdateVoucher(string maVoucher, string giaTri,DateTime ngayHetHan)
        {
            string sql = "Update Voucher set GiaTri = @giaTri,NgayHetHan =@ngayHetHan where  MaVoucher = @maVoucher ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maVoucher",maVoucher),
                new SqlParameter("@giaTri",giaTri),
                new SqlParameter("@ngayHetHan",ngayHetHan),
            };
            Ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }
        public DataTable SearchVoucher(string maVoucher)
        {
            string sql = "SELECT * FROM Voucher where MaVoucher = @maVoucher";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@maVoucher",maVoucher) };
            return Ketnoi.SearchData(sql, sqlParameters);
        }

    }
}