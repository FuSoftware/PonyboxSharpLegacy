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
    public partial class LoggerForm : Form
    {
        Logger logger;
        PonyboxClient client;
        string credentials;

        public LoggerForm()
        {
            InitializeComponent();

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
            logger = new Logger(cm.GetAdapter("SELECT * FROM Messages"),cm.GetAdapter("SELECT * FROM Users"));
            
            LoginForm frm = new LoginForm();

            string res = "";
            do
            {
                frm.ShowDialog();

                res = PonyboxClient.LoadUser(frm.GetUser(), frm.GetPass());
            } while (res == "");

            initCB(res);
        }

        public void initCB(string json)
        {
            this.credentials = json;

            client = new PonyboxClient();
            client.LoadUser(json);
            client.LoadChatbox();

            client.MessageRecieved += onMessageRecieved;
            client.MessagesRecieved += onMessagesRecieved;
            client.ChannelJoined += onChannelJoined;
            client.ChannelListRefreshed += onChannelListRefreshed;
            client.SocketConnectionStateChanged += onSocketConnectionStateChanged;

            client.RefreshChannelList();
        }

        public void onSocketConnectionStateChanged(object sender, PonyboxClient.SocketConnectionEvent e)
        {
            if(!e.isConnected)
            {
                Console.WriteLine("Chatbox disconnected");
                initCB(credentials);
            }
        }

        public void onChannelListRefreshed(object sender, PonyboxClient.ChannelListRefreshedEvent e)
        {
            List<Channel> channels = e.channels;
            var source = new AutoCompleteStringCollection();
            string[] names = new string[channels.Count];

            for(int i=0;i<channels.Count;i++)
            {
                names[i] = channels[i].GetName();

                client.JoinChannel(channels[i].GetName());
            }

            source.AddRange(names);

            textBoxChannel.Invoke((MethodInvoker)delegate
            {
                textBoxChannel.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxChannel.AutoCompleteCustomSource = source;
            });
        }

        public void onChannelJoined(object sender, PonyboxClient.ChannelJoinedEvent e)
        {
            listViewChannels.Invoke((MethodInvoker)delegate
            {
                listViewChannels.Items.Add(e.channel.GetName(), e.channel.GetName() + " (" + e.channel.GetLabel() + ")", 0);
            });
        }

        public void onMessageRecieved(object sender, Ponybox.Message m)
        {
            logger.LogMessage(m);
        }

        public void onMessagesRecieved(object sender, PonyboxClient.MessageListRecievedEvent m)
        {
            logger.LogMessages(m.messages);
            if(m.messages.Count > 0)
                client.GetOlderMessages(m.channel, m.messages[0].GetID());
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            client.JoinChannel(textBoxChannel.Text);
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            client.LeaveChannel(textBoxChannel.Text);
            listViewChannels.Invoke((MethodInvoker)delegate
            {
                listViewChannels.Items.RemoveByKey(textBoxChannel.Text);
            });
        }
    }
}
