using System;
using System.Linq;

namespace Common.Application
{
    public class PaginateBase
    {
        public int EntityCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int Take { get; private set; }

        public void GeneratePaging(IQueryable<Object> data, int take, int currentPage)
        {
            var entityCount = data.Count();
            var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            PageCount = pageCount;
            CurrentPage = currentPage;
            EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
            EntityCount = entityCount;
            Take = take;
            StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
        }
    }
}
