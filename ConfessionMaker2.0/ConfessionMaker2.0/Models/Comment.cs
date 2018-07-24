using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfessionMaker2._0.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateTime { get; set; }
        public int UpVotes { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public List<CommentReply> CommentReplies { get; set; }
    }
}
