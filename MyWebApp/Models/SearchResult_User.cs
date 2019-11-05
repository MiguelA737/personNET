using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class SearchResult_User : SearchResult
    {
        public string DirProfilePhoto { get; set; }
        public string User { get; set; }
    }
}