using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfessionMaker2._0.Models
{
    public class CommentReply
    {
        public int Id { get; set; }

        public string Reply { get; set; }
        public int UpVotes { get; set; }

        public DateTime DateTime { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

    }
}
