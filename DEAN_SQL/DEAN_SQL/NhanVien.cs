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
    public partial class NhanVien : Form
    {
        public string user, pass, server, data, connectionString;
        public NhanVien(string username, string password, string servername, string database)
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
        private void NhanVien_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            display();
        }
        public void display()
        {
            i = 0;
            lst_dl.Items.Clear();
            conn.Open();
            sql = @"EXEC HIENTHI_NHANVIEN";
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

        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmanv.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txttennv.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtchucvu.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txtnguoiql.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmanv.TextLength != 0)
            {
                try
                {
                    conn.Open();
                    sql = @"EXEC THEM_NHANVIEN '"+txtmanv.Text.Trim() +"', N'"+txttennv.Text.Trim() +"', N'"+txtchucvu.Text.Trim() +"', '"+txtnguoiql.Text.Trim() +"'";
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
                MessageBox.Show("Mã nhân viên không được đễ trống", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"EXEC XOA_NHANVIEN '"+txtmanv.Text.Trim() +"'";
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
                    string sql = @"EXEC SUA_NHANVIEN '" + txtmanv.Text.Trim() + "', N'" + txttennv.Text.Trim() + "', N'" + txtchucvu.Text.Trim() + "', '" + txtnguoiql.Text.Trim() + "', '" + item.SubItems[0].Text + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MANV", txtmanv.Text.Trim());
                        cmd.Parameters.AddWithValue("@TENNV", txttennv.Text.Trim());
                        cmd.Parameters.AddWithValue("@CHUCVU", txtchucvu.Text.Trim());
                        cmd.Parameters.AddWithValue("@MANV_QUANLY", txtnguoiql.Text.Trim());
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
            else MessageBox.Show("Bạn hãy chọn một đối tượng cần sửa");

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtchucvu.Clear();
            txtmanv.Clear();
            txtnguoiql.Clear();
            txttennv.Clear();
            display();
        }


    }
}
