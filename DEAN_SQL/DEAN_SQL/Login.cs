using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Khai báo thử viện để sử dụng câu lệnh kết nối sql

namespace DEAN_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //SqlConnection Conn=new SqlConnection(@"Data Source=LAPTOP-H6IDD6F8\SQLEXPRESS;Initial Catalog=DEAN4;Integrated Security=True");
        SqlConnection Conn;


        
        public string User;
        public string Password;
        public string Servername;
        public string Database;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            /*Port = 1433;*///Đây là cổng mặc định của sql server
            Servername = txtservername.Text;
            User = txtusername.Text;
            Password = txtpassword.Text;
            Database = txtdatabase.Text;//Tên database đã tạo trong csdl mà mình muốn kết nối
            //Host = "192.168.1.100";//Sẽ kết nối sql trên chính máy tính này 
            if(string.IsNullOrEmpty(txtusername.Text)||string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Tên người dùng và mật khẩu không được để trống");
                return;
            }

           

            try
            {
                //string connString = "Server=" + Host + "\\SQLEXPRESS" + ";Database=" + Database + ";User Id=" + User + ";Password=" + Password + ";";//Câu lệnh kết nối sql thông qua username và password
                //string connString = "Server=" +txtservername.Text + ";Database=" + txtdatabase.Text + ";User Id=" + User + ";Password=" + Password + ";";
                string connString = "Server=" + Servername + ";Database=" + Database + ";User Id=" + User + ";Password=" + Password + ";";
                DatabaseConnection.InitializeConnection(connString);
                //using (Conn = new SqlConnection(connString))

                using (Conn = DatabaseConnection.con)
                {
                    Conn.Open();
                    DangNhap.name = txtusername.Text;
                    DangNhap.password = txtpassword.Text;
                    string insertSessionQuery = "INSERT INTO UserSessions (UserID) VALUES (@UserID)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSessionQuery, Conn))
                    {
                        insertCmd.Parameters.AddWithValue("@UserID", User);
                        insertCmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Conn.Close();

                    if (User == "sa" && Password == "sa")
                    {
                        lblPhanQuyen.Text = "&Admin"; //Kiểm tra nếu là admin thì cấp quyền
                        this.Close();
                        AppForAdmin appForAdmin = new AppForAdmin(lblPhanQuyen.Text, User, Password, Servername, Database);
                        appForAdmin.Show();
                    }


                    else
                    {
                        lblPhanQuyen.Text = User; //không là admin thì gán bằng username
                        App app = new App(lblPhanQuyen.Text, User, Password, Servername, Database);
                        app.Show();
                        this.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                // Log ngoại lệ hoặc xử lý phù hợp tại đây
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }


        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if(r==DialogResult.No)
        //    {
        //        e.Cancel = true;
        //    }
        //}
        private void lblregister_Click(object sender, EventArgs e)
        {
            //khi lựa chọn chuyển sang sign up thì tạo form sign up mới rồi hiển thị nó cũng như sẽ ẩn đi form hiện tại là form login
            dangky dk = new dangky();
            dk.Show();
            this.Close();
        }

        private void chkpass_CheckedChanged(object sender, EventArgs e)
        {
            //Dùng để đổi mật khẩu thành các dấuu * và đổi ngược lại
            if(chkpass.Checked==true)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
        