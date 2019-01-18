using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuvaLinesVue.Models.EditModels
{
    public class SuvaEditModel
    {
        private readonly SuvaLinesContext _context;

        SuvaEditModel(SuvaLinesContext context) {
            _context = context;       
        }

    }
}
