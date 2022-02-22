using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class Page<T>
    {
        public int TotalRows { get; set; }
        public List<T> List { get; set; }
        public Page() { }
        public Page(int totalRows, List<T> list)
        {
            TotalRows = totalRows;
            List = list;
        }
    }
}
