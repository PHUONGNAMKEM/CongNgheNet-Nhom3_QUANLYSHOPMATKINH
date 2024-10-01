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
    public partial class CHITIETHOADON : Form
    {
        public string user, pass, server, data, connectionString;
        public CHITIETHOADON(string username, string password, string servername, string database)
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
        private void CHITIETHOADON_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            display();
        }
        public void display()
        {
            i = 0;
            lst_dl.Items.Clear();
            conn.Open();
            //sql = @"SELECT * FROM CHITIETHOADON";
            sql = @"EXEC HIENTHI_CHITIETHOADON";
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
            txtmahd.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txtmahg.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtsoluong.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txtgiaban.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmahd.TextLength != 0)
            {
                try
                {
                    conn.Open();
                    //sql = @"INSERT INTO CHITIETHOADON(MAHD, MAHG, SOLUONG, GIABAN) VALUES('" + txtmahd.Text.Trim() + "','" + txtmahg.Text.Trim() + "',N'" + txtsoluong.Text.Trim() + "','" + txtgiaban.Text.Trim() + "')";
                    sql = @"EXEC THEM_CHITIETHOADON '" + txtmahd.Text.Trim() + "', '" + txtmahg.Text.Trim() + "', " + txtsoluong.Text.Trim() + ", " + txtgiaban.Text.Trim() + "";
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
                //sql = @"DELETE FROM CHITIETHOADON WHERE MAHD = '" + txtmahd.Text.Trim() + "' AND MAHG = '"+txtmahg.Text.Trim()+"'";
                sql = @"EXEC XOA_CHITIETHOADON '" + txtmahd.Text.Trim() + "', '" + txtmahg.Text.Trim() + "'";
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
            try
            {
                conn.Open();
                //string sql = @"UPDATE CHITIETHOADON SET MAHD = @MAHD, MAHG = @MAHG, SOLUONG = @SOLUONG, GIABAN = @GIABAN WHERE MAHD = @MAHD AND MAHG = '" + item.SubItems[0].Text+ "'";
                string sql = @"EXEC SUA_CHITIETHOADON '" + txtmahd.Text.Trim() + "', '" + txtmahg.Text.Trim() + "'," + txtsoluong.Text.Trim() + "," + txtgiaban.Text.Trim() + ", '" + item.SubItems[0].Text.Trim() + "', '" + item.SubItems[1].Text.Trim() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MAHD", txtmahd.Text.Trim());
                    cmd.Parameters.AddWithValue("@MAHG", txtmahg.Text.Trim());
                    cmd.Parameters.AddWithValue("@SOLUONG", txtsoluong.Text.Trim());
                    cmd.Parameters.AddWithValue("@GIABAN", txtgiaban.Text.Trim());
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtgiaban.Clear();
            txtmahd.Clear();
            txtmahg.Clear();
            txtsoluong.Clear();
        }

    }
}
