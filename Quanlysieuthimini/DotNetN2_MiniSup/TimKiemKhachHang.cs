    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DotNetN2_MiniSup
    {
        internal class TimKiemKhachHang
        {
            Ketnoi ketNoi;

            public TimKiemKhachHang()
            {
                ketNoi = new Ketnoi();
            }

        public DataTable TimKiem(string tuKhoa, string loaiTimKiem)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                throw new Exception("Vui lòng nhập từ khóa tìm kiếm.");
            }

            if (string.IsNullOrWhiteSpace(loaiTimKiem))
            {
                throw new Exception("Vui lòng chọn loại tìm kiếm.");
            }

            string sql = "";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@tuKhoa", "%" + tuKhoa + "%")
            };

            switch (loaiTimKiem)
            {
                case "Mã Khách Hàng":
                    sql = "SELECT * FROM KhachHang WHERE MaKhachHang LIKE @tuKhoa";
                    break;
                case "Tên":
                    sql = "SELECT * FROM KhachHang WHERE TenKhachHang LIKE @tuKhoa";
                    break;
                case "Số Điện Thoại":
                    sql = "SELECT * FROM KhachHang WHERE SoDienThoai LIKE @tuKhoa";
                    break;
                case "Địa Chỉ":
                    sql = "SELECT * FROM KhachHang WHERE DiaChi LIKE @tuKhoa";
                    break;
                default:
                    throw new Exception("Tiêu chí tìm kiếm không hợp lệ. Vui lòng chọn 'Mã Khách Hàng', 'Tên', 'Số Điện Thoại' hoặc 'Địa Chỉ'.");
            }
            return ketNoi.SearchData(sql, sqlParameters);
        }
    }
    }
