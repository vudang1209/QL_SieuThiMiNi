using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace DotNetN2_MiniSup
{
    public partial class FrmPhieuNhap : Form
    {
        private PhieuNhap phieunhap = new PhieuNhap();

        public FrmPhieuNhap()
        {
            InitializeComponent();
            dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
            dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
            LoadNhaCungCapToComboBox();
            LoadMaPhieuNhapToComboBox();
            LoadMaSanPhamToComboBox();
        }

        public void cleartxt()
        {
            txt_mapn.Text = string.Empty;
            cbx_mancc.Text = string.Empty;
            dt_ngaynhap.Value = DateTime.Now;
            txt_tongtien.Text = string.Empty;
        }
        public void cleartxt2()
        {
            txt_mactpn.Text = string.Empty;
            cbx_mapn.Text = string.Empty;
            cbx_msp.Text = string.Empty;
            txt_ctpnsl.Text = string.Empty;
            txt_ctpndg.Text = string.Empty;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            string mapn = txt_mapn.Text.ToUpper();
            string mancc = cbx_mancc.Text;
            DateTime ngaynhap = dt_ngaynhap.Value;

            if (string.IsNullOrWhiteSpace(mapn) || string.IsNullOrWhiteSpace(mancc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của phiếu nhập trước khi thêm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (phieunhap.KiemTraMaTonTai("PhieuNhap", "MaPhieuNhap", mapn))
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                phieunhap.ThemPhieuNhap(mapn, mancc, ngaynhap);
                dgv_pn.DataSource = null;
                dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
                dgv_ctpn.DataSource = null;
                dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                cleartxt();
                LoadMaPhieuNhapToComboBox();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string mapn = txt_mapn.Text;
            string mancc = cbx_mancc.Text;
            DateTime ngaynhap = dt_ngaynhap.Value;
            if (string.IsNullOrWhiteSpace(mapn) || string.IsNullOrWhiteSpace(mancc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của phiếu nhập trước khi thay đổi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    phieunhap.UpdatePhieuNhap(mapn, mancc, ngaynhap);
                    dgv_ctpn.DataSource = null;
                    dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                    dgv_pn.DataSource = null;
                    dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
                    cleartxt();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string mapn = txt_mapn.Text;
            if (string.IsNullOrWhiteSpace(mapn))
            {
                MessageBox.Show("Vui nhập mã phiếu nhập trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    phieunhap.DeletePhieuNhap(mapn);
                    cleartxt();
                    dgv_ctpn.DataSource = null;
                    dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                    dgv_pn.DataSource = null;
                    dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_hienthipn_Click(object sender, EventArgs e)
        {
            dgv_pn.DataSource = null;
            dgv_pn.Rows.Clear();
            dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
            cleartxt();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng không click vào header row
                if (e.RowIndex >= 0)
                {
                    // Lấy mã phiếu nhập từ cột đầu tiên của dòng được click
                    string maPhieuNhap = dgv_pn.Rows[e.RowIndex].Cells[0].Value.ToString();

                    // Đổ dữ liệu vào các textbox từ các cột trong dòng
                    txt_mapn.Text = dgv_pn.Rows[e.RowIndex].Cells[0].Value.ToString();
                    cbx_mancc.Text = dgv_pn.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dt_ngaynhap.Text = dgv_pn.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txt_tongtien.Text = dgv_pn.Rows[e.RowIndex].Cells[3].Value.ToString();

                    // Lấy chi tiết phiếu nhập từ mã phiếu nhập đã chọn
                    DataTable dtChiTiet = phieunhap.SearchPhieuNhap(maPhieuNhap);

                    // Hiển thị chi tiết phiếu nhập vào DataGridView khác (dgv_ctpn)
                    dgv_ctpn.DataSource = dtChiTiet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        
        private void dgv_ctpn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_mactpn.Text = dgv_ctpn.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbx_mapn.Text = dgv_ctpn.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbx_msp.Text = dgv_ctpn.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_ctpnsl.Text = dgv_ctpn.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_ctpndg.Text = dgv_ctpn.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
        // chi tiet phieu nhap--------------------------------------------------------------------------------
        private void btn_hienthictpn_Click(object sender, EventArgs e)
        {
            dgv_ctpn.DataSource = null;
            dgv_ctpn.Rows.Clear();
            dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
            cleartxt2();
        }

        private void btn_themctpn_Click(object sender, EventArgs e)
        {
            string mctpn = txt_mactpn.Text.ToUpper();
            string mapn = cbx_mapn.Text;
            string msp = cbx_msp.Text;
            int sl = int.Parse(txt_ctpnsl.Text);
            string dg = txt_ctpndg.Text;

            if (string.IsNullOrWhiteSpace(mctpn) || string.IsNullOrWhiteSpace(mapn) || string.IsNullOrWhiteSpace(msp))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của chi tiết phiếu nhập trước khi thêm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (phieunhap.KiemTraMaTonTai("ChiTietPhieuNhap", "MaChiTietPhieuNhap", mctpn))
            {
                MessageBox.Show("Mã chi tiết phiếu nhập đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                phieunhap.ThemChiTietPhieuNhap(mctpn, mapn, msp, sl, dg);
                dgv_ctpn.DataSource = null;
                dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                dgv_pn.DataSource = null;
                dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
                cleartxt();
                phieunhap.TongTienPhieuNhap(mctpn,mapn);
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_suactpn_Click(object sender, EventArgs e)
        {
            string mctpn = txt_mactpn.Text;
            string mapn = cbx_mapn.Text;
            string msp = cbx_msp.Text;
            int sl = int.Parse(txt_ctpnsl.Text);
            string dg = txt_ctpndg.Text;

            if (string.IsNullOrWhiteSpace(mctpn) || string.IsNullOrWhiteSpace(mapn) || string.IsNullOrWhiteSpace(msp))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của phiếu nhập trước khi thay đổi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    phieunhap.UpdateChiTietPhieuNhap(mctpn, mapn, msp, sl, dg);
                    phieunhap.TongTienPhieuNhap(mctpn, mapn);
                    dgv_ctpn.DataSource = null;
                    dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                    dgv_pn.DataSource = null;
                    dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
                    cleartxt();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_xoactpn_Click(object sender, EventArgs e)
        {
            string mctpn = txt_mactpn.Text;
            string mapn = txt_mapn.Text;
            if (string.IsNullOrWhiteSpace(mctpn))
            {
                MessageBox.Show("Vui lòng chọn chi tiết phiếu nhập trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    phieunhap.DeleteChiTietPhieuNhap(mctpn);
                    cleartxt2();
                    dgv_ctpn.DataSource = null;
                    dgv_ctpn.DataSource = phieunhap.GetAllChiTietPhieuNhap();
                    dgv_pn.DataSource = null;
                    dgv_pn.DataSource = phieunhap.GetAllPhieuNhap();
                    phieunhap.TongTienPhieuNhap(mctpn, mapn);
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        // Day du lieu vao combobox------------------------------------------------------------------------------------------------

        private void LoadNhaCungCapToComboBox()
        {
            // Lấy danh sách mã nhà cung cấp
            DataTable dtncc = phieunhap.GetAllMaNhacc();

            cbx_mancc.DataSource = dtncc;
            cbx_mancc.DisplayMember = "MaNhaCungCap"; // Cột hiển thị
            cbx_mancc.ValueMember = "MaNhaCungCap"; // Giá trị mã nhà cung cấp

            cbx_mancc.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }

        private void LoadMaPhieuNhapToComboBox()
        {
            // Lấy danh sách mã nhà cung cấp
            DataTable dtpn = phieunhap.GetAllMaPhieuNhap();

            cbx_mapn.DataSource = dtpn;
            cbx_mapn.DisplayMember = "MaPhieuNhap"; // Cột hiển thị
            cbx_mapn.ValueMember = "MaPhieuNhap"; // Giá trị mã nhà cung cấp

            cbx_mapn.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }

        private void LoadMaSanPhamToComboBox()
        {
            // Lấy danh sách mã nhà cung cấp
            DataTable dtsp = phieunhap.GetAllMaSanPham();

            cbx_msp.DataSource = dtsp;
            cbx_msp.DisplayMember = "MaSanPham"; // Cột hiển thị
            cbx_msp.ValueMember = "MaSanPham"; // Giá trị mã nhà cung cấp

            cbx_msp.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }
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

                // Xuất dữ liệu từ Dd=gv sang Excel
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
            ExportToExcel(dgv_pn);
        }

        private void FrmPhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}