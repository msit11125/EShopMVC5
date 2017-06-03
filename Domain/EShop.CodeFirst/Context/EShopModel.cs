namespace EShop.CodeFirst.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class EShopModel : DbContext
    {
        //這裡是因為DataBase First而產生 ， 但已將產生的Model移動至EShop.Models
        public EShopModel()
            : base("name=EShopModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategorySub> CategorySubs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Cash)
                .HasPrecision(9, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.UnitPrice)
                .HasPrecision(9, 2);
        }
    }
}
