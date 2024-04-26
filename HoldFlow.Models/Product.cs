using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.CodeAnalysis;

namespace HoldFlow.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public int ImageId { get; set; } = 0;

        [AllowNull]
        public Image Image { get; set; }
    }
}
