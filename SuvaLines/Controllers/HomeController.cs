using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuvaLines.Models;

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
            List<Articles> model = _context.Articles.ToList();
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
