using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using search_from_archive.Models;
using ArchiveSearch.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using NLog;

namespace search_from_archive.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PopupController : Controller
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();
        private readonly ArchiveContext _context;
        private readonly IMemoryCache _cacheMemory;
        public PopupController(ArchiveContext context,IMemoryCache cacheMemory)
        {
            _context = context;
            _cacheMemory = cacheMemory;
        }
        enum Operation
        {
            Code = 1,
            Stage = 2,            
        }
        [HttpGet("modalCode")]
        public async Task<ListPopupModel> ModalCode(int idPopup)
        {
            try
            {
                if (_cacheMemory.TryGetValue(idPopup, out ListPopupModel popupModel))
                {
                    return popupModel;
                }
                ListPopupModel dataCollection = new ListPopupModel();
                switch (idPopup)
                {
                    case 1:
                        dataCollection.popupName = "Код проекта";

                        var itemCollection_1 = await _context.CurProjects.ToListAsync();
                        foreach (var item in itemCollection_1)
                        {
                            PopupModel newItem = new PopupModel
                            {

                                popupItem = item.Full_name,
                                itemId = item.Uid
                            };
                            dataCollection.listPopupModel.Add(newItem);
                        }
                        break;
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
                        break;
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
                        break;
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
                        break;
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
                        break;
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
                        break;
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
                        break;
                    case 8:
                        dataCollection.popupName = "Тип листа";
                        var itemCollection_8 = await _context.spr.Where(i => i.Cat_spr_id == 157).OrderBy(x => x.Full_name).ToListAsync();
                        foreach (var item in itemCollection_8)
                        {
                            PopupModel newItem = new PopupModel
                            {
                                popupItem = item.Full_name,
                                itemId = item.Uid.ToString()
                            };
                            dataCollection.listPopupModel.Add(newItem);
                        }
                        break;
                    case 9:
                        dataCollection.popupName = "Формат";
                        var itemCollection_9 = await _context.spr.Where(i => i.Cat_spr_id == 161 && i.Full_name != "").OrderBy(x => x.Full_name).ToListAsync();
                        foreach (var item in itemCollection_9)
                        {
                            PopupModel newItem = new PopupModel
                            {
                                popupItem = item.Full_name,
                                itemId = item.Uid.ToString()
                            };
                            dataCollection.listPopupModel.Add(newItem);
                        }
                        break;
                    case 10:
                        dataCollection.popupName = "Отдел";
                        var itemCollection_10 = await _context.Personal_Depart.OrderBy(p => p.Full_name).ToListAsync();
                        foreach (var item in itemCollection_10)
                        {
                            PopupModel newItem = new PopupModel
                            {
                                popupItem = item.Full_name,
                                itemId = item.uid.ToString()
                            };
                            dataCollection.listPopupModel.Add(newItem);
                        }
                        break;
                    case 11:
                        dataCollection.popupName = "Наименование компании";
                        var itemCollection_11 = await _context.Card_spr_company.ToListAsync();
                        foreach (var item in itemCollection_11)
                        {
                            PopupModel newItem = new PopupModel
                            {
                                popupItem = item.Full_name,
                                itemId = item.uid.ToString()
                            };
                            dataCollection.listPopupModel.Add(newItem);
                        }
                        break;
                }
                _cacheMemory.Set(idPopup, dataCollection, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(10)));
                return dataCollection;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex.Message);
                return null;
            }
        }        
    }
}
