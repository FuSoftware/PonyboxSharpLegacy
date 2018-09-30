using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Ponybox
{
    class AvatarChanger
    {
        CookieAwareWebClient client;

        static string cb_login = "http://www.frenchy-ponies.fr/ucp.php?mode=login";
        static string cb_avatar = "http://frenchy-ponies.fr/ucp.php?i=profile&mode=avatar";

        public AvatarChanger()
        {

        }

        public bool Login(string username, string password)
        {
            client = new CookieAwareWebClient();

            byte[] log_res = client.UploadValues(cb_login, "POST", new NameValueCollection()
            {
                { "username", username },
                { "password", password },
                { "redirect", "index.php" },
                { "login", "Connexion" },
                { "sid", "2ae96431ff45f50313493d91f6956327" }
            });

            //CB Credentials
            string res = client.DownloadString("http://frenchy-ponies.fr/ponybox/pb-include.php");

            return (res != "");
        }

        public string ChangeAvatar(string creation_time, string form_token, string url)
        {
            byte[] log_res = client.UploadValues(cb_avatar, "POST", new NameValueCollection()
            {
                { "creation_time", creation_time },
                { "form_token", form_token },
                //{ "delete", "0" },
                { "MAX_FILE_SIZE", "200000" },
                //{ "uploadfile", "" },
                //{ "uploadurl", "" },
                { "remotelink", url },
                { "width", "170" },
                { "height", "170" }
            });

            return System.Text.Encoding.UTF8.GetString(log_res);
        }
    }
}
