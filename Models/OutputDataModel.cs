using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveSearch.Models
{
    public class OutputDataModel
    {
        public long Uid { get; set; }
        public string code { get; set; }
        public long? Pid { get; set; }
        public string Hn { get; set; }
        public string FolderName { get; set; }
        public long Csid { get; set; }
    }
}
