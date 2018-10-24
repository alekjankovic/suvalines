using System;
using System.Collections.Generic;

namespace SuvaLinesSPA.Models
{
    public partial class Profiles
    {
        public int ProfileId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte? Age { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Users User { get; set; }
    }
}
