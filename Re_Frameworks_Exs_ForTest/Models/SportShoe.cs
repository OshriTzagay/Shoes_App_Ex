using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Frameworks_Exs_ForTest.Models
{
    public class SportShoe
    {
        public int Id { get; set; }
        public string ShoeCompany { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }



        public SportShoe(int id, string shoeCompany, string brand, int size, int price)
        {
            this.Id = id;
            this.ShoeCompany = shoeCompany;
            this.Brand = brand;
            this.Size = size;
            this.Price = price;
        }
        public SportShoe() { }
    }
}