using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DotNetN2_MiniSup
{
    public partial class FrmKhachhang : Form
    {
        Khachhang khachhang = new Khachhang();
        public FrmKhachhang()
        {
            InitializeComponent();
            dataGridView1.DataSource = khachhang.GetAllKH();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string makh = txt_makh.Text.ToUpper();
            string tenkh = txt_tenkh.Text;
            string sdt = txt_sdt.Text;
            string email = txt_email.Text;
            string diachi = txt_diachi.Text;
            if (string.IsNullOrWhiteSpace(makh) || string.IsNullOrWhiteSpace(tenkh) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của khách hàng trước khi thêm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                khachhang.ThemKH(makh, tenkh, sdt, email, diachi);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = khachhang.GetAllKH();
                cleartxt();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string makh = txt_makh.Text;
            if (string.IsNullOrWhiteSpace(makh))
            {
                MessageBox.Show("Vui nhập mã khách hàng trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                khachhang.DeleteKH(makh);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                cleartxt();
                dataGridView1.DataSource = khachhang.GetAllKH();
                MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
        
        private void btn_sua_Click(object sender, EventArgs e)
        {
            string makh = txt_makh.Text;
            string tenkh = txt_tenkh.Text;
            string sdt = txt_sdt.Text;
            string email = txt_email.Text;
            string diachi = txt_diachi.Text;
            if (string.IsNullOrWhiteSpace(makh) || string.IsNullOrWhiteSpace(tenkh) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của khách hàng trước khi thay đổi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    khachhang.UpdateKH(makh, tenkh, sdt, email, diachi);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.DataSource = khachhang.GetAllKH();
                    cleartxt();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                txt_makh.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_tenkh.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_diachi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
        private void cleartxt()
        {
            txt_makh.Text = string.Empty;
            txt_tenkh.Text = string.Empty;
            txt_sdt.Text = string.Empty;
            txt_diachi.Text = string.Empty;
            txt_email.Text = string.Empty;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmKhachhang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
