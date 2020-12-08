using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task24_advanced.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Article> News { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string Tag { get; set; }
        public string Id { get; set; }
    }
}