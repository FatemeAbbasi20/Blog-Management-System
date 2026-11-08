using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Utilities
{
    public class BasePagination
    {
        public int EntityCount { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }

        public void GeneratePaging(IQueryable<object>data,int take,int currentPage)
        {
           var entityCount = data.Count();
           var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            EntityCount = entityCount;
            PageCount = pageCount;
            Take = take;
            CurrentPage = currentPage;
            StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
            EndPage= (currentPage+5 > pageCount) ? pageCount : currentPage + 5 ;

        }




    }
}
