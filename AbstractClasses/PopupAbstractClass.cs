using ArchiveSearch.Database;
using Microsoft.EntityFrameworkCore;
using search_from_archive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace search_from_archive.AbstractClasses
{
    abstract class PopupAbstractClass
    {
        private readonly ArchiveContext _context;
        public string Full_name { get; set; }
        public string uid { get; set; }       
        public PopupAbstractClass(ArchiveContext context)
        {
            _context = context;            
        }

        public async void popupCreate (ListPopupModel dataCollection)
        {
            var itemCollection = await _context.CurProjects.ToListAsync();
            foreach (var item in itemCollection)
            {
                PopupModel newItem = new PopupModel
                {

                    popupItem = item.Full_name,
                    itemId = item.Uid
                };
                dataCollection.listPopupModel.Add(newItem);
            }
        }
    }
}
