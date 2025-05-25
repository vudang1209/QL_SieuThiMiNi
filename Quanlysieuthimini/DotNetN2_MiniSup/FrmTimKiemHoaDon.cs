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
    public partial class FrmTimKiemHoaDon : Form
    {
        private TimKiemHoaDon timKiemHoaDon = new TimKiemHoaDon();
        public FrmTimKiemHoaDon()
        {
            InitializeComponent();

        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = cbx_chonKhoaTimKiem.SelectedItem?.ToString();
            string giaTri = txb_thongTinTimKiem.Text.Trim();

            DateTime? ngayLapHoaDontruoc = null;
            DateTime? ngayLapHoaDonsau = null;

            if (dpk_ngayLapHDtruoc.Visible && dpk_ngayLapHDsau.Visible)
            {
                ngayLapHoaDontruoc = dpk_ngayLapHDtruoc.Value;
                ngayLapHoaDonsau = dpk_ngayLapHDsau.Value;
            }

            if (tieuChi == "Ngày Lập Hóa Đơn")
            {
                if (!ngayLapHoaDontruoc.HasValue || !ngayLapHoaDonsau.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn cả hai ngày để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ngayLapHoaDontruoc > ngayLapHoaDonsau)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                timKiemHoaDon.TimKiemHoaDonTheoTieuChi_Ngay(ngayLapHoaDontruoc, ngayLapHoaDonsau, dgv_dsHoaDon);
            }
            else if (!string.IsNullOrEmpty(tieuChi) && !string.IsNullOrEmpty(giaTri))
            {
                timKiemHoaDon.TimKiemHoaDonTheoTieuChi_TextBox(tieuChi, giaTri, dgv_dsHoaDon);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void FrmTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            cbx_chonKhoaTimKiem.Items.Add("Mã Hóa Đơn");
            cbx_chonKhoaTimKiem.Items.Add("Mã Sản Phẩm");
            cbx_chonKhoaTimKiem.Items.Add("Tên Sản Phẩm");
            cbx_chonKhoaTimKiem.Items.Add("Mã Khách Hàng");
            cbx_chonKhoaTimKiem.Items.Add("Ngày Lập Hóa Đơn");
            cbx_chonKhoaTimKiem.SelectedIndex = 0; 


            dpk_ngayLapHDtruoc.Visible = false;
            dpk_ngayLapHDsau.Visible = false;
        }

        private void cbx_chonKhoaTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_chonKhoaTimKiem.SelectedItem.ToString() == "Ngày Lập Hóa Đơn")
            {
                dpk_ngayLapHDtruoc.Visible = true;
                dpk_ngayLapHDsau.Visible = true; 
                txb_thongTinTimKiem.Enabled = false; 
            }
            else
            {
                dpk_ngayLapHDtruoc.Visible = false;
                dpk_ngayLapHDsau.Visible = false;  
                txb_thongTinTimKiem.Enabled = true; 
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmTimKiemHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
   
}
