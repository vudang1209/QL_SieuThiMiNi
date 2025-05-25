namespace DotNetN2_MiniSup
{
    partial class FrmTimKiemHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimKiemHoaDon));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dsHoaDon = new System.Windows.Forms.DataGridView();
            this.lb_tieuDe = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.txb_thongTinTimKiem = new System.Windows.Forms.TextBox();
            this.lb_timKiem = new System.Windows.Forms.Label();
            this.cbx_chonKhoaTimKiem = new System.Windows.Forms.ComboBox();
            this.lb_chonKhoaTimKiem = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.dpk_ngayLapHDtruoc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dpk_ngayLapHDsau = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsHoaDon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_dsHoaDon);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 305);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Khách hàng";
            // 
            // dgv_dsHoaDon
            // 
            this.dgv_dsHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dsHoaDon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_dsHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dsHoaDon.Location = new System.Drawing.Point(3, 22);
            this.dgv_dsHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_dsHoaDon.Name = "dgv_dsHoaDon";
            this.dgv_dsHoaDon.RowHeadersWidth = 51;
            this.dgv_dsHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dsHoaDon.Size = new System.Drawing.Size(839, 280);
            this.dgv_dsHoaDon.TabIndex = 36;
            // 
            // lb_tieuDe
            // 
            this.lb_tieuDe.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tieuDe.Location = new System.Drawing.Point(-1, -1);
            this.lb_tieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tieuDe.Name = "lb_tieuDe";
            this.lb_tieuDe.Size = new System.Drawing.Size(866, 45);
            this.lb_tieuDe.TabIndex = 42;
            this.lb_tieuDe.Text = "Thông tin hóa đơn";
            this.lb_tieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_thoat.Location = new System.Drawing.Point(469, 261);
            this.btn_thoat.Margin = new System.Windows.Forms.Padding(4);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(156, 42);
            this.btn_thoat.TabIndex = 41;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_timkiem.Location = new System.Drawing.Point(217, 261);
            this.btn_timkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(156, 42);
            this.btn_timkiem.TabIndex = 40;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // txb_thongTinTimKiem
            // 
            this.txb_thongTinTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_thongTinTimKiem.Location = new System.Drawing.Point(220, 69);
            this.txb_thongTinTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txb_thongTinTimKiem.Name = "txb_thongTinTimKiem";
            this.txb_thongTinTimKiem.Size = new System.Drawing.Size(431, 26);
            this.txb_thongTinTimKiem.TabIndex = 39;
            // 
            // lb_timKiem
            // 
            this.lb_timKiem.AutoSize = true;
            this.lb_timKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_timKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_timKiem.Location = new System.Drawing.Point(44, 76);
            this.lb_timKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_timKiem.Name = "lb_timKiem";
            this.lb_timKiem.Size = new System.Drawing.Size(83, 19);
            this.lb_timKiem.TabIndex = 38;
            this.lb_timKiem.Text = "Mã hóa đơn";
            // 
            // cbx_chonKhoaTimKiem
            // 
            this.cbx_chonKhoaTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_chonKhoaTimKiem.FormattingEnabled = true;
            this.cbx_chonKhoaTimKiem.Location = new System.Drawing.Point(220, 29);
            this.cbx_chonKhoaTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_chonKhoaTimKiem.Name = "cbx_chonKhoaTimKiem";
            this.cbx_chonKhoaTimKiem.Size = new System.Drawing.Size(431, 27);
            this.cbx_chonKhoaTimKiem.TabIndex = 37;
            this.cbx_chonKhoaTimKiem.SelectedIndexChanged += new System.EventHandler(this.cbx_chonKhoaTimKiem_SelectedIndexChanged);
            // 
            // lb_chonKhoaTimKiem
            // 
            this.lb_chonKhoaTimKiem.AutoSize = true;
            this.lb_chonKhoaTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_chonKhoaTimKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_chonKhoaTimKiem.Location = new System.Drawing.Point(44, 37);
            this.lb_chonKhoaTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_chonKhoaTimKiem.Name = "lb_chonKhoaTimKiem";
            this.lb_chonKhoaTimKiem.Size = new System.Drawing.Size(131, 19);
            this.lb_chonKhoaTimKiem.TabIndex = 36;
            this.lb_chonKhoaTimKiem.Text = "Chọn khóa tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(44, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "Ngày lập Hóa đơn";
            // 
            // dpk_ngayLapHDtruoc
            // 
            this.dpk_ngayLapHDtruoc.CustomFormat = "dd/MM/yyyy";
            this.dpk_ngayLapHDtruoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpk_ngayLapHDtruoc.Location = new System.Drawing.Point(220, 114);
            this.dpk_ngayLapHDtruoc.Name = "dpk_ngayLapHDtruoc";
            this.dpk_ngayLapHDtruoc.Size = new System.Drawing.Size(179, 26);
            this.dpk_ngayLapHDtruoc.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(418, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 19);
            this.label2.TabIndex = 46;
            this.label2.Text = "đến";
            // 
            // dpk_ngayLapHDsau
            // 
            this.dpk_ngayLapHDsau.CustomFormat = "dd/MM/yyyy";
            this.dpk_ngayLapHDsau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpk_ngayLapHDsau.Location = new System.Drawing.Point(472, 115);
            this.dpk_ngayLapHDsau.Name = "dpk_ngayLapHDsau";
            this.dpk_ngayLapHDsau.Size = new System.Drawing.Size(179, 26);
            this.dpk_ngayLapHDsau.TabIndex = 47;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dpk_ngayLapHDsau);
            this.groupBox2.Controls.Add(this.lb_chonKhoaTimKiem);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbx_chonKhoaTimKiem);
            this.groupBox2.Controls.Add(this.dpk_ngayLapHDtruoc);
            this.groupBox2.Controls.Add(this.lb_timKiem);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txb_thongTinTimKiem);
            this.groupBox2.Location = new System.Drawing.Point(15, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 188);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập dữ liệu";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(478, 271);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 99;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(227, 271);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 99;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTimKiemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 630);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_tieuDe);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTimKiemHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTimKiemHoaDon";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTimKiemHoaDon_FormClosed);
            this.Load += new System.EventHandler(this.FrmTimKiemHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsHoaDon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dsHoaDon;
        private System.Windows.Forms.Label lb_tieuDe;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.TextBox txb_thongTinTimKiem;
        private System.Windows.Forms.Label lb_timKiem;
        private System.Windows.Forms.ComboBox cbx_chonKhoaTimKiem;
        private System.Windows.Forms.Label lb_chonKhoaTimKiem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpk_ngayLapHDtruoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpk_ngayLapHDsau;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}