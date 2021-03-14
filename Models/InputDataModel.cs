using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static search_from_archive.Controllers.SearchController;

namespace search_from_archive.Models
{
    public class InputDataModel
    {
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public SearchTarget Target { get; set; }

    }
}
