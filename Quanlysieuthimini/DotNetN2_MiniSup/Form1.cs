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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quảnLíNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmnhacc frmnhacc = new Frmnhacc();
            this.Hide();
            frmnhacc.Show();
        }


        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKhachhang frm = new FrmKhachhang();  
            this.Hide();
            frm.Show();
        }

        private void chươngTrìnhKhuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVoucher frmVoucher = new FrmVoucher();   
            this.Hide();
            frmVoucher.Show();
        }

        private void danhMụcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDanhmuc frmDanhMuc = new FrmDanhmuc();
            this.Hide();
            frmDanhMuc.Show();
        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhieuNhap frmPhieuNhap = new FrmPhieuNhap();
            this.Hide();
            frmPhieuNhap.Show();
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSanPham frmSanPham = new FrmSanPham();
            this.Hide();
            frmSanPham.Show();
        }

        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemKhachHang frmTimKiemKhachHang = new FrmTimKiemKhachHang();
            this.Hide();
            frmTimKiemKhachHang.Show();
        }

        private void tìmKiếmSảnPhẩmTheoDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemSP_DM frmTimKiemSP_DM = new FrmTimKiemSP_DM();
            this.Hide();
            frmTimKiemSP_DM.Show();
        }

        private void tìmKiếmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemHoaDon frmTimKiemHoaDon = new FrmTimKiemHoaDon();
            this.Hide();
            frmTimKiemHoaDon.Show();
        }
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoaDon hoaDon = new FrmHoaDon();
            this.Hide();
            hoaDon.Show();
        }

        private void tìmKiếmPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemPhieuNhap frmTimKiemPhieuNhap = new FrmTimKiemPhieuNhap();
            this.Hide();
            frmTimKiemPhieuNhap.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
