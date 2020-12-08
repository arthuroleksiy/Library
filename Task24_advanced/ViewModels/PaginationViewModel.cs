using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task24_advanced.ViewModels
{
    public class PaginationViewModel
    {

        public int Pages { get; set; }
        public int TotalPages { get; set; }

        public PaginationViewModel(int count, int pages, int pageSize)
        {
            Pages = pages;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (Pages > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (Pages < TotalPages);
            }
        }
    }
}