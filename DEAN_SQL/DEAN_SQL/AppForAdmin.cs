using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DEAN_SQL
{
    public partial class AppForAdmin : Form
    {

        private Timer timer_logout;
        public string connString, user, pass, sever, data;
        public AppForAdmin(string phanQuyen, string name, string password, string servername, string database)
        {
            InitializeComponent();
            lblPhanQuyen.Text = phanQuyen;
            
            timer_logout = new Timer();
            timer_logout.Interval = 500; // Kiểm tra mỗi phút
            timer_logout.Tick += timer_logout_Tick;
            timer_logout.Start();
            user = name;
            pass = password;
            sever = servername;
            data = database;
            connString = "Server=" + sever + ";Database=" + data + ";User Id=" + user + ";Password=" + pass + ";";
        }


        private void App_Load(object sender, EventArgs e)
        {
            btnWorkWithData.Visible = false;

            if (lblPhanQuyen.Text.Equals("&Admin"))
            {
                btnWorkWithData.Visible = true;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    

        private void btnWorkWithData_Click(object sender, EventArgs e)
        {
            WorkWithData workWithData = new WorkWithData(lblPhanQuyen.Text, user, pass, sever, data);
            workWithData.Show();
            this.Close();
        }


        private void timer_logout_Tick(object sender, EventArgs e)
        {
            try
            {
                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (DatabaseConnection.con.State == ConnectionState.Closed)
                {
                    DatabaseConnection.con.Open();
                }

                string query = "SELECT * FROM UserSessions WHERE UserID = @UserID";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, DatabaseConnection.con))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@UserID", user);
                    DataTable dTable = new DataTable();
                    sda.Fill(dTable);

                    if (dTable.Rows.Count == 0)
                    {
                        timer_logout.Stop();
                        //MessageBox.Show("Người dùng " + DangNhap.dangNhap + " đã đăng xuất", "Thông báo");

                        // Hiển thị form đăng nhập và đóng form chính
                        Form1 login = new Form1();
                        login.Location = this.Location; // Đặt form login ở vị trí của form hiện tại
                        login.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error-------> " + ex.Message);
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang(user, pass, sever, data);
            kh.Show();
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon(user, pass, sever, data);
            hd.Show();
        }

        private void btnchitiethoadon_Click(object sender, EventArgs e)
        {
            CHITIETHOADON ct = new CHITIETHOADON();
            ct.Show();
        }

        private void btnhanghoa_Click(object sender, EventArgs e)
        {
            HangHoa hh = new HangHoa( user,  pass,  sever,  data);
            hh.Show();
        }

        private void btnloaihang_Click(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.Show();
        }

        private void btnchitietpn_Click(object sender, EventArgs e)
        {
            CHITIETPN ctpn = new CHITIETPN();
            ctpn.Show();
        }

        private void btnphieunhap_Click(object sender, EventArgs e)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.Show();
        }

        private void btnnhacc_Click(object sender, EventArgs e)
        {
            NHACC ncc = new NHACC();
            ncc.Show();
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien(user, pass, sever, data);
            nv.Show();
        }

        private void AppForAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien ttnv = new ThongTinNhanVien();
            ttnv.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 frm1 = new Form1();
            //frm1.Show();

            DatabaseConnection.InitializeConnection(connString);
            try
            {
                // Đăng xuất và đóng tất cả các form khác
                timer_logout.Stop();

                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (DatabaseConnection.con.State == ConnectionState.Closed)
                {
                    DatabaseConnection.con.Open();
                }

                string query = "DELETE FROM UserSessions WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.con))
                {
                    cmd.Parameters.AddWithValue("@UserID", user);
                    cmd.ExecuteNonQuery();
                }
                //MessageBox.Show("Người dùng " + DangNhap.dangNhap + " đã đăng xuất", "Thông báo");

                // Hiển thị form đăng nhập và đóng form hiện tại
                Form1 login = new Form1();
                login.Location = this.Location; // Đặt form login ở vị trí của form hiện tại
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error-------> " + ex.Message);
            }
        }

      
    }
}
