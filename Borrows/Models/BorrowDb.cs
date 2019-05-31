using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Borrows.Models
{
    public partial class BorrowDb
    {
        public BorrowDb()
        {
            BorrowItem = new HashSet<BorrowItem>();
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BorrowId { get; set; }

        public string ServiceCode { get; set; }
        public string CustomerName { get; set; }
        public string ProductId { get; set; }
        public string SerialNo { get; set; }
        public string EntryName { get; set; }
        public DateTime? EntryDate { get; set; }
        public string RequestName { get; set; }
        public DateTime? RequestDate { get; set; }
        public string BorrowStatus { get; set; }
        public string HeadApproverId { get; set; }
        public DateTime? HeadApproverDate { get; set; }
        public string ManagerApproverId { get; set; }
        public DateTime? ManagerApproverDate { get; set; }
        public string LogisticApproverId { get; set; }
        public DateTime? LogisticApproverDate { get; set; }

        public virtual ICollection<BorrowItem> BorrowItem { get; set; }
    }
}
