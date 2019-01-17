using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SuvaLinesVue.Models.Interfaces;

namespace SuvaLinesVue.Models.EditModels
{

    public class CommentEditModel
    {
       
        public int CommentId { get; set; }

        [Required(ErrorMessage = "No article id sent.")]
        public int ArticleId { get; set; }

        public bool Approved { get; set; }

        [Required(ErrorMessage = "No username sent.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "No comment sent.")]
        public string CommentText { get; set; }


        public CommentEditModel()
        {
            

            CommentId = 0;
            ArticleId = 0;
            Approved = false;
            Username = "";
            CommentText = "";
        }

        public CommentEditModel(Comments Comment)
        {
  
            if (Comment == null)
                throw new NoNullAllowedException("Null not allowed");

            CommentId = 0;
            ArticleId = Comment.ArticleId;
            Approved = false;
            Username = Comment.Username;
            CommentText = Comment.CommentText;
        }

        public bool SaveChanges() {

            Comments model = new Comments();

            model.CommentId = 0;
            model.ArticleId = ArticleId;
            model.Approved = Approved;
            model.Username = Username;
            model.CommentText = CommentText;

            //var a = context.Comments.Add(model);
            //var result = context.SaveChanges();

            return true;





        }




        //public CommentEditModel(int id) {
        //    //var model = _context.Comments.FirstOrDefault(x=> x.CommentId == id);

        //    CommentId = model.CommentId;
        //    ArticleId = model.ArticleId;
        //    Approved = model.Approved;
        //    Username = model.Username;
        //    CommentText = model.CommentText;
        //}

        //public void SaveComment() {

        //    Comments getComment = default(Comments);
        //    try {
        //        getComment



        //    }
        //    catch (Exception e) {
        //    }




        //}








    }
}
