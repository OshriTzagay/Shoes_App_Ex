using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Re_Frameworks_Exs_ForTest.Models
{
    public partial class MyShoeStoreDBC : DbContext
    {
        public MyShoeStoreDBC()
            : base("name=MyShoeStoreDBC")
        {
        }

        public DbSet<SportShoe> SportShoes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
