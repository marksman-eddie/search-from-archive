using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ArchiveSearch.Database;
using Microsoft.Data.SqlClient;
using search_from_archive.Models;

using Microsoft.EntityFrameworkCore;
using ArchiveSearch.Models;

namespace search_from_archive.Controllers
{
   
    public class SearchController : Controller
    {
        private readonly ArchiveContext _context;
        public SearchController (ArchiveContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult SearchForm()
        {
            return View();
        }

        public enum SearchTarget
        {
            Projects = 0,
            Folders = 1,
            Cards = 2
        }

        public enum checkFile
        {
            NoneCheck = 0,
            CheckFile = 1
            
        }

        [HttpPost]
        public IActionResult SearchForm(InputDataModel InputData)
        {
            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@Date1",InputData.Date1));
            sp.Add(new SqlParameter("@Date2", InputData.Date2));
            sp.Add(new SqlParameter("@ProjectsFoldersCards", Convert.ToInt32(InputData.Target)));
            sp.Add(new SqlParameter("@checkFile", Convert.ToInt32(InputData.CheckFile)));

            var Data = _context._OutputDataModels.FromSqlRaw("ar_Search6_new @Date1=@Date1,@Date2=@Date2,@ProjectsFoldersCards=@ProjectsFoldersCards,@checkFile=@checkFile", sp.ToArray());

            ListOutputModel listOutput = new ListOutputModel();
            foreach(var dataRow in Data)
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

            return View("ResultCollection",listOutput);
        }

        [HttpGet]
        public IActionResult ResultCollection()
        {
            return View();
        }
    }
}
