using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldFlow.Models
{
    public class BorrowItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BorrowId { get; set; } 
        public Borrow Borrow { get; set; } 
        public int PackageId { get; set; } 
        public Package Package { get; set; } 

    }
}
