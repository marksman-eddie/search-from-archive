using ArchiveSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace search_from_archive.Models
{
    public class ListOutputModel
    {
        public List<OutputDataModel> listOutputData { get; set; } = new List<OutputDataModel>();
    }
}
