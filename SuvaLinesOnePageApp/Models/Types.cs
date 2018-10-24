using System;
using System.Collections.Generic;

namespace SuvaLinesOnePageApp.Models
{
    public partial class Types
    {
        public Types()
        {
            ArticlesGroup = new HashSet<Articles>();
            ArticlesStatus = new HashSet<Articles>();
            ArticlesVisible = new HashSet<Articles>();
            UsersStatus = new HashSet<Users>();
            UsersType = new HashSet<Users>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public string Desccription { get; set; }
        public int? GroupId { get; set; }
        public int? StatusId { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<Articles> ArticlesGroup { get; set; }
        public ICollection<Articles> ArticlesStatus { get; set; }
        public ICollection<Articles> ArticlesVisible { get; set; }
        public ICollection<Users> UsersStatus { get; set; }
        public ICollection<Users> UsersType { get; set; }
    }
}
