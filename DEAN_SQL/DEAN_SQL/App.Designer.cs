namespace DEAN_SQL
{
    partial class App
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
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnnhanvienview = new System.Windows.Forms.Button();
            this.btnkhachhangview = new System.Windows.Forms.Button();
            this.btnhoadonview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhanQuyen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(892, 773);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(154, 73);
            this.btnlogout.TabIndex = 0;
            this.btnlogout.Text = "Log out";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(1084, 773);
            this.btnexit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(154, 73);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(18, 20);
            this.btnnew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(224, 62);
            this.btnnew.TabIndex = 2;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnnhanvienview
            // 
            this.btnnhanvienview.Location = new System.Drawing.Point(483, 20);
            this.btnnhanvienview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnnhanvienview.Name = "btnnhanvienview";
            this.btnnhanvienview.Size = new System.Drawing.Size(224, 62);
            this.btnnhanvienview.TabIndex = 13;
            this.btnnhanvienview.Text = "Nhân viên (View)";
            this.btnnhanvienview.UseVisualStyleBackColor = true;
            this.btnnhanvienview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btnkhachhangview
            // 
            this.btnkhachhangview.Location = new System.Drawing.Point(483, 91);
            this.btnkhachhangview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnkhachhangview.Name = "btnkhachhangview";
            this.btnkhachhangview.Size = new System.Drawing.Size(224, 62);
            this.btnkhachhangview.TabIndex = 14;
            this.btnkhachhangview.Text = "Khách hàng (View)";
            this.btnkhachhangview.UseVisualStyleBackColor = true;
            this.btnkhachhangview.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnhoadonview
            // 
            this.btnhoadonview.Location = new System.Drawing.Point(483, 162);
            this.btnhoadonview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnhoadonview.Name = "btnhoadonview";
            this.btnhoadonview.Size = new System.Drawing.Size(224, 62);
            this.btnhoadonview.TabIndex = 15;
            this.btnhoadonview.Text = "Hóa đơn (View)";
            this.btnhoadonview.UseVisualStyleBackColor = true;
            this.btnhoadonview.Click += new System.EventHandler(this.btnhoadonview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(885, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "Username";
            // 
            // lblPhanQuyen
            // 
            this.lblPhanQuyen.AutoSize = true;
            this.lblPhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanQuyen.Location = new System.Drawing.Point(1079, 38);
            this.lblPhanQuyen.Name = "lblPhanQuyen";
            this.lblPhanQuyen.Size = new System.Drawing.Size(159, 37);
            this.lblPhanQuyen.TabIndex = 17;
            this.lblPhanQuyen.Text = "username";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 869);
            this.Controls.Add(this.lblPhanQuyen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnhoadonview);
            this.Controls.Add(this.btnkhachhangview);
            this.Controls.Add(this.btnnhanvienview);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnlogout);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App";
            this.Load += new System.EventHandler(this.App_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnnhanvienview;
        private System.Windows.Forms.Button btnkhachhangview;
        private System.Windows.Forms.Button btnhoadonview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhanQuyen;
    }
}