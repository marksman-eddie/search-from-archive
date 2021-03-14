using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace search_from_archive.Database.DbModel
{
    public class SprDbModel
    {
        public long Uid { get; set; }
        public long? Cat_spr_id { get; set; }
        public string? Full_name { get; set; }
        public string? Abbr_name { get; set; }
        public int? LevelOrder { get; set; }
        public int? InLevelOrder { get; set; }       
    }
}
