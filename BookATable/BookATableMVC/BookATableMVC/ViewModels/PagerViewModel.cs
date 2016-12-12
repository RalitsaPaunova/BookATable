using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels
{
    public class PagerViewModel
    {

        public string Prefix { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public PagerViewModel()
            : this(0, 1, 5, "", "", "")
        {

        }

        public PagerViewModel(int totalItems, int? page, int? pageSize, string prefix, string action, string controller)
        {
            if (pageSize == null || PageSize == 0)
                pageSize = 5;


            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            Prefix = prefix;
            Action = action;
            Controller = controller;
        }
    }
}

