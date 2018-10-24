using System;
using System.Collections.Generic;

namespace SuvaLines.Models
{
    public partial class Articles
    {
        public int ArticleId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public int? GroupId { get; set; }
        public int? VisibleId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string LongTitle { get; set; }
        public string ImgUrl { get; set; }

        public Types Group { get; set; }
        public Types Status { get; set; }
        public Users User { get; set; }
        public Types Visible { get; set; }
    }
}
