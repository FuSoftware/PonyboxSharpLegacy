using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Forum.Data
{
    class ForumTopic
    {
        public List<ForumPost> Posts = new List<ForumPost>();
        public string Name { get; set; }
    }
}
