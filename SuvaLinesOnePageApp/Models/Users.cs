using System;
using System.Collections.Generic;

namespace SuvaLinesOnePageApp.Models
{
    public partial class Users
    {
        public Users()
        {
            Articles = new HashSet<Articles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int? StatusId { get; set; }
        public int? TypeId { get; set; }
        public int? ProfileId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Types Status { get; set; }
        public Types Type { get; set; }
        public Profiles Profiles { get; set; }
        public ICollection<Articles> Articles { get; set; }
    }
}
