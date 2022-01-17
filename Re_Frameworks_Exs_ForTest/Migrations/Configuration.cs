namespace Re_Frameworks_Exs_ForTest.Migrations
{
    using Re_Frameworks_Exs_ForTest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Re_Frameworks_Exs_ForTest.Models.MyShoeStoreDBC>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
       
        protected override void Seed(Re_Frameworks_Exs_ForTest.Models.MyShoeStoreDBC context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
