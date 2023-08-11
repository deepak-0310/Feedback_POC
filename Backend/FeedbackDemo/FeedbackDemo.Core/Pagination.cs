using System;
using System.Linq;
//using Microsoft.EntityFrameworkCore;
namespace FeedbackDemo.Core
{
    public class Pagination<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public Pagination(List<T> items, int count, int pageIndex, int pageSize ) {
            try
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                this.AddRange(items);
            }
            catch(Exception ex) {
                throw new Exception( ex.Message );
            }
           
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public static Pagination<T> Create (List<T> source, int pageIndex, int pazeSize)
        {
            try
            {
                var count = source.Count;
                return new Pagination<T>(source, count, pageIndex, pazeSize);
            }
            catch(Exception ex) 
            { 
                throw new Exception(ex.Message );
            }
            
        }
    }
}
