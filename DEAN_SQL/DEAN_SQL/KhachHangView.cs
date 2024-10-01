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

namespace DEAN_SQL
{
    public partial class KhachHangView : Form
    {
        public string user, pass, server, data, connectionString;
        public KhachHangView(string username, string password, string servername, string database)
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
        private void KhachHangView_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            display();
        }
        public void display()
        {
            i = 0;
            lst_khachhang.Items.Clear();
            conn.Open();
            sql = @"EXEC HIENTHI_KHACHHANG_VIEW";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                lst_khachhang.Items.Add(read[0].ToString());
                lst_khachhang.Items[i].SubItems.Add(read[1].ToString());
                lst_khachhang.Items[i].SubItems.Add(read[2].ToString());
                lst_khachhang.Items[i].SubItems.Add(read[3].ToString());
                i++;
            }
            conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmakh.TextLength != 0 && txttenkh.TextLength != 0)
            {
                try
                {
                    conn.Open();
                    sql = @"EXEC THEM_KHACH_VIEW '"+txtmakh.Text.Trim()+"', N'"+txttenkh.Text.Trim() + "', N'"+txtdiachi.Text.Trim() + "', '"+txtdiachi.Text.Trim() + "'";
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
                MessageBox.Show("Tên khách và mã khách hàng không được đễ trống", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"EXEC XOA_KHACH_VIEW '"+txtmakh.Text.Trim() + "'";
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

        private void lst_khachhang_Click(object sender, EventArgs e)
        {
            txtmakh.Text = lst_khachhang.SelectedItems[0].SubItems[0].Text;
            txttenkh.Text = lst_khachhang.SelectedItems[0].SubItems[1].Text;
            txtdiachi.Text = lst_khachhang.SelectedItems[0].SubItems[2].Text;
            txtsodt.Text = lst_khachhang.SelectedItems[0].SubItems[3].Text;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            ListViewItem item = lst_khachhang.FocusedItem;
            if(item!=null)
            {
                try
                {
                    conn.Open();
                    sql = @"EXEC SUA_KHACHHANG_VIEW '" + txtmakh.Text.Trim() + "', N'" + txttenkh.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "', '" + txtsodt.Text.Trim() + "','" + item.SubItems[0].Text + "'";
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
            else MessageBox.Show("Bạn hãy chọn một đối tượng cần sửa");
            
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmakh.Clear();
            txttenkh.Clear();
            txtdiachi.Clear();
            txtsodt.Clear();
            display();
        }

    }
}
