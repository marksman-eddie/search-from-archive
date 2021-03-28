using search_from_archive.Enum;
using System;
namespace search_from_archive.Models
{
    public class InputDataModel
    {
        public string ProjectCode { get; set; }
        public string ProjectStage { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public SearchTarget Target { get; set; }
        public CheckFile CheckFile { get; set; }
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
