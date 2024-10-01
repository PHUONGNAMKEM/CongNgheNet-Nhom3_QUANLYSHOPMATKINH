namespace DEAN_SQL
{
    partial class HangHoa
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
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grpnhapthongtin = new System.Windows.Forms.GroupBox();
            this.txtmaloai = new System.Windows.Forms.TextBox();
            this.txttenhang = new System.Windows.Forms.TextBox();
            this.txtdvt = new System.Windows.Forms.TextBox();
            this.txtmahg = new System.Windows.Forms.TextBox();
            this.lblmaloai = new System.Windows.Forms.Label();
            this.lbltenhang = new System.Windows.Forms.Label();
            this.lbldvt = new System.Windows.Forms.Label();
            this.lblmahg = new System.Windows.Forms.Label();
            this.grpthongtinhanghoa = new System.Windows.Forms.GroupBox();
            this.lst_dl = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnhangchuaban = new System.Windows.Forms.Button();
            this.btnhangbanchaynhat = new System.Windows.Forms.Button();
            this.grpnhapthongtin.SuspendLayout();
            this.grpthongtinhanghoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(699, 281);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(146, 46);
            this.btnclear.TabIndex = 28;
            this.btnclear.Text = "Mới";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(493, 281);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(146, 46);
            this.btnsua.TabIndex = 27;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(291, 281);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(146, 46);
            this.btnxoa.TabIndex = 26;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(89, 281);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(146, 46);
            this.btnthem.TabIndex = 25;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 29);
            this.label5.TabIndex = 24;
            this.label5.Text = "APP";
            // 
            // grpnhapthongtin
            // 
            this.grpnhapthongtin.Controls.Add(this.txtmaloai);
            this.grpnhapthongtin.Controls.Add(this.txttenhang);
            this.grpnhapthongtin.Controls.Add(this.txtdvt);
            this.grpnhapthongtin.Controls.Add(this.txtmahg);
            this.grpnhapthongtin.Controls.Add(this.lblmaloai);
            this.grpnhapthongtin.Controls.Add(this.lbltenhang);
            this.grpnhapthongtin.Controls.Add(this.lbldvt);
            this.grpnhapthongtin.Controls.Add(this.lblmahg);
            this.grpnhapthongtin.Location = new System.Drawing.Point(89, 66);
            this.grpnhapthongtin.Name = "grpnhapthongtin";
            this.grpnhapthongtin.Size = new System.Drawing.Size(756, 201);
            this.grpnhapthongtin.TabIndex = 23;
            this.grpnhapthongtin.TabStop = false;
            this.grpnhapthongtin.Text = "Nhập thông tin hàng hóa";
            // 
            // txtmaloai
            // 
            this.txtmaloai.Location = new System.Drawing.Point(467, 119);
            this.txtmaloai.Name = "txtmaloai";
            this.txtmaloai.Size = new System.Drawing.Size(230, 22);
            this.txtmaloai.TabIndex = 7;
            // 
            // txttenhang
            // 
            this.txttenhang.Location = new System.Drawing.Point(467, 43);
            this.txttenhang.Multiline = true;
            this.txttenhang.Name = "txttenhang";
            this.txttenhang.Size = new System.Drawing.Size(230, 22);
            this.txttenhang.TabIndex = 6;
            // 
            // txtdvt
            // 
            this.txtdvt.Location = new System.Drawing.Point(133, 125);
            this.txtdvt.Name = "txtdvt";
            this.txtdvt.Size = new System.Drawing.Size(215, 22);
            this.txtdvt.TabIndex = 5;
            // 
            // txtmahg
            // 
            this.txtmahg.Location = new System.Drawing.Point(133, 43);
            this.txtmahg.Name = "txtmahg";
            this.txtmahg.Size = new System.Drawing.Size(215, 22);
            this.txtmahg.TabIndex = 4;
            // 
            // lblmaloai
            // 
            this.lblmaloai.AutoSize = true;
            this.lblmaloai.Location = new System.Drawing.Point(397, 124);
            this.lblmaloai.Name = "lblmaloai";
            this.lblmaloai.Size = new System.Drawing.Size(55, 16);
            this.lblmaloai.TabIndex = 3;
            this.lblmaloai.Text = "MaLoai:";
            // 
            // lbltenhang
            // 
            this.lbltenhang.AutoSize = true;
            this.lbltenhang.Location = new System.Drawing.Point(397, 46);
            this.lbltenhang.Name = "lbltenhang";
            this.lbltenhang.Size = new System.Drawing.Size(54, 16);
            this.lbltenhang.TabIndex = 2;
            this.lbltenhang.Text = "TenHG:";
            this.lbltenhang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbldvt
            // 
            this.lbldvt.AutoSize = true;
            this.lbldvt.Location = new System.Drawing.Point(58, 128);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(34, 16);
            this.lbldvt.TabIndex = 1;
            this.lbldvt.Text = "ĐVT";
            // 
            // lblmahg
            // 
            this.lblmahg.AutoSize = true;
            this.lblmahg.Location = new System.Drawing.Point(58, 46);
            this.lblmahg.Name = "lblmahg";
            this.lblmahg.Size = new System.Drawing.Size(49, 16);
            this.lblmahg.TabIndex = 0;
            this.lblmahg.Text = "MaHG:";
            // 
            // grpthongtinhanghoa
            // 
            this.grpthongtinhanghoa.Controls.Add(this.lst_dl);
            this.grpthongtinhanghoa.Location = new System.Drawing.Point(89, 396);
            this.grpthongtinhanghoa.Name = "grpthongtinhanghoa";
            this.grpthongtinhanghoa.Size = new System.Drawing.Size(756, 212);
            this.grpthongtinhanghoa.TabIndex = 22;
            this.grpthongtinhanghoa.TabStop = false;
            this.grpthongtinhanghoa.Text = "Thông tin hàng hóa";
            // 
            // lst_dl
            // 
            this.lst_dl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lst_dl.FullRowSelect = true;
            this.lst_dl.GridLines = true;
            this.lst_dl.HideSelection = false;
            this.lst_dl.Location = new System.Drawing.Point(61, 39);
            this.lst_dl.Name = "lst_dl";
            this.lst_dl.Size = new System.Drawing.Size(636, 148);
            this.lst_dl.TabIndex = 0;
            this.lst_dl.UseCompatibleStateImageBehavior = false;
            this.lst_dl.View = System.Windows.Forms.View.Details;
            this.lst_dl.Click += new System.EventHandler(this.lst_dl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MAHG";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TENHANG";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DVT";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "MALOAI";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số lượng";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Doanh thu";
            this.columnHeader6.Width = 90;
            // 
            // btnhangchuaban
            // 
            this.btnhangchuaban.Location = new System.Drawing.Point(493, 344);
            this.btnhangchuaban.Name = "btnhangchuaban";
            this.btnhangchuaban.Size = new System.Drawing.Size(146, 46);
            this.btnhangchuaban.TabIndex = 29;
            this.btnhangchuaban.Text = "Hàng chưa bán";
            this.btnhangchuaban.UseVisualStyleBackColor = true;
            this.btnhangchuaban.Click += new System.EventHandler(this.btnhangchuaban_Click);
            // 
            // btnhangbanchaynhat
            // 
            this.btnhangbanchaynhat.Location = new System.Drawing.Point(291, 344);
            this.btnhangbanchaynhat.Name = "btnhangbanchaynhat";
            this.btnhangbanchaynhat.Size = new System.Drawing.Size(146, 46);
            this.btnhangbanchaynhat.TabIndex = 30;
            this.btnhangbanchaynhat.Text = "Hàng bán chạy nhất";
            this.btnhangbanchaynhat.UseVisualStyleBackColor = true;
            this.btnhangbanchaynhat.Click += new System.EventHandler(this.btnhangbanchaynhat_Click);
            // 
            // HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 620);
            this.Controls.Add(this.btnhangbanchaynhat);
            this.Controls.Add(this.btnhangchuaban);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpnhapthongtin);
            this.Controls.Add(this.grpthongtinhanghoa);
            this.Name = "HangHoa";
            this.Text = "HangHoa";
            this.Load += new System.EventHandler(this.HangHoa_Load);
            this.grpnhapthongtin.ResumeLayout(false);
            this.grpnhapthongtin.PerformLayout();
            this.grpthongtinhanghoa.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpnhapthongtin;
        private System.Windows.Forms.TextBox txtmaloai;
        private System.Windows.Forms.TextBox txttenhang;
        private System.Windows.Forms.TextBox txtdvt;
        private System.Windows.Forms.TextBox txtmahg;
        private System.Windows.Forms.Label lblmaloai;
        private System.Windows.Forms.Label lbltenhang;
        private System.Windows.Forms.Label lbldvt;
        private System.Windows.Forms.Label lblmahg;
        private System.Windows.Forms.GroupBox grpthongtinhanghoa;
        private System.Windows.Forms.ListView lst_dl;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnhangchuaban;
        private System.Windows.Forms.Button btnhangbanchaynhat;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}