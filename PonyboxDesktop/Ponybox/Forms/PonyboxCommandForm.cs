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
    public partial class PonyboxCommandForm : Form
    {
        PonyboxClient client;
        public PonyboxCommandForm()
        {
            InitializeComponent();

            client = new PonyboxClient();

            LoginForm frm = new LoginForm();

            string res = "";
            do
            {
                frm.ShowDialog();

                res = PonyboxClient.LoadUser(frm.GetUser(), frm.GetPass());
            } while (res == "");

            client.LoadUser(res);
            client.LoadChatbox();
            
        }

        private void buttonKick_Click(object sender, EventArgs e)
        {
            client.Kick((int)numericKick.Value);
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            client.LeaveChannel(textBoxChannel.Text);
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            client.JoinChannel(textBoxChannel.Text);
        }

        private void buttonListBans_Click(object sender, EventArgs e)
        {
            client.ListBans();
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            client.LockChannel(textBoxChannel.Text);
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            client.UnlockChannel(textBoxChannel.Text);
        }

        private void buttonOlderMessages_Click(object sender, EventArgs e)
        {
            client.GetOlderMessages(textBoxOlderMessages.Text, (long)numericUpDownOlderMessages.Value);
        }

        private void buttonDeban_Click(object sender, EventArgs e)
        {
            client.DebanUser((int)numericKick.Value);
        }
    }
}
