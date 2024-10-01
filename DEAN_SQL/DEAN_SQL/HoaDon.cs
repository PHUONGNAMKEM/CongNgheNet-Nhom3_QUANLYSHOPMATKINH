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
using DocumentFormat.OpenXml.Office2010.Drawing;

namespace DEAN_SQL
{
    public partial class HoaDon : Form
    {
        public string user, pass, server, data, connectionString;
        public HoaDon(string username, string password, string servername, string database)
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
        private void HoaDon_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            display();
            string[] str = new string[] { "Đang xử lý", "Đã giao", "Đã hủy" };
            foreach(string s in str)
            {
                cbotrangthai.Items.Add(s);
            }
        }
        public void display()
        {
            i = 0;
            lst_dl.Items.Clear();
            conn.Open();
            sql = @"EXEC HIENTHI_HOADON";
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

        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmahd.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txtngaylap.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            cbotrangthai.Text= lst_dl.SelectedItems[0].SubItems[2].Text;
            txtmakh.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
            txtmanv.Text = lst_dl.SelectedItems[0].SubItems[4].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmahd.TextLength != 0 )
            {
                try
                {
                    conn.Open();
                    sql = @"EXEC THEM_HOADON '"+txtmahd.Text.Trim() + "', '"+txtngaylap.Text.Trim()+"', N'"+cbotrangthai.Text.Trim() +"', '"+txtmakh.Text.Trim() +"', '"+txtmanv.Text.Trim() +"'";
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
                MessageBox.Show("Mã hóa đơn không được đễ trống", "Thông báo");
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"EXEC XOA_HOADON '"+txtmahd.Text.Trim() +"'";
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
            if(item!=null)
            {
                try
                {
                    conn.Open();
                    string sql = @"EXEC SUA_HOADON '" + txtmahd.Text.Trim() + "','" + txtngaylap.Text.Trim() + "', N'" + cbotrangthai.Text.Trim() + "', '" + txtmakh.Text.Trim() + "', '" + txtmanv.Text.Trim() + "', '" + item.SubItems[0].Text + "'";
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
            else
            {
                MessageBox.Show("Bạn hãy chọn một đối tượng cần sửa");
            }    
          
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmahd.Clear();
            txtmakh.Clear();
            txtmanv.Clear();
            txtngaylap.Clear();
            cbotrangthai.Text = "";
            display();
        }

    }
}
