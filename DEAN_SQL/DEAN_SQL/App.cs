using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.RightsManagement;

namespace DEAN_SQL
{
    //public partial class App : Form
    //{
    //    public App()
    //    {
    //        InitializeComponent();
    //    }

    //    private void App_Load(object sender, EventArgs e)
    //    {
    //    }



    //    private void btnnew_Click(object sender, EventArgs e)
    //    {
    //        Form1 form=new Form1();
    //        form.Show();
    //    }

    //    private void btnexit_Click(object sender, EventArgs e)
    //    {
    //        this.Close();
    //    }

    //    private void App_FormClosing(object sender, FormClosingEventArgs e)
    //    {
    //        // Hiển thị hộp thoại xác nhận khi đóng form từ các lý do khác
    //        DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    //        if (r == DialogResult.No)
    //        {
    //            e.Cancel = true;
    //        }
    //    }
    //    private void timer_logout_Tick(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            string query = $"SELECT * FROM UserSessions WHERE UserID"+"'Dangnhap.dangNhap'";
    //            SqlDataAdapter sda= new SqlDataAdapter(query, DatabaseConnection.con);
    //            DataTable dTable = new DataTable();
    //            sda.Fill(dTable);
    //            if(dTable.Rows.Count == 0)
    //            {
    //                timer_logout.Stop();
    //                Form1 login = new Form1();
    //                DatabaseConnection.con=null;
    //                login.Show();
    //                this.DestroyHandle();
    //                MessageBox.Show("Người dùng "+DangNhap.dangNhap+" đã đăng xuất", "Thông báo");

    //            }
    //        }
    //        catch(Exception ex)
    //        { 
    //            MessageBox.Show("Error-------> "+ ex.Message);
    //        }
    //    }

    //            private void btnlogout_Click(object sender, EventArgs e)
    //    {
    //        // Đăng xuất và đóng tất cả các form khác
    //        timer_logout.Stop();
    //        string query = "DELETE FROM UserSessions WHERE UserID = "+ DangNhap.dangNhap;
    //        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.con);
    //        cmd.ExecuteNonQuery();

    //        Form1 login=new Form1();
    //        DatabaseConnection.con=null;
    //        this.DestroyHandle();
    //        login.Show();
    //    }
  

    //}
    public partial class App : Form
    {
        private Timer timer_logout;
        string connString, user, pass, server, data;

        public App(string phanQuyen, string name, string password, string servername, string database)
        {
            InitializeComponent();
            lblPhanQuyen.Text = phanQuyen;
            
            timer_logout = new Timer();
            timer_logout.Interval = 500; // Kiểm tra mỗi phút
            timer_logout.Tick += timer_logout_Tick;
            timer_logout.Start();
            user = name;
            pass = password;
            server = servername;
            data = database;
            connString = "Server=" +server + ";Database=" + data + ";User Id=" + user + ";Password=" + pass + ";";
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
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

        private void App_Load(object sender, EventArgs e)
        {

        }

        //private void btnKhachHang_Click(object sender, EventArgs e)
        //{
        //    KhachHang kh = new KhachHang();
        //    kh.Show();
        //}

        //private void btnhoadon_Click(object sender, EventArgs e)
        //{
        //    HoaDon hd = new HoaDon();
        //    hd.Show();
        //}

        //private void btnchitiethoadon_Click(object sender, EventArgs e)
        //{
        //    CHITIETHOADON ct = new CHITIETHOADON();
        //    ct.Show();
        //}

        //private void btnhanghoa_Click(object sender, EventArgs e)
        //{
        //    HangHoa hh = new HangHoa(user, pass, server, data);
        //    hh.Show();
        //}

        //private void btnloaihang_Click(object sender, EventArgs e)
        //{
        //    LoaiHang lh = new LoaiHang();
        //    lh.Show();
        //}

        //private void btnchitietpn_Click(object sender, EventArgs e)
        //{
        //    CHITIETPN ctpn = new CHITIETPN();
        //    ctpn.Show();
        //}

        //private void btnphieunhap_Click(object sender, EventArgs e)
        //{
        //    PHIEUNHAP pn = new PHIEUNHAP();
        //    pn.Show();
        //}

        //private void btnnhacc_Click(object sender, EventArgs e)
        //{
        //    NHACC ncc = new NHACC();
        //    ncc.Show();
        //}

        //private void btnnhanvien_Click(object sender, EventArgs e)
        //{
        //    NhanVien nv = new NhanVien();
        //    nv.Show();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ThongTinNhanVien ttnv = new ThongTinNhanVien();
        //    ttnv.Show();
        //}

        private void btnview_Click(object sender, EventArgs e)
        {
            NhanVienView nv = new NhanVienView(user, pass, server, data);
            nv.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachHangView kh = new KhachHangView(user, pass, server, data);
            kh.Show();
        }

        private void btnhoadonview_Click(object sender, EventArgs e)
        {
            HoaDonView hd = new HoaDonView(user, pass, server, data);
            hd.Show();
        }
    }   
}
