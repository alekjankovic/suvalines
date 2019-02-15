using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuvaLinesVue.Models;

namespace SuvaLines.Models.ApiGetModels
{
    public class PostArticleModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public int GroupId { get; set; }
        public bool Visible { get; set; }
        public string LongTitle { get; set; }
        public string ImgUrl { get; set; }
    }
}
