using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuvaLines.Models;
using SuvaLines.Models.DisplayModels;

namespace SuvaLines.Controllers
{

    public class HomeController : Controller
    {
        NewsLinesContext _context;

        public HomeController(NewsLinesContext context) {

            _context = context;
        }


        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();

            model.Politics = _context.Articles.Where(x => x.GroupId == 10005).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Business = _context.Articles.Where(x => x.GroupId == 10006).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.World = _context.Articles.Where(x => x.GroupId == 10007).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Sports = _context.Articles.Where(x => x.GroupId == 10008).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Teach = _context.Articles.Where(x => x.GroupId == 10009).OrderByDescending(x => x.ArticleId).Take(5).ToList();
            model.Health = _context.Articles.Where(x => x.GroupId == 10010).OrderByDescending(x => x.ArticleId).Take(5).ToList();

            model.MainSection = _context.Articles.GroupBy(x => x.GroupId).Select(x => x.Last()).ToList();

            return View(model);
        }

        public IActionResult Article(int id)
        {
            if (id > 0)
            {
                Articles model = _context.Articles.FirstOrDefault(x => x.ArticleId == id);
                return View(model);
            }
            else {
                return RedirectToAction("Index");
            }
           
        }

          
        public IActionResult SecBlock()
        {
            List<Articles> model = _context.Articles.ToList();
            return Json(model);

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
    }
}
