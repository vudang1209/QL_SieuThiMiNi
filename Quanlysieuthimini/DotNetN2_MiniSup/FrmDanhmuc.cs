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
    public partial class FrmDanhmuc : Form
    {
        private Danhmuc Danhmuc = new Danhmuc();

        public FrmDanhmuc()
        {
            InitializeComponent();
            dataGridView1.DataSource = Danhmuc.GetAllDanhMuc();
        }

        public void cleartxt()
        {
            txt_madm.Text = string.Empty;
            txt_tendm.Text = string.Empty;
            txt_tk.Text = string.Empty;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string madm = txt_madm.Text.ToUpper();
            string tendm = txt_tendm.Text;

            if (string.IsNullOrWhiteSpace(madm) || string.IsNullOrWhiteSpace(tendm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin danh mục trước khi thêm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Danhmuc.ThemDM(madm, tendm);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = Danhmuc.GetAllDanhMuc();
                cleartxt();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string madm = txt_madm.Text;
            if (string.IsNullOrWhiteSpace(madm))
            {
                MessageBox.Show("Vui nhập mã danh mục trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Danhmuc.DeleteDM(madm);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    cleartxt();
                    dataGridView1.DataSource = Danhmuc.GetAllDanhMuc();
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string madm = txt_madm.Text;
            string tendm = txt_tendm.Text;
            if (string.IsNullOrWhiteSpace(madm) || string.IsNullOrWhiteSpace(tendm))
            {
                MessageBox.Show("Vui nhập mã danh mục trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Danhmuc.UpdateDM(madm, tendm);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.DataSource = Danhmuc.GetAllDanhMuc();
                    cleartxt();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string timkiem = txt_tk.Text;

            if (string.IsNullOrWhiteSpace(timkiem))
            {
                MessageBox.Show("Vui nhập mã danh mục muốn tìm kiếm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rb_ma.Checked == false && rb_ten.Checked == false) MessageBox.Show("Vui chọn loại danh mục bạn muốn tìm kiếm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (rb_ma.Checked)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.DataSource = Danhmuc.SearchMDM(timkiem);
                    }
                    if(rb_ten.Checked)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.DataSource = Danhmuc.SearchTDM(timkiem);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                txt_madm.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_tendm.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmDanhmuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void FrmDanhmuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}