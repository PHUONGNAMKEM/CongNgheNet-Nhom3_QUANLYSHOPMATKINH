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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class HangHoa : Form
    {
        public string user, pass, server, data, connectionString;
        public HangHoa(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            connectionString = "Server=" + server + ";Database=" + data + ";User Id=" + user + ";Password=" + pass + ";";
        } 
    
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader read;
        int i = 0;
        string sql;
        private void HangHoa_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            display();
        }
        public void display()
        {
            i = 0;
            lst_dl.Items.Clear();
            conn.Open();
            //sql = @"EXEC HIENTHI_HANGHOA";
            sql = @"EXEC DISPLAY_HANGHOA";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                lst_dl.Items.Add(read[0].ToString());
                lst_dl.Items[i].SubItems.Add(read[1].ToString());
                lst_dl.Items[i].SubItems.Add(read[2].ToString());
                lst_dl.Items[i].SubItems.Add(read[3].ToString());
                i++;
            }
            conn.Close();
        }
        public void display_1()
        {
            i = 0;
            lst_dl.Items.Clear();
            conn.Open();
            //sql = @"EXEC HANG_CHUA_BAN";
            sql = @"EXEC HANG_CHUA_BAN";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                lst_dl.Items.Add(read[0].ToString());
                lst_dl.Items[i].SubItems.Add(read[1].ToString());
                lst_dl.Items[i].SubItems.Add(read[2].ToString());
                lst_dl.Items[i].SubItems.Add(read[3].ToString());
                lst_dl.Items[i].SubItems.Add(read[4].ToString());
                i++;
            }
            conn.Close();
        }
        public void display_2()
        {
            i = 0;
            lst_dl.Items.Clear();
            conn.Open();
            //sql = @"EXEC HANG_BAN_CHAY_NHAT";
            sql = @"EXEC HANG_BAN_CHAY_NHAT";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                lst_dl.Items.Add(read[0].ToString());
                lst_dl.Items[i].SubItems.Add(read[1].ToString());
                lst_dl.Items[i].SubItems.Add(read[2].ToString());
                lst_dl.Items[i].SubItems.Add(read[3].ToString());
                lst_dl.Items[i].SubItems.Add("");
                lst_dl.Items[i].SubItems.Add(read[4].ToString());
                i++;
            }
            conn.Close();
        }

        public void display_3()
        {
            int tongSoLuongChuaBan = 0;

            // Mở kết nối đến SQL Server
            conn.Open();

            // Khởi tạo SqlCommand và đặt thủ tục cần gọi
            SqlCommand cmd = new SqlCommand("HANG_CHUA_BAN_VA_TONG", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Khai báo tham số OUTPUT trong C#
            SqlParameter outputParam = new SqlParameter();
            outputParam.ParameterName = "@TongSoLuongChuaBan";
            outputParam.SqlDbType = SqlDbType.Int;
            outputParam.Direction = ParameterDirection.Output;

            // Thêm tham số OUTPUT vào SqlCommand
            cmd.Parameters.Add(outputParam);

            // Đọc dữ liệu của hàng chưa bán
            SqlDataReader read = cmd.ExecuteReader();
            int i = 0;
            lst_dl.Items.Clear();
            while (read.Read())
            {
                lst_dl.Items.Add(read[0].ToString());
                lst_dl.Items[i].SubItems.Add(read[1].ToString());
                lst_dl.Items[i].SubItems.Add(read[2].ToString());
                lst_dl.Items[i].SubItems.Add(read[3].ToString());
                lst_dl.Items[i].SubItems.Add(read[4].ToString());
                i++;
            }
            read.Close();

            // Lấy giá trị của tham số OUTPUT
            tongSoLuongChuaBan = (int)cmd.Parameters["@TongSoLuongChuaBan"].Value;

            // Hiển thị tổng số lượng hàng chưa bán ra màn hình hoặc gán vào nhãn (label)
            MessageBox.Show("Tổng số lượng hàng chưa bán: " + tongSoLuongChuaBan);

            // Đóng kết nối
            conn.Close();
        }



        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmahg.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txttenhang.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtdvt.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txtmaloai.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmahg.TextLength != 0)
            {
                try
                {
                    conn.Open();
                    //sql = @"EXEC THEM_HANGHOA '" + txtmahg.Text.Trim()+"', N'"+txttenhang.Text.Trim()+"', N'"+txtdvt.Text.Trim() + "', '"+txtmaloai.Text.Trim() + "'";
                    sql = @"EXEC INSERT_HANGHOA '" + txtmahg.Text.Trim() + "',N'" + txttenhang.Text.Trim() + "',N'" + txtdvt.Text.Trim() + "','" + txtmaloai.Text.Trim() + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    display();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã hàng không được đễ trống", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                //sql = @"EXEC XOA_HANGHOA '"+txtmahg.Text+"'";
                sql = @"EXEC DELETE_HANGHOA '" + txtmahg.Text.Trim() + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                display();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            ListViewItem item = lst_dl.FocusedItem;
            if (item != null)
            {
                try
                {
                    conn.Open();
                    //string sql = @"EXEC SUA_HANGHOA '"+ txtmahg.Text.Trim() + "', N'@"+ txttenhang.Text.Trim() + "', N'"+ txtdvt.Text.Trim() + "', '"+ txtmaloai.Text.Trim() + "', '" + item.SubItems[0].Text + "'";
                    string sql = @"EXEC UPDATE_HANGHOA '" + item.SubItems[0].Text + "','" + txtmahg.Text.Trim() + "',N'" + txttenhang.Text.Trim() + "',N'" + txtdvt.Text.Trim() + "','" + txtmaloai.Text.Trim() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    display();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Bạn hãy chọn một đối tưởng để sửa");
         
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmahg.Clear();
            txttenhang.Clear();
            txtdvt.Clear();
            txtmaloai.Clear();
            display();
        }

        private void btnhangchuaban_Click(object sender, EventArgs e)
        {
            display_3();
        }

        private void btnhangbanchaynhat_Click(object sender, EventArgs e)
        {
            display_2();
        }
    }
}
