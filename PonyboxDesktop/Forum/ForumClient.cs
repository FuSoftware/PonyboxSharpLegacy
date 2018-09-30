using HtmlAgilityPack;
using PonyboxDesktop.Forum;
using PonyboxDesktop.Forum.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Forum
{
    class ForumClient
    {
        public static string verif = "Les éléments marqués par une * sont des champs obligatoires du profil et doivent être remplis.";
        public static string url_register = "http://frenchy-ponies.fr/ucp.php?mode=register";
        public static string cb_login = "http://www.frenchy-ponies.fr/ucp.php?mode=login";
        public static string url_memberlist = "http://frenchy-ponies.fr/memberlist.php?start=";
        public static string url_new_topic = "http://frenchy-ponies.fr/posting.php?mode=post&f=";

        private static string token = "";
        private static string timestamp = "";

        public static string last_res;
        public static CookieAwareWebClient c = new CookieAwareWebClient();

        public static bool LoginClient(string username, string password, CookieAwareWebClient c)
        {
            string res = "";
            //c.CookieContainer.SetCookies(new Uri("http://frenchy-ponies.fr"), "phpbb_ma_sid=c7aca50b997055971562307c4be3d745;domain=.frenchy-ponies.fr;path =/");

            try
            {
                byte[] log_res = c.UploadValues(cb_login, "POST", new NameValueCollection()
                {
                    { "username", username },
                    { "password", password },
                    { "redirect", "index.php" },
                    { "login", "Connexion" },
                    { "sid", "2ae96431ff45f50313493d91f6956327" }
                });

                res = c.DownloadString("http://frenchy-ponies.fr/ponybox/pb-include.php");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception for " + username + "/" + password);
                Console.WriteLine(e.Message);
            }

            return (res.Length > 0);
        }

        public static bool Login(string username, string password)
        {
            string res = "";
            //c.CookieContainer.SetCookies(new Uri("http://frenchy-ponies.fr"), "phpbb_ma_sid=c7aca50b997055971562307c4be3d745;domain=.frenchy-ponies.fr;path =/");

            try
            {
                byte[] log_res = c.UploadValues(cb_login, "POST", new NameValueCollection()
                {
                    { "username", username },
                    { "password", password },
                    { "redirect", "index.php" },
                    { "login", "Connexion" },
                    { "sid", "2ae96431ff45f50313493d91f6956327" }
                });

                res = c.DownloadString("http://frenchy-ponies.fr/ponybox/pb-include.php");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception for " + username + "/" + password);
                Console.WriteLine(e.Message);
            }

            return (res.Length > 0);
        }

        public static void GenerateTokens()
        {
            c = new CookieAwareWebClient();

            HtmlNode.ElementsFlags.Remove("form");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(c.DownloadString(url_register));

            HtmlNode NodeRegister = doc.GetElementbyId("agreement");

            List<HtmlNode> inputs = NodeRegister.Descendants("input").ToList();

            string timestamp = "";
            string token = "";

            foreach (HtmlNode input in inputs)
            {
                if(input.GetAttributeValue("name","") == "form_token")
                {
                    token = input.GetAttributeValue("value", "");
                }
                else if (input.GetAttributeValue("name", "") == "creation_time")
                {
                    timestamp = input.GetAttributeValue("value", "");
                }
            }

            Console.WriteLine("Timestamp : " + timestamp + " | Token : " + token);

            LoadRegisterData(timestamp, token);            
        }

        public static void LoadRegisterData(string form_timestamp, string form_token)
        {
            byte[] log_res = c.UploadValues(url_register, "POST", new NameValueCollection()
            {
                { "agreed", "J’accepte ces conditions" },
                { "change_lang","" },
                { "creation_time", form_timestamp },
                { "form_token", form_token }
            });

            last_res = Encoding.Default.GetString(log_res);

            HtmlNode.ElementsFlags.Remove("form");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(last_res);

            HtmlNode NodeRegister = doc.GetElementbyId("register");

            List<HtmlNode> inputs = NodeRegister.Descendants("input").ToList();

            foreach (HtmlNode input in inputs)
            {
                if (input.GetAttributeValue("name", "") == "form_token")
                {
                    token = input.GetAttributeValue("value", "");
                }
                else if (input.GetAttributeValue("name", "") == "creation_time")
                {
                    timestamp = input.GetAttributeValue("value", "");
                }
            }

            Console.WriteLine("Timestamp : " + timestamp + " | Token : " + token);
        }

        public static bool Register(string username)
        {
            if (token == "" || timestamp == "")
            {
                Console.WriteLine("Tokens not generated");
                return false;
            }

            Random r = new Random();

            byte[] log_res = c.UploadValues(url_register, "POST", new NameValueCollection()
            {
                { "username", username },
                //{ "email", username + "@" + username + ".com" },
                //{ "email_confirm", username + "@" + username + ".com" },
                { "email", "jtdparanoia@gmail.com" },
                { "email_confirm", "jtdparanoia@gmail.com" },
                { "new_password", "0123456789" },
                { "password_confirm", "0123456789" },
                { "lang", "fr" },
                { "tz", "1" },
                { "website", "" },
                { "location", "TEST_BOT" },
                { "occupation", "TEST_BOT" },
                { "bday_day", ((int)(r.NextDouble()*27 + 1)).ToString() },
                { "bday_month", ((int)(r.NextDouble()*11 + 1)).ToString() },
                { "bday_year", "1967" },
                { "pf_sexe", "2" },
                { "pf_anti_robots", "2" },
                { "pf_cm", "" },
                { "xbox", "" },
                { "psn", "" },
                { "psnzone", "" },
                { "wii", "" },
                { "wiiurl", "" },
                { "steam", "" },
                { "steamid", "" },
                { "xfire", "" },
                { "xfireskin", "sh" },
                { "origin", "" },
                { "agreed", "true" },
                { "change_lang", "0" },
                { "submit", "Envoyer" },
                { "creation_time", timestamp },
                { "form_token", token }
            });

            last_res =  Encoding.Default.GetString(log_res);

            return !last_res.Contains(verif);
        }

        public static string PostTopic(int t, string subject, string message)
        {
            string url = url_new_topic + t;

            string res = c.DownloadString(url);

            HtmlNode.ElementsFlags.Remove("form");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(res);

            HtmlNode NodeRegister = doc.GetElementbyId("postform");

            List<HtmlNode> inputs = NodeRegister.Descendants("input").ToList();

            string token = "";
            string timestamp = "";

            foreach (HtmlNode input in inputs)
            {
                if (input.GetAttributeValue("name", "") == "form_token")
                {
                    token = input.GetAttributeValue("value", "");
                }
                else if (input.GetAttributeValue("name", "") == "creation_time")
                {
                    timestamp = input.GetAttributeValue("value", "");
                }
            }

            byte[] log_res = c.UploadValues(url, "POST", new NameValueCollection()
            {
                { "subject", subject },
                { "abbc3_font", ""},
                { "abbc3_size", ""},
                { "abbc3_highlight", ""},
                { "helpbox", ""},
                { "form_token" , token },
                { "creation_time" , timestamp },
                { "message", message },
                { "notify", "on" },
                { "attach_sig", "on" },
                { "post", "Envoyer" }
            });

            return Encoding.Default.GetString(log_res);
        }
        
        public static List<ForumUser> GetFullUserList(int pageLimit)
        {
            List<ForumUser> res = new List<ForumUser>();
            List<ForumUser> buf = new List<ForumUser>();
            int page = 0;
            do
            {
                buf = GetUserList(page, pageLimit);
                res.AddRange(buf);
                page++;
                Console.WriteLine("Loading Page " + page);
            } while (buf.Count == 25);

            return res;
        }

        public static List<ForumUser> GetUserList(int page, int limit)
        {
            int start = page * limit;
            List<ForumUser> users = new List<ForumUser>();

            string res = c.DownloadString(url_memberlist + start);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(res);

            HtmlNode NodeTable = doc.GetElementbyId("memberlist");

            List<HtmlNode> rows = NodeTable.Descendants("tr").ToList();

            foreach (HtmlNode row in rows)
            {
                if(row.Descendants("td").ToList().Count > 0)
                {
                    users.Add(new ForumUser(row));
                }  
            }

            return users;
        }

        public static void GetPosts(string url)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ForumSearchParser f = new ForumSearchParser();
            string html = c.DownloadString(url);
            sw.Stop();
            f.ParsePage(html);
            Console.WriteLine("Processed page in " + sw.ElapsedMilliseconds +" ms");
        }

        private static string[] old_months = new string[12] { "Jan", "Fév", "Mar", "Avr", "Mai", "Juin", "Juil", "Aoû", "Sep", "Oct", "Nov", "Déc" };
        private static string[] months = new string[12] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };

        public static string FixDate(string s)
        {
            for (int i = 0; i < 12; i++)
            {
                if (s.Contains(old_months[i]))
                {
                    return s.Replace(old_months[i], months[i]);
                }
            }

            return "";
        }

        public static string FixHTML(string s)
        {
            string res = "";
            res = s.Replace("&nbsp;", "");
            res = res.Replace("Ã©", "é");
            res = res.Replace("Ã»", "û");
            return res;
        }

    }
}
