using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Iss
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            
        } 
        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from user where username='"+txtUser.Text+"' and pass='"+txtPassword.Text+"' ";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if(ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i< ds.Tables[0].Rows.Count; i++)
                {
                    if(ds.Tables[0].Rows[i]["usertype"].ToString() == cmbItemValue)
                    {
                        if(comboBox1.SelectedIndex == 0)
                        {
                            this.Hide();
                            frmHome frmHome = new frmHome();
                            frmHome.Show();
                        }
                        else
                        {
                            this.Hide();
                            frmUser frmUser = new frmUser();
                            frmUser.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect type user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister register = new frmRegister();
            register.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
