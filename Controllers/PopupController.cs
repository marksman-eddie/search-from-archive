using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using search_from_archive.Models;
using ArchiveSearch.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
                    var itemCollection_1 = await _context.CurProjects.ToListAsync();                    
                    foreach (var item in itemCollection_1)
                    {
                        PopupModel newItem = new PopupModel { 
                        
                            popupItem = item.Full_name,
                            itemId=item.UID
                        };                        
                        dataCollection.listPopupModel.Add(newItem);                        
                    }
                    return dataCollection;
                case 2:
                    dataCollection.popupName = "Стадия";
                    var itemCollection_2 = await _context.spr.Where(i => i.Cat_spr_id == 156).ToListAsync();                        
                    foreach (var item in itemCollection_2)
                    {
                        PopupModel newItem = new PopupModel
                        {
                            popupItem = item.Full_name,
                            itemId = item.Uid.ToString()
                        };
                        dataCollection.listPopupModel.Add(newItem);
                    }
                    return dataCollection;
                case 3:
                    dataCollection.popupName = "Разработчик";
                    var itemCollection_3 = await _context.Personal_develop.OrderBy(p => p.Full_name).ToListAsync();
                    foreach (var item in itemCollection_3)
                    {
                        PopupModel newItem = new PopupModel
                        {
                            popupItem = item.Full_name,
                            itemId = item.uid.ToString()
                        };
                        dataCollection.listPopupModel.Add(newItem);
                    }
                    return dataCollection;
                case 4:
                    dataCollection.popupName = "Начальник отдела";
                    var itemCollection_4 = await _context.Personal_chiefDepart.OrderBy(p => p.Full_name).ToListAsync();
                    foreach (var item in itemCollection_4)
                    {
                        PopupModel newItem = new PopupModel
                        {
                            popupItem = item.Full_name,
                            itemId = item.uid.ToString()
                        };
                        dataCollection.listPopupModel.Add(newItem);
                    }
                    return dataCollection;
                case 5:
                    dataCollection.popupName = "Начальник группы";
                    var itemCollection_5 = await _context.Personal_chiefGrp.OrderBy(p => p.Full_name).ToListAsync();
                    foreach (var item in itemCollection_5)
                    {
                        PopupModel newItem = new PopupModel
                        {
                            popupItem = item.Full_name,
                            itemId = item.uid.ToString()
                        };
                        dataCollection.listPopupModel.Add(newItem);
                    }
                    return dataCollection;
                case 6:
                    dataCollection.popupName = "ГИП";
                    var itemCollection_6 = await _context.Personal_gip.OrderBy(p => p.Full_name).ToListAsync();
                    foreach (var item in itemCollection_6)
                    {
                        PopupModel newItem = new PopupModel
                        {
                            popupItem = item.Full_name,
                            itemId = item.uid.ToString()
                        };
                        dataCollection.listPopupModel.Add(newItem);
                    }
                    return dataCollection;
                case 7:
                    dataCollection.popupName = "Главный специалист";
                    var itemCollection_7 = await _context.Personal_mainExpert.OrderBy(p => p.Full_name).ToListAsync();
                    foreach (var item in itemCollection_7)
                    {
                        PopupModel newItem = new PopupModel
                        {
                            popupItem = item.Full_name,
                            itemId = item.uid.ToString()
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
