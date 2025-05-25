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
    public partial class FrmVoucher : Form
    {
        Voucher Voucher = new Voucher();
        public FrmVoucher()
        {
            InitializeComponent();
            dataGridView1.DataSource = Voucher.GetAllVoucher();
        }
        public void cleartxt(){
            txt_giatri.Text = string.Empty;
            txt_mavoucher.Text = string.Empty;
            dtp_ngay.Value = DateTime.Now;
            txt_tk.Text = string.Empty;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string mavocher = txt_mavoucher.Text.ToUpper();
            string giatri = txt_giatri.Text;
           DateTime ngay = dtp_ngay.Value;
   
            if (string.IsNullOrWhiteSpace(mavocher) || string.IsNullOrWhiteSpace(giatri)  )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin voucher trước khi thêm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Voucher.ThemVoucher(mavocher, giatri, ngay);    
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = Voucher.GetAllVoucher();
                cleartxt();
                MessageBox.Show("Thêm dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0){
                txt_mavoucher.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_giatri.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtp_ngay.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string mavoucher = txt_mavoucher.Text;
            if (string.IsNullOrWhiteSpace(mavoucher))
            {
                MessageBox.Show("Vui nhập mã voucher trước khi xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Voucher.DeleteVoucher(mavoucher);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    cleartxt();
                    dataGridView1.DataSource = Voucher.GetAllVoucher();
                    MessageBox.Show("Xóa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string mavoucher = txt_mavoucher.Text;
            string giatri = txt_giatri.Text;
            DateTime ngay = dtp_ngay.Value;
            
            if (string.IsNullOrWhiteSpace(mavoucher) || string.IsNullOrWhiteSpace(giatri) )
            {
                MessageBox.Show("Vui nhập mã voucher trước khi sửa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Voucher.UpdateVoucher(mavoucher, giatri, ngay);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.DataSource = Voucher.GetAllVoucher();
                    cleartxt();
                    MessageBox.Show("Sửa dữ liệu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string timkiem = txt_tk.Text;
            if (string.IsNullOrWhiteSpace(timkiem))
            {
                MessageBox.Show("Vui nhập mã voucher muốn tìm kiếm !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = Voucher.SearchVoucher(timkiem);
            }
        }

        private void FrmVoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
