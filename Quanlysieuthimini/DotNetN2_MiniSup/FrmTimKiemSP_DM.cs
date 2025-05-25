using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetN2_MiniSup
{
    public partial class FrmTimKiemSP_DM : Form
    {
        private TimKiemSP timKiemSanPham;
        public FrmTimKiemSP_DM()
        {
            InitializeComponent();
            timKiemSanPham = new TimKiemSP();
        }
        private void LoadDanhMuc()
        {
            DataTable dtDanhMuc = timKiemSanPham.LayDanhMuc();
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDanhMuc";
            cmbDanhMuc.DataSource = dtDanhMuc;
        }

        private void UpdateControlsState()
        {
            string selectedOption = cbx_chonKhoaTimKiem.SelectedItem?.ToString();

            if (selectedOption == "Danh Mục")
            {
                // Nếu chọn "Danh Mục" thì disable TextBox và enable ComboBox
                txb_thongTinTimKiem.Enabled = false;
                cmbDanhMuc.Enabled = true;
                LoadDanhMuc();
            }
            else
            {
                // Nếu chọn các mục khác thì disable ComboBox và enable TextBox
                txb_thongTinTimKiem.Enabled = true;
                cmbDanhMuc.Enabled = false;
            }
        }
        private void FrmTimKiemSP_DM_Load(object sender, EventArgs e)
        {
            cbx_chonKhoaTimKiem.Items.Add("Mã Sản Phẩm");
            cbx_chonKhoaTimKiem.Items.Add("Tên Sản Phẩm");
            cbx_chonKhoaTimKiem.Items.Add("Danh Mục");
            cbx_chonKhoaTimKiem.Items.Add("Hạn Sử Dụng dưới 7 ngày");
            cbx_chonKhoaTimKiem.Items.Add("Hạn Sử Dụng đã quá hạn");
            cbx_chonKhoaTimKiem.SelectedIndex = 0;
            
            UpdateControlsState();
        }

        private void cmbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maDanhMuc = cmbDanhMuc.SelectedValue.ToString();
            LoadSanPhamTheoDanhMuc(maDanhMuc);
        }
        private void LoadSanPhamTheoDanhMuc(string maDanhMuc)
        {
            DataTable dtSanPham = timKiemSanPham.LaySanPhamTheoDanhMuc(maDanhMuc);
            dgv_dsSanPham.DataSource = dtSanPham;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cbx_chonKhoaTimKiem.SelectedItem?.ToString();
            string giaTri = txb_thongTinTimKiem.Text.Trim();

            DateTime today = DateTime.Today;
            DateTime sevenDaysLater = today.AddDays(7);

            if (tieuChi == "Mã Sản Phẩm" && !string.IsNullOrEmpty(giaTri))
            {
                timKiemSanPham.TimKiemTheoMasp(giaTri, dgv_dsSanPham);  
            }
            else if (tieuChi == "Tên Sản Phẩm" && !string.IsNullOrEmpty(giaTri))
            {
                timKiemSanPham.TimKiemTheoTen(giaTri, dgv_dsSanPham);
            }
            else if (tieuChi == "Danh Mục" && cmbDanhMuc.SelectedValue != null)
            {
                string maDanhMuc = cmbDanhMuc.SelectedValue.ToString();
                timKiemSanPham.LaySanPhamTheoDanhMuc(maDanhMuc);
                LoadDanhMuc();
            }
            else if (tieuChi == "Hạn Sử Dụng dưới 7 ngày")
            {
                timKiemSanPham.TimKiemTheoHanSuDung(sapHetHan: true, ngayKeTiep: sevenDaysLater, dgv_dsSanPham);
                
            }
            else if (tieuChi == "Hạn Sử Dụng đã quá hạn")
            {
                timKiemSanPham.TimKiemTheoHanSuDung(sapHetHan: false, ngayKeTiep: today, dgv_dsSanPham);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm hợp lệ!");
            }
        }

        private void cbx_chonKhoaTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmTimKiemSP_DM_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
