using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetN2_MiniSup
{
    internal class TimKiemPhieuNhap
    {
        private Ketnoi ketnoi = new Ketnoi();

        public void TimKiemPhieuNhapTheoTieuChi_TextBox(string tieuChi, string giaTri, DataGridView dataGridView)
        {
            string sql = @"
        SELECT 
            pn.MaPhieuNhap, 
            pn.MaNhaCungCap, 
            pn.NgayNhap,  
            sp.TenSanPham, 
            ctpn.SoLuong, 
            pn.TongTien
        FROM 
            PhieuNhap pn 
        JOIN 
            ChiTietPhieuNhap ctpn ON pn.MaPhieuNhap = ctpn.MaPhieuNhap
        JOIN 
            SanPham sp ON ctpn.MaSanPham = sp.MaSanPham 
        WHERE 1 = 1";  // Điều kiện này để giữ cho câu SQL luôn đúng khi không có điều kiện tìm kiếm nào

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            // Thêm các điều kiện tìm kiếm vào câu lệnh SQL nếu có giá trị
            if (!string.IsNullOrEmpty(tieuChi) && !string.IsNullOrEmpty(giaTri))
            {
                switch (tieuChi)
                {
                    case "Mã Phiếu Nhập":
                        sql += " AND pn.MaPhieuNhap = @MaPhieuNhap";
                        sqlParameters.Add(new SqlParameter("@MaPhieuNhap", giaTri));
                        break;
                    case "Mã Nhà Cung Cấp":
                        sql += " AND pn.MaNhaCungCap = @MaNhaCungCap";
                        sqlParameters.Add(new SqlParameter("@MaNhaCungCap", giaTri));
                        break;
                    case "Tên Sản Phẩm":
                        sql += " AND sp.TenSanPham LIKE @TenSanPham";
                        sqlParameters.Add(new SqlParameter("@TenSanPham", "%" + giaTri + "%"));
                        break;
                }
            }

            // Thực hiện truy vấn với câu SQL đã hoàn thành và tham số truyền vào
            DataTable dt = ketnoi.SearchData(sql, sqlParameters.ToArray());
            dataGridView.DataSource = dt;
        }

        public void TimKiemPhieuNhapTheoTieuChi_Ngay(DateTime? ngayNhapTruoc, DateTime? ngayNhapSau, DataGridView dataGridView)
        {
            string sql = @"
        SELECT 
            pn.MaPhieuNhap, 
            pn.MaNhaCungCap, 
            pn.NgayNhap,  
            sp.TenSanPham, 
            ctpn.SoLuong, 
            pn.TongTien
        FROM 
            PhieuNhap pn 
        JOIN 
            ChiTietPhieuNhap ctpn ON pn.MaPhieuNhap = ctpn.MaPhieuNhap
        JOIN 
            SanPham sp ON ctpn.MaSanPham = sp.MaSanPham 
        WHERE 1 = 1";  // Điều kiện này để giữ cho câu SQL luôn đúng khi không có điều kiện tìm kiếm nào

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            // Thêm điều kiện tìm kiếm theo ngày nếu có giá trị
            if (ngayNhapTruoc.HasValue && ngayNhapSau.HasValue)
            {
                sql += " AND pn.NgayNhap BETWEEN @FromDate AND @ToDate";
                sqlParameters.Add(new SqlParameter("@FromDate", ngayNhapTruoc.Value.ToString("yyyy-MM-dd")));
                sqlParameters.Add(new SqlParameter("@ToDate", ngayNhapSau.Value.ToString("yyyy-MM-dd")));
            }

            // Thực hiện truy vấn với câu SQL đã hoàn thành và tham số truyền vào
            DataTable dt = ketnoi.SearchData(sql, sqlParameters.ToArray());
            dataGridView.DataSource = dt;
        }

    }
}
