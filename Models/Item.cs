using System;
namespace MyApi.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int Weight { get; set; }
        public bool Worn { get; set; }
        public bool Consumable { get; set; }
        public string URL { get; set; }
    }
}
