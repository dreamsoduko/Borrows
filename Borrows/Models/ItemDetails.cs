using System;
using System.Collections.Generic;

namespace Borrows.Models
{
    public partial class ItemDetails
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string FrgnName { get; set; }
        public decimal? StockAvailable { get; set; }
    }
}
