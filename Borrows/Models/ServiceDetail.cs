using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borrows.Models
{
    public class ServiceDetails
    {
        public string RequestID { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string Technician { get; set; }

        public string Problem { get; set; }

        public string SerialNO { get; set; }

        public string ItemName { get; set; }
    }
}
