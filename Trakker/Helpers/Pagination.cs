using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trakker.Helpers
{
    public class Pagination
    {

        private int _lowerbound;
        private int _upperbound;

        public int Index { get; private set; }
        public int PageSize { get; private set; }
        public int ItemCount { get; private set; }
        public int TotalPages { get; private set; }

        public int Lowerbound
        {
            get { return _lowerbound; }
            private set
            {
                if (value < 1)
                    _lowerbound = 1;
                else if (value > Index)
                    _lowerbound = Index;
                else
                    _lowerbound = value;
            }
        }

        public int Upperbound
        {
            get { return _upperbound; }
            private set
            {
                if (value < Index)
                    _upperbound = Index;
                else if (value > TotalPages)
                    _upperbound = TotalPages;
                else
                    _upperbound = value;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (Index > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (Index + 1 <= TotalPages);
            }
        }

        //cannot be less than one
        public int PreviousPage
        {
            get 
            {  
                int page = Index - 1;
                if (page < 1) page = 1;
                return page;
            }
        }

        //cannot be greater than total pages
        public int NextPage
        {
            get
            {
                int page = Index + 1;
                if (page > TotalPages) page = TotalPages;
                return page;
            }
        }

        public Pagination(int totalItemCount, int pageIndex, int pageSize)
        {
            if (pageIndex < 1) pageIndex = 1;
           

            Index = pageIndex;
            PageSize = pageSize;
            ItemCount = totalItemCount;
            PopulateTotalPages();
            PopulateBounds(10);

            if (Index > TotalPages) Index = TotalPages;

        }

        public Pagination(int totalItemCount, int pageIndex, int pageSize, int numPagesToShow)
        {
            if (pageIndex < 1) pageIndex = 1;

            Index = pageIndex;
            PageSize = pageSize;
            ItemCount = totalItemCount;
            PopulateTotalPages();
            PopulateBounds(numPagesToShow);

            if (Index > TotalPages) Index = TotalPages;
        }


       

        private void PopulateTotalPages()
        {
            TotalPages = (int)Math.Ceiling(ItemCount / (double)PageSize);
        }

        private void PopulateBounds(int numPagesToShow)
        {
            int left = 0;
            int right = 0;

            if ((numPagesToShow % 2) != 0)
            {
                left = right = (int)Math.Floor(numPagesToShow / 2.0);
            }
            else
            {
                left = (int)Math.Floor((numPagesToShow - 1) / 2.0);
                right = (int)Math.Ceiling((numPagesToShow - 1) / 2.0);
            }

            Lowerbound = Index - left;
            Upperbound = Index + right;
        }
    }
}
