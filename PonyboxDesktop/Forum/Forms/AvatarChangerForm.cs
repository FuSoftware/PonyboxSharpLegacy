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
    public partial class AvatarChangerForm : Form
    {
        AvatarChanger client;

        public AvatarChangerForm()
        {
            InitializeComponent();

            client = new AvatarChanger();
            LoginForm frm = new LoginForm();

            bool ok = false;

            do
            {
                frm.ShowDialog();
                ok = client.Login(frm.GetUser(), frm.GetPass());
            } while (!ok);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string html = client.ChangeAvatar(textBoxTimestamp.Text, textBoxToken.Text, textBoxUrl.Text);
            webBrowserMain.DocumentText = html;
        }
    }
}
