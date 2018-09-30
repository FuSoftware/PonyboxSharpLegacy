using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Forum.Data
{
    class ForumPost
    {
        public long Id { get; set; }
        public int User { get; set; }
        public string Text { get; set; }
        public DateTime DatePost { get; set; }

        public long TopicID { get; set; }
        public long ForumID { get; set; }

        public ForumPost(long id, int user, string text, string datestring, int topicid, int forumid)
        {
            Text = text;
            User = user;
            Id = id;
            TopicID = topicid;
            ForumID = forumid;
            DatePost = DateTime.Parse(ForumClient.FixDate(ForumClient.FixHTML(datestring)));
        }
    }
}
