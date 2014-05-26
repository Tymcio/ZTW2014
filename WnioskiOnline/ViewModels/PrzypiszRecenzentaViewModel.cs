using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WnioskiOnline.ViewModels
{
    public class PrzypiszRecenzentaViewModel
    {
        public IEnumerable<WnioskiOnline.Models.UserProfile> Recenzenci { get; set; }
        public IEnumerable<WnioskiOnline.Models.Wniosek> Wnioski { get; set; }
    }
}