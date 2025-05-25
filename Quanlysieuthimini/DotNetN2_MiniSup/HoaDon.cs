using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetN2_MiniSup
{
    internal class HoaDon
    {
        private Ketnoi ketnoi;

        public HoaDon()
        {
            ketnoi = new Ketnoi();
        }

        public DataTable GetAllHoaDon()
        {
            string sql = "SELECT * FROM HoaDon";
            return ketnoi.ReadData(sql);
        }

        public DataTable GetAllChiTietHoaDon()
        {
            string sql = "SELECT * FROM ChiTietHoaDon";
            return ketnoi.ReadData(sql);
        }

        public DataTable GetAllVoucher()
        {
            string sql = "SELECT MaVoucher FROM Voucher";
            return ketnoi.ReadData(sql);
        }

        public DataTable GetAllMaKhachHang()
        {
            string sql = "SELECT MaKhachHang FROM KhachHang";
            return ketnoi.ReadData(sql);
        }

        public DataTable GetAllMaHoaDon()
        {
            string sql = "SELECT MaHoaDon FROM HoaDon";
            return ketnoi.ReadData(sql);
        }

        public DataTable GetAllMaSanPham()
        {
            string sql = "SELECT MaSanPham FROM SanPham";
            return ketnoi.ReadData(sql);
        }

        public void ThemHoaDon(string mahd, string makh, DateTime ngaylap)
        {
            string sql = "Insert into HoaDon(MaHoaDon,MaKhachHang,NgayLap) Values(@mahd,@makh,@ngaylap)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@mahd",mahd),
                new SqlParameter("@makh",makh),
                new SqlParameter("@ngaylap",ngaylap),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }

        public bool KiemTraMaTonTai(string tableName, string columnName, string ma)
        {
            Ketnoi ketnoi = new Ketnoi();
            string sql = $"SELECT COUNT(*) AS SoLuong FROM {tableName} WHERE {columnName} = @ma";
            SqlParameter[] sqlParameters = { new SqlParameter("@ma", ma) };

            DataTable dt = ketnoi.SearchData(sql, sqlParameters);

            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
                return count > 0;
            }
            return false;
        }

        public void UpdateHoaDon(string mahd, string makh, DateTime ngaylap, string tongtien)
        {
            string sql = "Update HoaDon " +
                "set MaKhachHang = @makh, NgayLap = @ngaylap,TongTien = @tongtien where MaHoaDon = @mahd";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mahd",mahd),
                new SqlParameter("@makh",makh),
                new SqlParameter("@ngaylap",ngaylap),
                new SqlParameter("@tongtien",tongtien)
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }

        public void DeleteHoaDon(string mahd)
        {
            string sql = "Delete from HoaDon where MaHoaDon = @mahd";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mahd",mahd),
            };
            string sql1 = "Delete from ChiTietHoaDon where MaHoaDon = @mahd";
            SqlParameter[] sqlParameters1 = new SqlParameter[] {
                new SqlParameter("@mahd",mahd),
            };
            ketnoi.CreateUpdateDelete(sql1, sqlParameters1);
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }

        public DataTable SearchChiTietHoaDon(string mahd)
        {
            string sql = "SELECT * FROM ChiTietHoaDon where MaHoaDon = @mahd";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@mahd",mahd)};
            return ketnoi.SearchData(sql, sqlParameters);
        }

        public DateTime NgayHetHan(string mavoucher)
        {
            string sql = "SELECT NgayHetHan FROM Voucher WHERE MaVoucher = @mavoucher";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mavoucher", mavoucher)
            };

            DataTable dt = ketnoi.SearchData(sql, sqlParameters);

 
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDateTime(dt.Rows[0]["NgayHetHan"]);
            }
            else
            {
                throw new Exception("Voucher không tồn tại.");
            }
        }


        // chi tiet hoa don----------------------------------------------------------------

        public void ThemChiTietHoaDon(string macthd, string mahd, string msp, string sl, string dg)
        {
            string sql = "Insert into ChiTietHoaDon(MaChiTietHoaDon,MaHoaDon,MaSanPham,SoLuong,DonGia) Values(@macthd,@mahd,@msp,@sl,@dg)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@macthd",macthd),
                new SqlParameter("@mahd",mahd),
                new SqlParameter("@msp",msp),
                new SqlParameter("@sl",sl),
                new SqlParameter("@dg",dg)
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }

        public void UpdateChiTietHoaDon(string macthd, string mahd, string msp, string sl, string dg)
        {
            string sql = "Update ChiTietHoaDon " +
                "set MaHoaDon = @mahd, MaSanPham = @msp, SoLuong = @sl,DonGia = @dg where MaChiTietHoaDon = @macthd";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@macthd",macthd),
                new SqlParameter("@mahd",mahd),
                new SqlParameter("@msp",msp),
                new SqlParameter("@sl",sl),
                new SqlParameter("@dg",dg)
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }

        public void DeleteChiTietHoaDon(string macthd)
        {
            string sql = "Delete from ChiTietHoaDon where MaChiTietHoaDon = @macthd";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@macthd",macthd),
            };
            ketnoi.CreateUpdateDelete(sql, sqlParameters);
        }

        public void TongTienHoaDon(string macthd, string mahd)
        {
            // Bước 1: Lấy thông tin SoLuong và DonGia từ bảng ChiTietHoaDon
            string sqlGetDetails = @"
                SELECT SoLuong, DonGia
                FROM ChiTietHoaDon
                WHERE MaChiTietHoaDon = @macthd
            ";

            SqlParameter[] sqlGetDetailsParameters = new SqlParameter[]
            {
                new SqlParameter("@macthd", macthd),
            };

            DataTable dt = ketnoi.SearchData(sqlGetDetails, sqlGetDetailsParameters);

            if (dt.Rows.Count > 0)
            {
                int soluong = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
                decimal dongia = Convert.ToDecimal(dt.Rows[0]["DonGia"]);

                // Bước 2: Cập nhật lại tổng tiền trong bảng HoaDon
                string sqlUpdate = @"
                    UPDATE HoaDon
                    SET TongTien = (
                        SELECT SUM(SoLuong * DonGia)
                        FROM ChiTietHoaDon
                        WHERE MaHoaDon = @mahd
                    )
                    WHERE MaHoaDon = @mahd
                ";

                SqlParameter[] sqlUpdateParameters = new SqlParameter[] {
            new SqlParameter("@mahd", mahd),
        };

                ketnoi.CreateUpdateDelete(sqlUpdate, sqlUpdateParameters);
            }
            else
            {
                // Nếu không tìm thấy ChiTietHoaDon với MaChiTietHoaDon tương ứng
                Console.WriteLine("Không tìm thấy ChiTiết Hóa Đơn với mã: " + macthd);
            }
        }

        public decimal TongTienSauVoucher(string mavoucher, string mahd)
        {
            decimal tongTienSauVoucher = 0;

            string sql = @"
        SELECT
            h.TongTien - COALESCE(v.GiaTri, 0) AS TongTienSauVoucher
        FROM
            HoaDon h
        LEFT JOIN
            Voucher v ON v.MaVoucher = @mavoucher
        WHERE
            h.MaHoaDon = @mahd;
    ";

            SqlParameter[] sqlParameters = new SqlParameter[] {
        new SqlParameter("@mavoucher", mavoucher),
        new SqlParameter("@mahd", mahd),
    };

            try
            {
                DataTable dt = ketnoi.SearchData(sql, sqlParameters);

                if (dt.Rows.Count > 0)
                {
                    // Truy xuất giá trị sau khi tính toán
                    tongTienSauVoucher = Convert.ToDecimal(dt.Rows[0]["TongTienSauVoucher"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return tongTienSauVoucher;
        }
    }
}