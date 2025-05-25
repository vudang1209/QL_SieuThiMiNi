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
    public partial class FrmTimKiemPhieuNhap : Form
    {
        private TimKiemPhieuNhap timKiem = new TimKiemPhieuNhap();
        public FrmTimKiemPhieuNhap()
        {
            InitializeComponent();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cbx_chonKhoaTimKiem.SelectedItem?.ToString(); 
            string giaTri = txb_thongTinTimKiem.Text.Trim();  

            DateTime? ngayNhapTruoc = null;
            DateTime? ngayNhapSau = null;

            if (dpk_ngayNhapTruoc.Visible && dpk_ngayNhapSau.Visible)
            {
                ngayNhapTruoc = dpk_ngayNhapTruoc.Value;
                ngayNhapSau = dpk_ngayNhapSau.Value;
            }

            if (!string.IsNullOrEmpty(tieuChi) && !string.IsNullOrEmpty(giaTri))
            {
                timKiem.TimKiemPhieuNhapTheoTieuChi_TextBox(tieuChi, giaTri, dgv_dsHoaDon);
            }
            else if (ngayNhapTruoc.HasValue && ngayNhapSau.HasValue)
            {
                timKiem.TimKiemPhieuNhapTheoTieuChi_Ngay(ngayNhapTruoc, ngayNhapSau, dgv_dsHoaDon);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm hợp lệ!");
            }
        }

        private void FrmTimKiemPhieuNhap_Load(object sender, EventArgs e)
        {
            cbx_chonKhoaTimKiem.Items.Add("Mã Phiếu Nhập");
            cbx_chonKhoaTimKiem.Items.Add("Mã Nhà Cung Cấp");
            cbx_chonKhoaTimKiem.Items.Add("Tên Sản Phẩm");
            cbx_chonKhoaTimKiem.Items.Add("Ngày Nhập");

            // Chọn mặc định tiêu chí tìm kiếm là "Mã Phiếu Nhập"
            cbx_chonKhoaTimKiem.SelectedIndex = 0;
        }

        private void cbx_chonKhoaTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_chonKhoaTimKiem.SelectedItem.ToString() == "Ngày Nhập")
            {
                dpk_ngayNhapTruoc.Visible = true;
                dpk_ngayNhapSau.Visible = true;
                txb_thongTinTimKiem.Visible = false;
            }
            else
            {
                dpk_ngayNhapTruoc.Visible = false;
                dpk_ngayNhapSau.Visible = false;
                txb_thongTinTimKiem.Visible = true;
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmTimKiemPhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
