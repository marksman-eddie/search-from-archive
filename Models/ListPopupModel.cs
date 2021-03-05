using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace search_from_archive.Models
{
    public class ListPopupModel
    {
        public List<PopupModel> listPopupModel { get; set; } = new List<PopupModel>();
        public string popupName { get; set; }
    }
}
