using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static search_from_archive.Controllers.SearchController;

namespace search_from_archive.Models
{
    public class InputDataModel
    {
        public string ProjectCode { get; set; }
        public string ProjectStage { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public SearchTarget Target { get; set; }
        public checkFile CheckFile { get; set; }
        public string ProjectName { get; set; }
        public string InvEntoryNumber { get; set; }
        public string PromyselCode { get; set; }
        public string PromyselName { get; set; }
        public string PloshCode { get; set; }
        public string PloshName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string MarkCode { get; set; }
        public string MarkName { get; set; }



    }
}
