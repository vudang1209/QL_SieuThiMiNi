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
    public partial class Frmnhacc : Form
    {
        Nhacc Nhacc= new Nhacc();
        public Frmnhacc()
        {
            InitializeComponent();
            dataGridView1.DataSource = Nhacc.GetAllNhaCC();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string manhacc = txt_mancc.Text.ToUpper();
            string tennhacc = txt_tenncc.Text;
            string sdt= txt_sdt.Text;   
            string email = txt_email.Text;
            string diachi = txt_diachi.Text;
            if (string.IsNullOrWhiteSpace(manhacc) || string.IsNullOrWhiteSpace(tennhacc) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của nhà cung cấp trước khi thêm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                Nhacc.ThemNhaCC(manhacc, tennhacc, sdt, email, diachi);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = Nhacc.GetAllNhaCC();
                cleartext();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string manhacc = txt_mancc.Text;
            if (string.IsNullOrWhiteSpace(manhacc)) {
                MessageBox.Show("Vui nhập mã nhà cung cấp muốn xóa !!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Nhacc.DeleteNhaCC(manhacc);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.DataSource = Nhacc.GetAllNhaCC();
                    cleartext();
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string manhacc = txt_mancc.Text.ToUpper();
            string tennhacc = txt_tenncc.Text;
            string sdt = txt_sdt.Text;
            string email = txt_email.Text;
            string diachi = txt_diachi.Text;
            if (string.IsNullOrWhiteSpace(manhacc) || string.IsNullOrWhiteSpace(tennhacc) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của nhà cung cấp trước khi thay đổi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Nhacc.UpdateNhaCC(manhacc, tennhacc, sdt, email, diachi);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.DataSource = Nhacc.GetAllNhaCC();
                    cleartext();
                }
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string timkiem = txt_tk.Text;
            if (string.IsNullOrWhiteSpace(timkiem))
            {
                MessageBox.Show("Vui nhập mã nhà cung cấp muốn tìm kiếm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource =   Nhacc.SearchNhaCC(timkiem);
                
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
        private void cleartext()
        {
            txt_diachi.Text = string.Empty;
            txt_tk.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_sdt.Text = string.Empty;
            txt_tenncc.Text = string.Empty;
            txt_mancc.Text = string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                txt_mancc.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_tenncc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_diachi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void Frmnhacc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
