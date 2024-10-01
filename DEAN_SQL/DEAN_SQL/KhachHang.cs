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
    public partial class KhachHang : Form
    {
        public string user, pass, server, data, connectionString;
        public KhachHang(string username, string password, string servername, string database)
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            display();
        }
        public void display()
        {
            i = 0;
            lst_khachhang.Items.Clear();
            conn.Open();
            sql = @"EXEC DISPLAY_KHACHHANG";
            cmd = new SqlCommand(sql, conn);
            read = cmd.ExecuteReader();
            while(read.Read())
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
            if(txtmakh.TextLength!=0 && txttenkh.TextLength!=0)
            {
                try
                {
                    conn.Open();
                    sql = @"EXEC INSERT_KHACHHANG'" + txtmakh.Text + "', N'" + txttenkh.Text + "', N'" + txtdiachi.Text + "', '" + txtsodt.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    display();
                }
                catch(Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Lỗi "+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên khách và mã khách hàng không được đễ trống", "Thông báo");
            }

            
    
        }

        private void lst_khachhang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lst_khachhang_Click(object sender, EventArgs e)
        {
            txtmakh.Text = lst_khachhang.SelectedItems[0].SubItems[0].Text;
            txttenkh.Text = lst_khachhang.SelectedItems[0].SubItems[1].Text;
            txtdiachi.Text = lst_khachhang.SelectedItems[0].SubItems[2].Text;
            txtsodt.Text = lst_khachhang.SelectedItems[0].SubItems[3].Text;
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"EXEC DELETE_KHACHHANG '" + txtmakh.Text + "'";
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmakh.Clear();
            txttenkh.Clear();
            txtdiachi.Clear();
            txtsodt.Clear();
            display();
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            ListViewItem item = lst_khachhang.FocusedItem;
            try
            {
                conn.Open();
                sql = @"EXEC UPDATE_KHACHHANG '" + item.SubItems[0].Text + "', '" + txtmakh.Text + "', N'" + txttenkh.Text + "', N'" + txtdiachi.Text + "', '" + txtsodt.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                display();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
