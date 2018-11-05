﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuvaLines.Models.ApiGetModels;
using SuvaLinesVue.Models;
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
        /*Still need to figure out why is this working in Vue*/
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
            Articles model = _context.Articles.FirstOrDefault(x => x.ArticleId == id);
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
