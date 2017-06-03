namespace EShop.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<EShop.Models.IMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //自訂 |DataDirectory| 相對路徑
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\msit11125\Desktop\Eshop\EShop.Domain\App_Data");
        }

        protected override void Seed(EShop.Models.IMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
