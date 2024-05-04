using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldFlow.Models.DTOs
{
    public class PackageDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
    }
}