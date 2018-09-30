using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace PonyboxDesktop.Forum.Data
{
    class ForumSearchParser
    {
        Regex regexUID = new Regex("u=(.*)\" style");

        public List<ForumPost> ParsePage(string html)
        {
            List<ForumPost> Posts = new List<ForumPost>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            List<HtmlNode> posts = doc.DocumentNode
                .Descendants("div")
                .Where(d =>
                   d.Attributes.Contains("class")
                   &&
                   d.Attributes["class"].Value.Contains("vtouter")
                ).ToList();

            for(int i=0;i<posts.Count;i++)
            {
                Posts.Add(ParseSection(posts[i]));
            }

            return Posts;
        }

        public ForumPost ParseSection(HtmlNode node)
        {
            //Post ID
            long id = long.Parse(node.GetAttributeValue("id","p-1").Substring(1));

            //UID
            int user = int.Parse(regexUID.Match(node.Descendants("span")
                .Where(d =>
                   d.Attributes.Contains("class")
                   &&
                   d.Attributes["class"].Value.Contains("vtusername")
                ).ToArray()[0].InnerHtml).Groups[1].Value);

            //Inner Text
            string text = node.Descendants("div")
                .Where(d =>
                   d.Attributes.Contains("id")
                   &&
                   d.Attributes["id"].Value.Contains("postdiv" + id)
                ).ToArray()[0].InnerHtml;

            //Date
            string date = node.Descendants("span")
                .Where(d =>
                   d.Attributes.Contains("class")
                   &&
                   d.Attributes["class"].Value.Contains("vtdate")
                ).ToArray()[0].InnerText;

            //Topic ID
            int topic = -1;

            //Forum ID
            int forum = -1;

            return new ForumPost(id,user,text,date,topic,forum);
        }
    }
}
