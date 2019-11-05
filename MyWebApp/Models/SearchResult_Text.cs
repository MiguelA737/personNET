using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class SearchResult_Text : SearchResult
    {
        public string ContentText { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string UploadDate { get; set; }
    }
}