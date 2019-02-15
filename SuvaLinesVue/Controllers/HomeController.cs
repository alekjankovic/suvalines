using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SuvaLines.Models.ApiGetModels;
using SuvaLinesVue.Models;
using SuvaLinesVue.Models.EditModels;
using SuvaLinesVue.Models.HelperModels;

namespace SuvaLinesVue.Controllers
{
    public class HomeController : Controller
    {
        SuvaLinesContext _context;

        public HomeController(SuvaLinesContext context) {
            _context = context;
        }

        [Route("")]
        [Route("Category/{id}")]
        [Route("Article/{id}")]
        [Route("Search")]
        [Route("AddNews")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/mainnewslist")]
        public IActionResult NewsList() {
            var model = _context.Articles.GroupBy(x => x.GroupId).Select(x => x.Last()).ToList();
            return Json(model);
        }

        [HttpGet]
        [Route("api/breakingnews")]
        public IActionResult BreakingNews()
        {
            var model = _context.Articles.GroupBy(x => x.GroupId).Select(x => x.Last()).ToList();
            return Json(model);
        }

        [HttpGet]
        [Route("api/seclines")]
        public IActionResult SecLines()
        {
            HomePageModel model = new HomePageModel();

            model.Politics = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == 10005).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Business = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == 10006).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.World = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == 10007).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Sports = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == 10008).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Teach = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == 10009).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Health = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == 10010).OrderByDescending(x => x.ArticleId).Take(5).ToList();

            return Json(model);
        }

        [HttpGet]
        [Route("api/category")]
        public IActionResult Category(int id)
        {

            List<Articles> model = _context.Articles.Include(x => x.Group).Where(x => x.GroupId == id).OrderByDescending(x => x.ArticleId).ToList();
            return Json(model);
        }

        [HttpGet]
        [Route("api/article")]
        public IActionResult Article(int id)
        {
            Articles model = _context.Articles.Include(x=> x.Comments).FirstOrDefault(x => x.ArticleId == id) ;
            return Json(model);
        }

        [HttpGet]
        [Route("api/search")]
        public IActionResult Search(string qSearch) {

            List<Articles> model = new List<Articles>();

            if (!string.IsNullOrEmpty(qSearch)) {
                model = _context.Articles.Where(x => x.Title.Contains(qSearch) || x.LongTitle.Contains(qSearch) || x.ArticleText.Contains(qSearch)).ToList();
            }  
            return Json(model);

        }

        [HttpPost]
        [Route("api/postcomment")]
        public HttpResponseMessage PostComment(Comments dataToPost)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            try
            {
                _context.Comments.Add(dataToPost);
                var result = _context.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex) {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }

        }

        [HttpPost]
        [Route("api/uploadimg")]
        public async Task<ActionResult> UploadImg(IFormFile image)
        {
            JsonResult result;

            if (image != null) {
                long size = image.Length;
                string newfilename = DateTime.Now.ToString("yyyy-MM-dd-") + image.FileName;

                var filePath = Environment.CurrentDirectory + "\\wwwroot\\img\\news_temp\\" + newfilename;
                
                try {
                    Stream fileContent = image.OpenReadStream();
                    using (var stream = new FileStream(filePath, FileMode.Create)) {
                        await image.CopyToAsync(stream);
                    }
                    newfilename = "/img/news_temp/" + newfilename;
                    result = new JsonResult(new { url = newfilename });
                    result.StatusCode = 200;
                    return Ok(result);
                } catch (Exception ex) {
                    result = new JsonResult(new { Message = "Error" });
                    result.StatusCode = 500;
                    return result;
                }         
            }
            result = new JsonResult(new { Message = "Error" });
            result.StatusCode = 500;
            return result;
        }

        [HttpPost]
        [Route("api/postarticle")]
        public HttpResponseMessage PostArticle(PostArticleModel dataToPost)
        {
            ArticleEditModel model = new ArticleEditModel(_context, dataToPost);
            model.AddNew();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }


        [HttpGet]
        [Route("api/types")]
        public IActionResult Types(int groupid)
        {
            List<Types> model = _context.Types.Where(x => x.GroupId == groupid).ToList();
            return Json(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
