using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iss
{
    public partial class ViewBooksUser : Form
    {
        public ViewBooksUser()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewBooksUser_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel1.Visible = true;

            
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to borrow this book?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String username = textUsername.Text;
                String password = textPass.Text;
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                if (textUsername.Text != "" && textQuan.Text != "")
                {

                    cmd.CommandText = "select * from user where username='" + username + "' and pass='" + password + "' ";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        int userId = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                        cmd.CommandText = "select * from NewBook where bookId= " + bid + "";
                        MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                        DataSet ds1 = new DataSet();
                        da.Fill(ds1);

                        String bookName = ds1.Tables[0].Rows[0]["bName"].ToString();
                        Int64 quan = Int64.Parse(textQuan.Text);
                        Int64 bquan = Int64.Parse(ds1.Tables[0].Rows[0]["bquan"].ToString());

                        Int64 totalQuan = bquan - quan;

                        if (totalQuan >= 0)
                        {
                            con.Open();
                            cmd.CommandText = "insert into borrowedBooks(userId,bookId,username,bookName,quantity) values (" + userId + ", " + bid + ", '" + username + "', '" + bookName + "', " + quan + ")";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Book(s) borrowed", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textUsername.Clear();
                            textPass.Clear();
                            textQuan.Clear();

                            con.Open();
                            cmd.CommandText = "update NewBook set bQuan = " + totalQuan + " where bookId = " + bid + " ";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            ViewBooksUser_Load(this, null);
                        }
                        else
                        {
                            MessageBox.Show("Not enough books", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty fields not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
