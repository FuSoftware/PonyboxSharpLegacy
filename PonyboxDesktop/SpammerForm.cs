using Microsoft.Office.Interop.Excel;
using PonyboxDesktop.Ponybox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonyboxDesktop
{
    public partial class SpammerForm : Form
    {
        PonyboxClient[] clients;
        string credentials = "";
        List<Thread> threadPool = new List<Thread>();

        int connected = 0;
        int disconnected = 0;

        string csv = "";
        int timestamp=0;

        public SpammerForm()
        {
            InitializeComponent();

            /*
            LoginForm frm = new LoginForm();

            string res = "";
            do
            {
                frm.ShowDialog();

                res = PonyboxClient.LoadUser(frm.GetUser(), frm.GetPass());
            } while (res == "");

            this.credentials = res;
            */

            Thread t = new Thread(new ThreadStart((MethodInvoker)delegate
            {
                csv += "Time;" + "Connected;" + "Disconnected;" + "Running\n";
                while (true)
                {
                    csv += timestamp + ";" + connected + ";" + disconnected +";" + (connected - disconnected) +  "\n";
                    timestamp++;
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
        }

        public void initCB(string json, long count)
        {
            
            clients = new PonyboxClient[count];

            for (long i=0;i<count;i++)
            {
                clients[i] = new PonyboxClient();
                //clients[i].LoadUser(json);
                clients[i].LoadChatbox(false);
                clients[i].SocketConnectionStateChanged += onSocketConnectionStateChanged;
            }
        }

        public void onSocketConnectionStateChanged(object sender, PonyboxClient.SocketConnectionEvent e)
        {
            if (e.isConnected)
            {
                connected++;
                /*
                Thread t = new Thread(new ThreadStart((MethodInvoker)delegate
                {
                    while (true)
                    {
                        ((PonyboxClient)sender).SendMessage("rp", "message", "nightmane");
                        Thread.Sleep(100);
                    }
                        
                }));

                t.Start();

                threadPool.Add(t);
                */
            }
            else
            {
                disconnected++;
            }

            labelStarted.Invoke((MethodInvoker)delegate
            {
                labelStarted.Text = connected + " / " + disconnected + " (" + (connected - disconnected) + ")";
            });
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            initCB(this.credentials, (long)numericUpDownCount.Value);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart((MethodInvoker)delegate
            {
                string file = Path.GetTempPath() + timestamp + ".csv";
                string data = csv;
                File.Delete(file);
                File.WriteAllText(file, data);
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Open(file);
                excel.Visible = true;
            }));
            t.Start();
        }
    }
}
