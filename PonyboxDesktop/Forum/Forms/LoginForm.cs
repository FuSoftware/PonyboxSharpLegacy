using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonyboxDesktop
{
    public partial class LoginForm : Form
    {
        string user;
        string pass;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonConnecter_Click(object sender, EventArgs e)
        {
            user = textBoxUser.Text;
            pass = textBoxPass.Text;
            this.Close();
        }

        public string GetUser()
        {
            return this.user;
        }

        public string GetPass()
        {
            return this.pass;
        }
    }
}
