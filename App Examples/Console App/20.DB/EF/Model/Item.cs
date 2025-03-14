using System;

namespace BoscComa.ADO
{
    public class Item
    {
        public string? Uuid { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public User UserOwner { get; set; }
    }
}