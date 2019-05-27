using System;
using System.Collections.Generic;

namespace Borrows.Models
{
    public partial class BorrowItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int? ItemQty { get; set; }
        public string ItemBarcode { get; set; }
        public string ItemStatus { get; set; }
        public int? BorrowId { get; set; }

        public virtual BorrowDb Borrow { get; set; }
    }
}
