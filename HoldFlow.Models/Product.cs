﻿namespace HoldFlow.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; } = 1;
        public Category Category { get; set; }
        public Image Image { get; set; }
    }
}