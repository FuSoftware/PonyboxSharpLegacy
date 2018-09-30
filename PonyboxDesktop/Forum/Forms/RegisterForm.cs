using PonyboxDesktop.Forum;
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

namespace PonyboxDesktop
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            MessageBox.Show(Environment.UserName + " / " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            MessageBox.Show(Environment.MachineName);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            ForumClient.GenerateTokens();

            /*
            bool ok = ForumClient.Register(textBox1.Text);

            if(!ok)
                MessageBox.Show("Registration failed");

            webBrowser1.DocumentText = ForumClient.last_res;
            */

        }
    }
}
