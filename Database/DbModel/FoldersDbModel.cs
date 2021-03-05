using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveSearch.Database.DbModel
{
    public class FoldersDbModel
    {
        public int Uid { get; set; }
        public int? Pid { get; set; }
        public string? Hn { get; set; }
        public string? VirtualCode { get; set; }
        public string? FolderName { get; set; }
        public int? Csid { get; set; }
        public string? Code { get; set; }

    }

}
