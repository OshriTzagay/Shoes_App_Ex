using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Frameworks_Exs_ForTest.Models
{
    public class ClassicShoe
    {
        public ClassicShoe(int id, string company, string gender, bool isHeels, bool inStock, int size)
        {
            Id = id;
            Company = company;
            Gender = gender;
            IsHeels = isHeels;
            InStock = inStock;
            Size = size;
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }
        public bool IsHeels { get; set; }
        public bool InStock { get; set; }

        public int Size { get; set; }

        public ClassicShoe() { }

    }
}