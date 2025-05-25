using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DotNetN2_MiniSup
{
    public partial class FrmHoaDon : Form
    {
        private HoaDon hoadon = new HoaDon();
        public FrmHoaDon()
        {
            InitializeComponent();
            dgv_hd.DataSource = hoadon.GetAllHoaDon();
            dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
            LoadKhachHangToComboBox();
            LoadMaHoaDonToComboBox();
            LoadMaSanPhamToComboBox();
            LoadVoucherToComboBox();
        }

        public void cleartxt()
        {
            txt_mhd.Text = string.Empty;
            cbx_kh.Text = string.Empty;
            dt_ngaylap.Value = DateTime.Now;
            txt_tongtien.Text = string.Empty;
        }

        public void cleartxt2()
        {
            txt_macthd.Text = string.Empty;
            cbx_mahd.Text = string.Empty;
            cbx_msp.Text = string.Empty;
            txt_cthdsl.Text = string.Empty;
            txt_cthddg.Text = string.Empty;
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            string mahd = txt_mhd.Text.ToUpper();
            string makh = cbx_kh.Text;
            DateTime ngaylap = dt_ngaylap.Value;

            if (string.IsNullOrWhiteSpace(mahd) || string.IsNullOrWhiteSpace(makh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của phiếu nhập trước khi thêm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (hoadon.KiemTraMaTonTai("HoaDon", "MaHoaDon", mahd))
            {
                MessageBox.Show("Mã hoá đơn đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                hoadon.ThemHoaDon(mahd, makh, ngaylap);
                dgv_hd.DataSource = null;
                dgv_hd.Rows.Clear();
                dgv_hd.DataSource = hoadon.GetAllHoaDon();
                cleartxt();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadMaHoaDonToComboBox();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string mahd = txt_mhd.Text;
            string makh = cbx_kh.Text;
            DateTime ngaylap = dt_ngaylap.Value;
            string tongtien = txt_tongtien.Text;

            if (string.IsNullOrWhiteSpace(mahd) || string.IsNullOrWhiteSpace(makh) || string.IsNullOrWhiteSpace(tongtien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của hoá đơn trước khi thay đổi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    hoadon.UpdateHoaDon(mahd, makh, ngaylap, tongtien);
                    dgv_hd.DataSource = null;
                    dgv_hd.Rows.Clear();
                    dgv_hd.DataSource = hoadon.GetAllHoaDon();
                    cleartxt();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string mahd = txt_mhd.Text;
            if (string.IsNullOrWhiteSpace(mahd))
            {
                MessageBox.Show("Vui lòng chọn mã hoá đơn trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    hoadon.DeleteHoaDon(mahd);
                    dgv_hd.DataSource = null;
                    cleartxt();
                    dgv_hd.DataSource = hoadon.GetAllHoaDon();
                    dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btn_hienthihd_Click(object sender, EventArgs e)
        {
            dgv_hd.DataSource = null;
            dgv_hd.Rows.Clear();
            dgv_hd.DataSource = hoadon.GetAllHoaDon();
            cleartxt();
        }

        private void btn_hienthicthd_Click(object sender, EventArgs e)
        {
            dgv_cthd.DataSource = null;
            dgv_cthd.Rows.Clear();
            dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
            cleartxt2();
        }

        //Day du lieu vao combobox----------------------------------------------------------------

        private void LoadKhachHangToComboBox()
        {
            // Lấy danh sách mã khach hang
            DataTable dtkh = hoadon.GetAllMaKhachHang();

            cbx_kh.DataSource = dtkh;
            cbx_kh.DisplayMember = "MaKhachHang"; // Cột hiển thị
            cbx_kh.ValueMember = "MaKhachHang"; // Giá trị mã Khach hang

            cbx_kh.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }

        private void LoadMaHoaDonToComboBox()
        {
            // Lấy danh sách ma hoa don
            DataTable dthd = hoadon.GetAllMaHoaDon();

            cbx_mahd.DataSource = dthd;
            cbx_mahd.DisplayMember = "MaHoaDon"; // Cột hiển thị
            cbx_mahd.ValueMember = "MaHoaDon"; // Giá trị mã Khach hang

            cbx_mahd.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }
        private void LoadVoucherToComboBox()
        {
            // Lấy danh sách ma san pham
            DataTable dtvc = hoadon.GetAllVoucher();

            // Tạo dòng trống
            //DataRow dr = dtvc.NewRow();
            //dr["MaVoucher"] = ""; // Cột chứa mã sản phẩm
            //dtvc.Rows.InsertAt(dr, 0); // Thêm dòng trống vào đầu danh sách

            cbx_voucher.DataSource = dtvc;
            cbx_voucher.DisplayMember = "MaVoucher"; // Cột hiển thị
            cbx_voucher.ValueMember = "MaVoucher"; // Giá trị mã sản phẩm
        }
        private void LoadMaSanPhamToComboBox()
        {
            // Lấy danh sách ma san pham
            DataTable dtsp = hoadon.GetAllMaSanPham();

            cbx_msp.DataSource = dtsp;
            
            cbx_msp.DisplayMember = "MaSanPham"; // Cột hiển thị
            cbx_msp.ValueMember = "MaSanPham"; // Giá trị mã Khach hang
            cbx_msp.SelectedIndex = cbx_voucher.Items.Count-1; // Không chọn mục nào ban đầu
        }

        // cell click-----------------------------------------------------

        private void dgv_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng không click vào header row
                if (e.RowIndex >= 0)
                {
                    // Lấy mã phiếu nhập từ cột đầu tiên của dòng được click
                    string mahd = dgv_hd.Rows[e.RowIndex].Cells[0].Value.ToString();

                    // Đổ dữ liệu vào các textbox từ các cột trong dòng
                    txt_mhd.Text = dgv_hd.Rows[e.RowIndex].Cells[0].Value.ToString();
                    cbx_kh.Text = dgv_hd.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dt_ngaylap.Text = dgv_hd.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txt_tongtien.Text = dgv_hd.Rows[e.RowIndex].Cells[3].Value.ToString();

                    // Lấy chi tiết phiếu nhập từ mã phiếu nhập đã chọn
                    DataTable dtChiTiet = hoadon.SearchChiTietHoaDon(mahd);

                    // Hiển thị hoá đơn vào DataGridView khác

                    dgv_cthd.DataSource = dtChiTiet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgv_cthd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_macthd.Text = dgv_cthd.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbx_mahd.Text = dgv_cthd.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbx_msp.Text = dgv_cthd.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_cthdsl.Text = dgv_cthd.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_cthddg.Text = dgv_cthd.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btn_themcthd_Click(object sender, EventArgs e)
        {
            string macthd = txt_macthd.Text.ToUpper();
            string mahd = cbx_mahd.Text;
            string msp = cbx_msp.Text;
            string sl = txt_cthdsl.Text;
            string dg = txt_cthddg.Text;

            if (string.IsNullOrWhiteSpace(macthd) || string.IsNullOrWhiteSpace(mahd) || string.IsNullOrWhiteSpace(msp) || string.IsNullOrWhiteSpace(dg))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết hoá đơn trước khi thêm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (hoadon.KiemTraMaTonTai("ChiTietHoaDon", "MaChiTietHoaDon", macthd))
            {
                MessageBox.Show("Mã chi tiết hoá đơn đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                hoadon.ThemChiTietHoaDon(macthd, mahd,msp, sl, dg);
                hoadon.TongTienHoaDon(macthd, mahd);
                dgv_cthd.DataSource = null;
                dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
                cleartxt();
                dgv_hd.DataSource = hoadon.GetAllHoaDon();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
                        
        }

        private void btn_suacthd_Click(object sender, EventArgs e)
        {
            string macthd = txt_macthd.Text;
            string mahd = cbx_mahd.Text;
            string msp = cbx_msp.Text;
            string sl = txt_cthdsl.Text;
            string dg = txt_cthddg.Text;

            if (string.IsNullOrWhiteSpace(macthd) || string.IsNullOrWhiteSpace(mahd) || string.IsNullOrWhiteSpace(msp) || string.IsNullOrWhiteSpace(dg))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của Chi tiết hoá đơn trước khi thay đổi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    hoadon.UpdateChiTietHoaDon(macthd, mahd,msp, sl, dg);
                    hoadon.TongTienHoaDon(macthd, mahd);
                    dgv_cthd.DataSource = null;
                    dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
                    cleartxt();
                    dgv_hd.DataSource = hoadon.GetAllHoaDon();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_xoacthd_Click(object sender, EventArgs e)
        {
            string mcthd = txt_macthd.Text;
            string mahd = cbx_mahd.Text;
            if (string.IsNullOrWhiteSpace(mcthd))
            {
                MessageBox.Show("Vui lòng chọn chi tiết hoá đơn trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    hoadon.DeleteChiTietHoaDon(mcthd);
                    hoadon.TongTienHoaDon(mcthd, mahd);
                    dgv_cthd.DataSource = null;
                    cleartxt2();
                    dgv_cthd.DataSource = hoadon.GetAllChiTietHoaDon();
                    dgv_hd.DataSource = hoadon.GetAllHoaDon();
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // xuat Excel nee-----------------------------------------------------------------
        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                // Tạo đối tượng Excel nè
                Excel.Application excelApp = new Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);
                excelApp.Visible = true;

                // lấy tiêu đề
                for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }

                // Xuất dữ liệu từ Dgv sang Excel
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btn_xuatEx_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_hd);
        }

        private void cbx_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string mahd = txt_mhd.Text; // Mã hóa đơn (nếu cần sử dụng)
            //string voucher = cbx_voucher.Text; // Voucher được chọn

            //try
            //{
            //    // Lấy ngày hết hạn của voucher
            //    DateTime ngayHetHan = hoadon.NgayHetHan(voucher);
            //    DateTime homlay = DateTime.Now;

            //    // Kiểm tra nếu voucher đã hết hạn
            //    if (cbx_voucher.SelectedIndex != 0)  // Kiểm tra nếu đã chọn voucher
            //    {
            //        if (ngayHetHan < homlay)  // So sánh ngày hết hạn với ngày hiện tại
            //        {
            //            MessageBox.Show("Voucher này đã hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string voucher = cbx_voucher.SelectedValue.ToString(); 
            string mahd = txt_mhd.Text;
            DateTime homlay = DateTime.Now;
            DateTime ngayhethanVC = new DateTime();
            ngayhethanVC = hoadon.NgayHetHan(voucher);

            if (!string.IsNullOrEmpty(mahd) && !string.IsNullOrEmpty(voucher))
            {
               if(ngayhethanVC >= homlay)
                {
                    decimal tongtien = hoadon.TongTienSauVoucher(voucher, mahd);
                    lb_tongTien.Text = tongtien.ToString();
                }
                else
                {
                    MessageBox.Show("Voucher này đã hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn voucher và nhập mã hóa đơn.");
            }
        }
        

        private void btn_xuatExCTHD_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet workSheet = workBook.Sheets[1];
            excelApp.Visible = true;

            try
            {
                // Xuất dữ liệu từ DataGridView vào Excel
                for (int i = 1; i < dgv_cthd.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dgv_cthd.Columns[i - 1].HeaderText;  // Tiêu đề cột
                }

                // Xuất dữ liệu từ DataGridView
                for (int i = 0; i < dgv_cthd.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_cthd.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = dgv_cthd.Rows[i].Cells[j].Value?.ToString();  // Dữ liệu từng ô
                    }
                }

                // Thêm tổng tiền và voucher vào cuối bảng
                int rowIndex = dgv_cthd.Rows.Count + 2;  // Chỉ số dòng để thêm thông tin
                workSheet.Cells[rowIndex, 1] = "Tổng Tiền:";
                workSheet.Cells[rowIndex, 2] = lb_tongTien.Text;  // Tổng tiền từ Label

                workSheet.Cells[rowIndex + 1, 1] = "Voucher:";
                workSheet.Cells[rowIndex + 1, 2] = cbx_voucher.SelectedValue.ToString();  // Giá trị voucher từ ComboBox

                workSheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
