using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class IMSContext : DbContext
    {
        public IMSContext()
            : base("name=MyConnection")
        {
        }

        //步驟 1 開啟套件主控台，選取CodeFirst專案

        //步驟 2 enable-migrations

        //步驟 3 add-migration 'First'

        //步驟 4 update-database


        public DbSet<ProductTable> Products { get; set; }
        public DbSet<CategoryTable> Category { get; set; }
        public DbSet<CategorySubTable> CategorySub { get; set; }
        public DbSet<OrderTable> Order { get; set; }
        public DbSet<OrderDetailTable> OrderDetail { get; set; }
        public DbSet<AccountTable> Account { get; set; }
        public DbSet<ShoppingCartTable> ShoppingCart { get; set; }

        //EF6 decimal精準度設定方法
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(9, 2)); //DecimalPropertyConvention(byte precision, byte scale)
        }
    }
}
