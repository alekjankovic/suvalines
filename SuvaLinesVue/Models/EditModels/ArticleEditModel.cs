using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SuvaLines.Models.ApiGetModels;
using SuvaLinesVue.Models.Interfaces;

namespace SuvaLinesVue.Models.EditModels
{

    public class ArticleEditModel
    {
       
        public int ArticleId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string ArticleText { get; set; }

        public int GroupId { get; set; }

        public int VisibleId { get; set; }

        public int StatusId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string LongTitle { get; set; }
        
        public string ImgUrl { get; set; }


        SuvaLinesContext _context;

        public ArticleEditModel(SuvaLinesContext context)
        {
            _context = context;

            ArticleId = 0;
            UserId = 1;
            Title = "";
            ArticleText = "";
            GroupId = 10005;
            StatusId = 1;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            LongTitle = "";
            ImgUrl = "";
        }

        public ArticleEditModel(SuvaLinesContext context, PostArticleModel model)
        {
            _context = context;

            if (model == null)
                throw new NoNullAllowedException("Null not allowed");

            ArticleId = 0;
            UserId = 1;
            Title = model.Title;
            ArticleText = model.ArticleText;
            GroupId = model.GroupId;

            if (model.ArticleId == 0)
            {
                DateCreated = DateTime.Now;
            }
           
            DateUpdated = DateTime.Now;
            LongTitle = model.LongTitle;
            ImgUrl = model.ImgUrl;
        }

        public int AddNew() {

            Articles model = new Articles();
            model.ArticleId = 0;
            model.UserId = UserId;
            model.Title = Title.Length <= 30 ? Title : Title.Substring(0, 30);
            model.ArticleText = ArticleText;
            model.GroupId = GroupId;
            //model.VisibleId = VisibleId;
            //model.StatusId = StatusId;
            model.DateCreated = DateCreated;
            model.DateUpdated = DateUpdated;
            model.LongTitle = LongTitle.Length <= 128 ? LongTitle : LongTitle.Substring(0, 128);
            model.ImgUrl = ImgUrl;

            try
            {
                _context.Articles.Add(model);
                var result = _context.SaveChanges();

                return result;
            }
            catch (Exception ex) {
                var a = ex;
                return 1;
            }

        }




    }
}
