using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfessionMaker2._0.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string PostContent { get; set; }
        public int UpVotes { get; set; }
        public DateTime DateTime { get; set; }


        public List<Comment> Comments { get; set; }

    }
}
