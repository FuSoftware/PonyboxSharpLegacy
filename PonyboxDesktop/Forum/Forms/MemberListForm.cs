using PonyboxDesktop.Ponybox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonyboxDesktop.Forum
{
    public partial class MemberListForm : Form
    {
        public MemberListForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            else
            {
                Application.Exit();
            }

            DBConnectionManager cm = new DBConnectionManager(path, "OleDb");
            AccountDatabase db = new AccountDatabase(cm.GetAdapter("SELECT * FROM Accounts"));

            ForumClient.Login("username", "password");
            List<ForumUser> u = ForumClient.GetFullUserList(25);
            Console.WriteLine("Storing " + u.Count + " users");
            db.LogUsers(u);
            MessageBox.Show("Process ended successfully");
        }
    }
}
