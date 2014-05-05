using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WnioskiOnline.ViewModels
{
    public class WnioskiViewModel
    {
        public IEnumerable<WnioskiOnline.Models.Wniosek> Wnioski { get; set; }
        public IEnumerable<string> Statusy { get; set; }
        public IEnumerable<string> Konkursy { get; set; }
        public string Konkurs { get; set; }
        public string Status { get; set; }
    }
}