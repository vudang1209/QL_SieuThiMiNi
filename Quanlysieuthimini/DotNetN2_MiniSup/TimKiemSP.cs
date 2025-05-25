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
    internal class TimKiemSP
    {
        private Ketnoi ketnoi;

        public TimKiemSP()
        {
            ketnoi = new Ketnoi();
        }

        public DataTable LayDanhMuc()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMucSanPham";
            return ketnoi.ReadData(sql);
        }

        public DataTable LaySanPhamTheoDanhMuc(string maDanhMuc)
        {
            string sql = "SELECT MaSanPham, TenSanPham, Gia, SoLuong FROM SanPham WHERE MaDanhMuc = @maDanhMuc";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@maDanhMuc", maDanhMuc)
            };
            return ketnoi.SearchData(sql, parameters);
        }

        public void TimKiemTheoMasp(string maSanPham, DataGridView dataGridView)
        {
            string sql = "SELECT * FROM SanPham WHERE MaSanPham = @MaSanPham";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaSanPham", maSanPham)
            };
            LoadDataToGridView(sql, parameters, dataGridView);
        }

        public void TimKiemTheoTen(string tenSanPham, DataGridView dataGridView)
        {
            string sql = "SELECT * FROM SanPham WHERE TenSanPham LIKE @TenSanPham";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TenSanPham", "%" + tenSanPham + "%")
            };
            LoadDataToGridView(sql, parameters, dataGridView);
        }

        public void TimKiemTheoHanSuDung(bool sapHetHan, DateTime ngayKeTiep, DataGridView dataGridView)
        {
            string sql = sapHetHan ?
                "SELECT * FROM SanPham WHERE HanSuDung <= @NgayKeTiep AND HanSuDung >= @NgayHienTai" :
                "SELECT * FROM SanPham WHERE HanSuDung < @NgayHienTai";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@NgayHienTai", DateTime.Today),
                new SqlParameter("@NgayKeTiep", ngayKeTiep)
            };

            LoadDataToGridView(sql, parameters, dataGridView);
        }

        private void LoadDataToGridView(string sql, SqlParameter[] parameters, DataGridView dataGridView)
        {
            DataTable dt = ketnoi.SearchData(sql, parameters);
            dataGridView.DataSource = dt;
        }
    }
}
