using System;

namespace BoscComa.ADO
{
    public class Item
    {
        public string? Uuid { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? UserOwner { get; set; }

        public override string ToString() 
        {
            return $"Name: {this.Name} Price: {this.Price}"; 
        }
    }
}