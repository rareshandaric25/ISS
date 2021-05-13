using System;
using System.Windows.Forms;

namespace Iss
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks adbks = new AddBooks();
            adbks.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewBooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBooks vwbks = new ViewBooks();
            vwbks.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addstud = new AddUser();
            addstud.Show();
        }

        private void viewUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsers vwu = new ViewUsers();
            vwu.Show();
        }
    }
}
