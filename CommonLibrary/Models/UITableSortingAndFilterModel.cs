using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class UITableSortingAndFilterModel
    {

        public string Active { get; set; }
        public string Direction { get; set; }
        public ushort PageIndex { get; set; }
        public ushort PageSize { get; set; }
        public string Search { get; set; }
    }
}
