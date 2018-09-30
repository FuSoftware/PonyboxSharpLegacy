using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Forum
{
    class ForumUser
    {
        public int Id { get; set; }
        public string Rank { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public string LastLoginString { get; set; }
        public string RegisterDateString { get; set; }
        public int Messages { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime LoginDate { get; set; }

        public ForumUser(HtmlNode root)
        {
            List<HtmlNode> columns = root.Descendants("td").ToList();

            Id = int.Parse(ForumClient.FixHTML(columns[0].InnerText));

            Rank = ForumClient.FixHTML(columns[2].Descendants("span").ToArray()[0].InnerText);
            Name = ForumClient.FixHTML(columns[2].Descendants("a").ToArray()[0].InnerText);

            if (columns[2].Descendants("a").ToArray()[0].Attributes.Contains("style"))
                Color = ForumClient.FixHTML(columns[2].Descendants("a").ToArray()[0].Attributes["style"].Value.Replace("color: ", "").Replace(";",""));
            else
                Color = "#";

            Messages = int.Parse(ForumClient.FixHTML(columns[3].InnerText));

            if (columns[4].Descendants("a").ToArray().Length > 0)
                Website = ForumClient.FixHTML(columns[4].Descendants("a").ToArray()[0].InnerText);
            else
                Website = "";

            Location = ForumClient.FixHTML(columns[4].InnerText);

            if (Website != "" && Location != "")
                Location = Location.Replace(Website, "");

            RegisterDateString = ForumClient.FixHTML(columns[5].InnerText);

            LastLoginString = ForumClient.FixHTML(columns[6].InnerText);

            RegisterDate = DateTime.Parse(ForumClient.FixDate(RegisterDateString));

            if (LastLoginString == " - ")
                LoginDate = DateTime.MinValue;
            else
                LoginDate = DateTime.Parse(ForumClient.FixDate(LastLoginString));
        }        
    }
}
