using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuvaLinesVue.Models;

namespace SuvaLines.Models.ApiGetModels
{
    public class HomePageModel
    {
        public List<Articles> Politics { get; set; }
        public List<Articles> Business { get; set; }
        public List<Articles> World { get; set; }
        public List<Articles> Sports { get; set; }
        public List<Articles> Teach { get; set; }
        public List<Articles> Health { get; set; }
    }
}
