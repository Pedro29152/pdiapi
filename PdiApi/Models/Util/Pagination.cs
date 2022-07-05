using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdiApi.Models.Util
{
    public class Pagination
    {
        public const int DEFAULT_PAGE_NUMBER = 1;
        public const int DEFAULT_PAGE_SIZE = 10;
        public const int MAX_PAGE_SIZE = 100;

        public Pagination()
        {
            Page = DEFAULT_PAGE_NUMBER;
            PageSize = DEFAULT_PAGE_SIZE;
        }

        private int _Page { get; set; }
        [FromQuery(Name = "p")]
        public int Page { 
            get => _Page;
            set
            {
                if (value < 1) _Page = 1;
                else _Page = value;
            }
        }

        private int _PageSize;
        [FromQuery(Name = "psize")]
        public int PageSize {
            get => _PageSize;
            set {
                if (value > MAX_PAGE_SIZE) _PageSize = MAX_PAGE_SIZE;
                else if (value < 1) _PageSize = 1;
                else _PageSize = value;
            } 
        }

        public int GetSkip()
        {
            return (Page - 1) * PageSize;
        }
    }
}
