using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonyboxDesktop.Forum.Forms
{
    public partial class SearchPageParserForm : Form
    {
        public SearchPageParserForm()
        {
            InitializeComponent();

            ForumClient.Login("username", "password");
            ForumClient.GetPosts("http://frenchy-ponies.fr/viewtopic.php?p=84036");
        }
    }
}
