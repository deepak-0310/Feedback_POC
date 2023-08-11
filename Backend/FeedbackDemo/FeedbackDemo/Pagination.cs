using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace FeedbackDemo
{
    public class Pagination<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public Pagination(List<T> items, int count, int pageIndex, int pageSize ) {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange( items );
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public static Pagination<T> Create (List<T> source, int pageIndex, int pazeSize)
        {
            var count=source.Count;
            var items = source.Skip((pageIndex-1)*pazeSize).Take(pazeSize).ToList();
            return new Pagination<T>(items, count, pageIndex, pazeSize);
        }
    }
}
