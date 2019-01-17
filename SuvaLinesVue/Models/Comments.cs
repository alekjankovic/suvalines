using System;
using System.Collections.Generic;

namespace SuvaLinesVue.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public bool Approved { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }

        public Articles Article { get; set; }
    }
}
