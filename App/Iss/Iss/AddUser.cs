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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textFName.Text != "" && textLName.Text != "" && textCNP.Text != "" && textAdress.Text != "" && textPassword.Text != "" && textPhone.Text != "")
            {
                String fname = textFName.Text;
                String lname = textLName.Text;
                String bDate = dateTimePicker1.Text;
                Int64 cnp = Int64.Parse(textCNP.Text);
                String adress = textAdress.Text;
                String password = textPassword.Text;
                Int64 phone = Int64.Parse(textPhone.Text);
                String username = textUsername.Text;
                String usertype = "User";

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into user(fname,lname,bDate,CNP,adress,pass,phone,username,usertype) values('" + fname + "', '" + lname + "', '" + bDate + "', " + cnp + ", '" + adress + "', '" + password + "', " + phone + ", '" + username + "', '" + usertype + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empty fields not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textFName.Clear();
            textLName.Clear();
            textCNP.Clear();
            textAdress.Clear();
            textPassword.Clear();
            textPhone.Clear();
        }
    }
}
