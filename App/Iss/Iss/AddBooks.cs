using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Iss
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBookName.Text != "" && textAuthor.Text !="" && textQuan.Text!="")
            {

                String bname = textBookName.Text;
                String bautor = textAuthor.Text;
                String bdate = dateTimePicker1.Text;
                Int64 bquan = Int64.Parse(textQuan.Text);

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server = localhost ; database=biblioteca ; user id=root; password= Hara6052!";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook(bname,bAuthor,bBDate,bQuan) values ('" + bname + "', '" + bautor + "', '" + bdate + "', " + bquan + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book stored", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBookName.Clear();
                textAuthor.Clear();
                textQuan.Clear();
            }
            else
            {
                MessageBox.Show("Empty fields not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
