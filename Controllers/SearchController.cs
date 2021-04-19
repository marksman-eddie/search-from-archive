using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ArchiveSearch.Database;
using Microsoft.Data.SqlClient;
using search_from_archive.Models;
using Microsoft.EntityFrameworkCore;
using ArchiveSearch.Models;
using NLog;
namespace search_from_archive.Controllers
{   
    public class SearchController : Controller
    {
        private readonly ArchiveContext _context;
        private static Logger _Logger = LogManager.GetCurrentClassLogger();
        public SearchController (ArchiveContext context)
        {
            _context = context;
            
    }
        [HttpGet]
        public IActionResult SearchForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchForm(InputDataModel InputData)
        {
            try
            {
                string cmdToTSql = "ar_Search6_new @Date1=@Date1,@Date2=@Date2,@ProjectsFoldersCards=@ProjectsFoldersCards,@checkFile=@checkFile";
                List<SqlParameter> sp = new List<SqlParameter>();
                sp.Add(new SqlParameter("@Date1", InputData.Date1));
                sp.Add(new SqlParameter("@Date2", InputData.Date2));
                sp.Add(new SqlParameter("@ProjectsFoldersCards", Convert.ToInt32(InputData.Target)));
                sp.Add(new SqlParameter("@checkFile", Convert.ToInt32(InputData.CheckFile)));
                if (InputData.ProjectName != null)
                {
                    sp.Add(new SqlParameter("@ProjectName", $"%{InputData.ProjectName}%"));
                    cmdToTSql += ",@ProjectName=@ProjectName";
                }
                if (InputData.InvEntoryNumber != null)
                {
                    sp.Add(new SqlParameter("@InvEntoryNumber", $"{InputData.InvEntoryNumber}"));
                    cmdToTSql += ",@InvEntoryNumber=@InvEntoryNumber";
                }
                if (InputData.PromyselCode != null)
                {
                    sp.Add(new SqlParameter("@PromyselCode", $"%{InputData.PromyselCode}%"));
                    cmdToTSql += ",@PromyselCode=@PromyselCode";
                }
                if (InputData.PromyselName != null)
                {
                    sp.Add(new SqlParameter("@PromyselName", $"%{InputData.PromyselName}%"));
                    cmdToTSql += ",@PromyselName=@PromyselName";
                }
                if (InputData.PloshCode != null)
                {
                    sp.Add(new SqlParameter("@PloshCode", $"%{InputData.PloshCode}%"));
                    cmdToTSql += ",@PloshCode=@PloshCode";
                }
                if (InputData.PloshName != null)
                {
                    sp.Add(new SqlParameter("@PloshName", $"%{InputData.PloshName}%"));
                    cmdToTSql += ",@PloshName=@PloshName";
                }
                if (InputData.PositionCode != null)
                {
                    sp.Add(new SqlParameter("@PositionCode", $"%{InputData.PositionCode}%"));
                    cmdToTSql += ",@PositionCode=@PositionCode";
                }
                if (InputData.PositionName != null)
                {
                    sp.Add(new SqlParameter("@PositionName", $"%{InputData.PositionName}%"));
                    cmdToTSql += ",@PositionName=@PositionName";
                }
                if (InputData.MarkCode != null)
                {
                    sp.Add(new SqlParameter("@MarkCode", $"%{InputData.MarkCode}%"));
                    cmdToTSql += ",@MarkCode=@MarkCode";
                }
                if (InputData.MarkName != null)
                {
                    sp.Add(new SqlParameter("@MarkName", $"%{InputData.MarkName}%"));
                    cmdToTSql += ",@MarkName=@MarkName";
                }
                if (InputData.ProjectCode != null)
                {
                    sp.Add(new SqlParameter("@ProjectCode", InputData.ProjectCode));
                    cmdToTSql += ",@ProjectCode=@ProjectCode";
                }
                if (InputData.ProjectStage != null)
                {
                    sp.Add(new SqlParameter("@ProjectStage", InputData.ProjectStage));
                    cmdToTSql += ",@ProjectStage=@ProjectStage";
                }
                if (InputData.Leaftypename != null)
                {
                    sp.Add(new SqlParameter("@Leaftypename", InputData.Leaftypename));
                    cmdToTSql += ",@Leaftypename=@Leaftypename";
                }
                if (InputData.PaperFormatName != null)
                {
                    sp.Add(new SqlParameter("@PaperFormatName", InputData.PaperFormatName));
                    cmdToTSql += ",@PaperFormatName=@PaperFormatName";
                }
                if (InputData.LeafNumber != null)
                {
                    sp.Add(new SqlParameter("@LeafNumber", InputData.LeafNumber));
                    cmdToTSql += ",@LeafNumber=@LeafNumber";
                }
                if (InputData.organization != null)
                {
                    sp.Add(new SqlParameter("@organization", InputData.organization));
                    cmdToTSql += ",@organization=@organization";
                }
                if (InputData.Otdel != null)
                {
                    sp.Add(new SqlParameter("@Otdel", InputData.Otdel));
                    cmdToTSql += ",@Otdel=@Otdel";
                }
                var Data = _context._OutputDataModels.FromSqlRaw(cmdToTSql, sp.ToArray());
                ListOutputModel listOutput = new ListOutputModel();
                foreach (var dataRow in Data)
                {
                    OutputDataModel output = new OutputDataModel();
                    output.Csid = dataRow.Csid;
                    output.FolderName = dataRow.FolderName;
                    output.Hn = dataRow.Hn;
                    output.Pid = dataRow.Pid;
                    output.Uid = dataRow.Uid;
                    output.code = dataRow.code;
                    listOutput.listOutputData.Add(output);
                }

                return View("ResultCollection", listOutput);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public IActionResult ResultCollection()
        {
            return View();
        }
    }
}
