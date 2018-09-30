using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonyboxDesktop.Forum.Forms
{
    public partial class PostTopicForm : Form
    {
        public PostTopicForm()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            bool ok = ForumClient.Login(textBoxUsername.Text, textBoxPassword.Text);

            if(ok)
            {
                string s = ForumClient.PostTopic((int)numericUpDownSection.Value, textBoxSubject.Text, textBoxMessage.Text);
                webBrowserMain.DocumentText = s;
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}
