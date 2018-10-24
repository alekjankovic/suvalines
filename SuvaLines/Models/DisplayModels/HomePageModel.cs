using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuvaLines.Models.DisplayModels
{
    public class HomePageModel
    {
        public List<Articles> MainSection { get; set; }
        public List<Articles> Politics { get; set; }
        public List<Articles> Business { get; set; }
        public List<Articles> World { get; set; }
        public List<Articles> Sports { get; set; }
        public List<Articles> Teach { get; set; }
        public List<Articles> Health { get; set; }
    }
}
