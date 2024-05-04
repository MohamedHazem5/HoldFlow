using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldFlow.Models.DTOs
{
    public class DeletePackageDto
    {
        public int Id { get; set; }
        public double ListPrice { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Stock { get; set; }
        public int left { get; set; }
        public double Price { get; set; }
    }
}