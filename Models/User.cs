using System;
namespace MyApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string TrailName { get; set; }
        public string Email { get; set; }
    }
}
