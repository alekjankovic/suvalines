using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuvaLinesVue.Models.Interfaces
{
    public  class EditModel
    {
        public SuvaLinesContext context;

        EditModel(SuvaLinesContext _context) {
            context = _context;
        }
    }
}
