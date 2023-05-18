using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Paging
{
    public  class PaginatedList<T>:List<T>
    {
        public int PageIndex { get;  set; }
        public int TotalPage { get;  set; }
        public int PageSize { get;  set; }
        public List<T> item { get;  set; }
        public PaginatedList(List<T> items, int count, int pageIndex,int pageSize) 
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count /(double) pageSize);
            item = items;
            this.AddRange(item);
        }

        public bool HasPreveousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPage;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageSize, int PageIndex)
        {
            var count = await source.CountAsync();
           var items =await source.Skip((PageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, PageIndex, pageSize);
        }
    }
}
