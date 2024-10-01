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
    public partial class dangky : Form
    {
        public dangky()
        {
            InitializeComponent();
        }
        //private void dangky_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if(r==DialogResult.No)
        //    {
        //        e.Cancel = true;
        //    }
        //}
        private void btnsignup_Click(object sender, EventArgs e)
        {
            //string connectionString = "Server=LAPTOP-H6IDD6F8\\SQLEXPRESS;User Id=sa;Password=sa;";
            string connectionString = @"Data Source=LAPTOP-7VLSR7BE\SQLEXPRESS02;Initial Catalog=DEAN4;Integrated Security=True;Encrypt=False";//Kết nối sql server lưu ý mỗi máy có Source=LAPTOP-H6IDD6F8\SQLEXPRESS khác nhau nên cần xem Source của mình là gì cũng như tên đề án đúng ko
            string username = txtUsername.Text.Trim();
            string password = txtpassword.Text.Trim();
            string re_password = txtrePassword.Text.Trim();
            string database = "DEAN4";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên người dùng và mật khẩu không được để trống.");
                return;
            }
            if (re_password.Equals(password) == false)
            {
                MessageBox.Show("Mật khẩu của bạn nhập lại không chính xác.");
                txtrePassword.Clear();
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //string query = "CREATE LOGIN " + "[" + username + "]" + " WITH PASSWORD = '" + password + "'" + ";USE " + database + ";" + "CREATE USER " + "[" + username + "]" + " FOR LOGIN " + "[" + username + "]" + ";" + "GRANT INSERT ON [dbo].[UserSessions] TO" + "[" + username + "]" + ";" + "GRANT DELETE ON [dbo].[UserSessions] TO" + "[" + username + "]" + ";" + "GRANT SELECT ON [dbo].[UserSessions] TO"+"["+username+"]"+";";//Ghi câu lệnh giống sql để đưa vào sql chạy
                    //string query = "CREATE LOGIN " + "[" + username + "]" + " WITH PASSWORD = '" + password + "'" + ";USE " + database + ";" + "CREATE USER " + "[" + username + "]" + " FOR LOGIN " + "[" + username + "]" + ";" + "GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE TO" + "[" + username + "]" + ";";//Ghi câu lệnh giống sql để đưa vào sql chạy
                    string query = "CREATE_USER" + "";
                    SqlCommand command = new SqlCommand(query, connection);//Tạo một đối tượng SqlCommand để chứa và thực thi câu lệnh SQL query trong kết nối connection.
                    command.CommandType = CommandType.StoredProcedure;

                    //Thêm tham số @USERNAME và @PASSWORD cho thủ tục CREATE_USER
                    command.Parameters.AddWithValue("@USERNAME", username);
                    command.Parameters.AddWithValue("@PASSWORD", password);
                    command.Parameters.AddWithValue("@DATABASE", database);

                    command.ExecuteNonQuery();//Thực thi câu lệnh SQL
                    MessageBox.Show("Tạo người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form1 dangnhap = new Form1();
                    dangnhap.Show();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }



        private void btnclear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtrePassword.Clear();
            txtUsername.Focus();
        }



        private void lbllogin_Click(object sender, EventArgs e)
        {
            //khi lựa chọn chuyển sang login thì tạo form login mới rồi hiển thị nó cũng như sẽ ẩn đi form hiện tại là form sign up
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void chkpass_CheckedChanged(object sender, EventArgs e)
        {
            //Dùng để đổi mật khẩu thành các dấuu * và đổi ngược lại
            if (chkpass.Checked == true)
            {
                txtpassword.PasswordChar = '\0';
                txtrePassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtrePassword.PasswordChar = '*';
            }
        }

    }
}
