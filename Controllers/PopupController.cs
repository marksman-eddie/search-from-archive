﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using search_from_archive.Models;
using ArchiveSearch.Database;
using Microsoft.EntityFrameworkCore;

namespace search_from_archive.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PopupController : Controller
    {
        private readonly ArchiveContext _context;
        public PopupController(ArchiveContext context)
        {
            _context = context;
        }
        enum Operation
        {
            Code = 1,
            Stage = 2,            
        }
        [HttpGet("modalCode")]
        public async Task<ListPopupModel> ModalCode(int idButton)
        {
        ListPopupModel dataCollection = new ListPopupModel();
                switch (idButton)
            {
                case 1:
                    dataCollection.popupName = "Код проекта";
                    var itemCollection = await _context.folders.Select(c => c.Code).Distinct().Take(100).ToListAsync();
                    foreach (var item in itemCollection)
                    {
                        PopupModel newItem = new PopupModel
                        { 
                            popupItem = item 
                        };                        
                        dataCollection.listPopupModel.Add(newItem);                        
                    }
                    return dataCollection;

            }
            return null;
        }

        //public async Task<ListPopupModel> getListFromDb(string table, ListPopupModel model)
        //{
        //    var itemCollection = await _context..Select(c => ).Distinct().Take(100).ToListAsync();
        //    foreach (var item in itemCollection)
        //    {
        //        PopupModel newItem = new PopupModel();
        //        newItem.popupItem = item;
        //        model.listPopupModel.Add(newItem);
        //    }
        //    return model;
        //}
    }


}