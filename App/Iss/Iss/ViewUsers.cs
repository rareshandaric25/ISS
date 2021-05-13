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
    public partial class ViewUsers : Form
    {
        public ViewUsers()
        {
            InitializeComponent();
        }

        private void textNameSearch_TextChanged(object sender, EventArgs e)
        {
            if(textNameSearch.Text != "")
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from user where lName LIKE '"+textNameSearch.Text+ "%' or fName LIKE '" + textNameSearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from user";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from user where usertype = 'User'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel1.Visible = true;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from user where userId="+bid+" ";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            textFName.Text = ds.Tables[0].Rows[0][1].ToString();
            textLName.Text = ds.Tables[0].Rows[0][2].ToString();
            textBDate.Text = ds.Tables[0].Rows[0][3].ToString();
            textCNP.Text = ds.Tables[0].Rows[0][4].ToString();
            textAdres.Text = ds.Tables[0].Rows[0][5].ToString();
            textPassword.Text = ds.Tables[0].Rows[0][6].ToString();
            textPhone.Text = ds.Tables[0].Rows[0][7].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this row?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String fname = textFName.Text;
                String lname = textLName.Text;
                String bdate = textBDate.Text;
                Int64 cnp = Int64.Parse(textCNP.Text);
                String adress = textAdres.Text;
                String password = textPassword.Text;
                Int64 phone = Int64.Parse(textPhone.Text);
                String username = textUsername.Text;

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update user set fName = '" + fname + "', lName = '" + lname + "', bDate= '" + bdate + "', CNP = " + cnp + ", adress = '"+adress+"', pass = '"+password+"', phone = "+phone+", username = '"+username+"' where userId=" + rowid + " ";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewUsers_Load(this, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from user where userId=" + rowid + " ";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewUsers_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textNameSearch.Clear();
            ViewUsers_Load(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
