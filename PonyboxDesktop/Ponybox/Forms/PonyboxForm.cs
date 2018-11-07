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
    public partial class PonyboxForm : Form
    {
        PonyboxClient client;
        Channel currentChannel;

        Dictionary<string, ListView> channels = new Dictionary<string, ListView>();

        public PonyboxForm()
        {
            InitializeComponent();
            client = new PonyboxClient();

            /*
            LoginForm frm = new LoginForm();

            string res = "";
            do
            {
                frm.ShowDialog();

                res = PonyboxClient.LoadUser(frm.GetUser(), frm.GetPass());
            } while (res == "");
            client.LoadUser(res);
            */

            //client.SetUserData(542, "9fa06f4fe6183864037435842e646a5b92133c34"); Mitaka


            client.LoadChatbox();
            client.Connect();

            client.BindForm(this);
            client.BindMessageListCallback("UpdateMessages");
            client.BindMessageInsertCallback("InsertMessage");
            client.BindChannelListCallback("UpdateChannels");

            client.RefreshChannelList();
            client.JoinChannel("general");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //client.SendMessage("general", textBoxMessage.Text, textBoxPM.Text);
            //client.SendMessage(currentChannel.GetName(), textBoxMessage.Text, textBoxPM.Text);
            textBoxMessage.Text = "";
        }

        public void UpdateChannels()
        {
            List<Channel> channels = client.GetChannelList();

            ((ToolStripMenuItem)contextMenuStripChannels.Items[0]).DropDownItems.Clear();
            //contextMenuStripChannels.Invoke((MethodInvoker)delegate { ((ToolStripMenuItem)contextMenuStripChannels.Items[0]).DropDownItems.Clear(); });
            for(int i=0;i<channels.Count;i++)
            {
                Channel c = channels[i];
                ((ToolStripMenuItem)contextMenuStripChannels.Items[0]).DropDownItems.Add(c.GetLabel());
                ((ToolStripMenuItem)contextMenuStripChannels.Items[0]).DropDownItems[i].Tag = c.GetName();
                ((ToolStripMenuItem)contextMenuStripChannels.Items[0]).DropDownItems[i].Click += JoinChannel;
                //contextMenuStripChannels.Invoke((MethodInvoker)delegate{((ToolStripMenuItem)contextMenuStripChannels.Items[0]).DropDownItems.Add(c.GetLabel());});
            }
        }

        public void InsertMessage(string channel)
        {
            Ponybox.Message m = client.GetMessages(channel).Last();
            string[] items = new string[3] { m.GetSender().GetUsername(), m.GetMessage(), Functions.UnixTimeStampToDateTime(m.GetTimestamp()).ToString("yyy-MM-dd hh:mm:ss") };
            ListViewItem lvi = new ListViewItem(items);
            channels[channel].Invoke((MethodInvoker)delegate
            {
                channels[channel].Items.Add(lvi);
            });
        }

        public void UpdateMessages(string channel)
        {
            Console.WriteLine("Updating Message List");
            List<Ponybox.Message> messages = client.GetMessages(channel);

            if (channels.Count == 0 || !channels.ContainsKey(channel))
            {
                CreateChannelTab(client.GetChannelList()[0]);
            }

            channels[channel].Invoke((MethodInvoker)delegate{ channels[channel].Items.Clear();});

            foreach(Ponybox.Message m in messages)
            {
                string[] items = new string[3] { m.GetSender().GetUsername() , m.GetMessage(), Functions.UnixTimeStampToDateTime(m.GetTimestamp()).ToString("yyy-MM-dd hh:mm:ss") };
                ListViewItem lvi = new ListViewItem(items);
                channels[channel].Invoke((MethodInvoker)delegate
                {
                    channels[channel].Items.Add(lvi);
                });
            }

            channels[channel].Invoke((MethodInvoker)delegate
            {
                channels[channel].Items[channels[channel].Items.Count - 1].EnsureVisible();
            });
        }

        public void CreateChannelTab(Channel c)
        {
            tabControlChannels.Invoke((MethodInvoker)delegate
            {
                ListView lv = new ListView();
                lv.Columns.Add("User");
                lv.Columns.Add("Message");
                lv.Columns.Add("Heure");
                lv.View = View.Details;
                lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                tabControlChannels.TabPages.Add(c.GetName(),c.GetLabel());
                tabControlChannels.TabPages[c.GetName()].Controls.Add(lv);
                lv.Dock = DockStyle.Fill;
                channels.Add(c.GetName(), lv);
            });

            this.currentChannel = c;
        }

        public void JoinChannel(Channel c)
        {
            CreateChannelTab(c);
            client.JoinChannel(c.GetName());
            this.currentChannel = c;
        }

        private void comboBoxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
                        
        }

        private void JoinChannel(object sender, EventArgs e)
        {
            JoinChannel(client.GetChannel((string)((ToolStripMenuItem)sender).Tag));
        }

        private void leaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.LeaveChannel(currentChannel.GetName());
            tabControlChannels.Invoke((MethodInvoker)delegate
            {
                tabControlChannels.TabPages.Remove(tabControlChannels.TabPages[currentChannel.GetName()]);
            });

            channels.Remove(currentChannel.GetName());
        }

        private void tabControlChannels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
