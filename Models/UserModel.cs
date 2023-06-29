using System;
namespace dotNetAPI.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string ?TrailName { get; set; }
        public string ?Email { get; set; }
        public List<ItemModel> Items { get; set; } = new();
    }
}
