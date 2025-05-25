namespace DotNetN2_MiniSup
{
    partial class FrmTimKiemKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimKiemKhachHang));
            this.lb_tieuDe = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.txb_thongTinTimKiem = new System.Windows.Forms.TextBox();
            this.lb_timKiem = new System.Windows.Forms.Label();
            this.cbx_chonKhoaTimKiem = new System.Windows.Forms.ComboBox();
            this.lb_chonKhoaTimKiem = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dsKhachHang = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhachHang)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_tieuDe
            // 
            this.lb_tieuDe.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tieuDe.Location = new System.Drawing.Point(-1, 5);
            this.lb_tieuDe.Name = "lb_tieuDe";
            this.lb_tieuDe.Size = new System.Drawing.Size(861, 37);
            this.lb_tieuDe.TabIndex = 34;
            this.lb_tieuDe.Text = "Thông tin khách hàng";
            this.lb_tieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_thoat.Location = new System.Drawing.Point(426, 221);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(156, 42);
            this.btn_thoat.TabIndex = 33;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click_1);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_timkiem.Location = new System.Drawing.Point(195, 221);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(156, 42);
            this.btn_timkiem.TabIndex = 32;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click_1);
            // 
            // txb_thongTinTimKiem
            // 
            this.txb_thongTinTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_thongTinTimKiem.Location = new System.Drawing.Point(303, 88);
            this.txb_thongTinTimKiem.Name = "txb_thongTinTimKiem";
            this.txb_thongTinTimKiem.Size = new System.Drawing.Size(270, 26);
            this.txb_thongTinTimKiem.TabIndex = 31;
            // 
            // lb_timKiem
            // 
            this.lb_timKiem.AutoSize = true;
            this.lb_timKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_timKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_timKiem.Location = new System.Drawing.Point(150, 95);
            this.lb_timKiem.Name = "lb_timKiem";
            this.lb_timKiem.Size = new System.Drawing.Size(102, 19);
            this.lb_timKiem.TabIndex = 30;
            this.lb_timKiem.Text = "Mã khách hàng";
            // 
            // cbx_chonKhoaTimKiem
            // 
            this.cbx_chonKhoaTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_chonKhoaTimKiem.FormattingEnabled = true;
            this.cbx_chonKhoaTimKiem.Location = new System.Drawing.Point(303, 36);
            this.cbx_chonKhoaTimKiem.Name = "cbx_chonKhoaTimKiem";
            this.cbx_chonKhoaTimKiem.Size = new System.Drawing.Size(270, 27);
            this.cbx_chonKhoaTimKiem.TabIndex = 29;
            this.cbx_chonKhoaTimKiem.SelectedIndexChanged += new System.EventHandler(this.cbx_chonKhoaTimKiem_SelectedIndexChanged);
            // 
            // lb_chonKhoaTimKiem
            // 
            this.lb_chonKhoaTimKiem.AutoSize = true;
            this.lb_chonKhoaTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_chonKhoaTimKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_chonKhoaTimKiem.Location = new System.Drawing.Point(141, 39);
            this.lb_chonKhoaTimKiem.Name = "lb_chonKhoaTimKiem";
            this.lb_chonKhoaTimKiem.Size = new System.Drawing.Size(131, 19);
            this.lb_chonKhoaTimKiem.TabIndex = 28;
            this.lb_chonKhoaTimKiem.Text = "Chọn khóa tìm kiếm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_dsKhachHang);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 278);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(842, 341);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Khách hàng";
            // 
            // dgv_dsKhachHang
            // 
            this.dgv_dsKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dsKhachHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_dsKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dsKhachHang.Location = new System.Drawing.Point(2, 21);
            this.dgv_dsKhachHang.Name = "dgv_dsKhachHang";
            this.dgv_dsKhachHang.RowHeadersWidth = 51;
            this.dgv_dsKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dsKhachHang.Size = new System.Drawing.Size(838, 318);
            this.dgv_dsKhachHang.TabIndex = 36;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_chonKhoaTimKiem);
            this.groupBox2.Controls.Add(this.cbx_chonKhoaTimKiem);
            this.groupBox2.Controls.Add(this.lb_timKiem);
            this.groupBox2.Controls.Add(this.txb_thongTinTimKiem);
            this.groupBox2.Location = new System.Drawing.Point(9, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(840, 156);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập dữ liệu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(206, 231);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(443, 231);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 101;
            this.pictureBox5.TabStop = false;
            // 
            // FrmTimKiemKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 630);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_tieuDe);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmTimKiemKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTimKiemKhachHang";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTimKiemKhachHang_FormClosed);
            this.Load += new System.EventHandler(this.FrmTimKiemKhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhachHang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_tieuDe;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.TextBox txb_thongTinTimKiem;
        private System.Windows.Forms.Label lb_timKiem;
        private System.Windows.Forms.ComboBox cbx_chonKhoaTimKiem;
        private System.Windows.Forms.Label lb_chonKhoaTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dsKhachHang;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}