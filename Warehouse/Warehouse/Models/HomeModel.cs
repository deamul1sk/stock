namespace Warehouse.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HomeModel : DbContext
    {
        public HomeModel()
            : base("name=HomeModel1")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Detail_Product> Detail_Product { get; set; }
        public virtual DbSet<Detail_Stock> Detail_Stock { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Sold> Solds { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Detail_Product)
                .WithOptional(e => e.Bill)
                .HasForeignKey(e => e.idBill)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Detail_Product>()
                .Property(e => e.price)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Detail_Product>()
                .HasMany(e => e.Solds)
                .WithOptional(e => e.Detail_Product)
                .HasForeignKey(e => e.idDetail_Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Detail_Product)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.idProduct)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Inputs)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.idProduct)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stocks)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.idProduct)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Stock>()
                .HasMany(e => e.Detail_Stock)
                .WithOptional(e => e.Stock)
                .HasForeignKey(e => e.idStock)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Stock>()
                .HasMany(e => e.Proposals)
                .WithOptional(e => e.Stock)
                .HasForeignKey(e => e.idStock)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.Inputs)
                .WithOptional(e => e.Supply)
                .HasForeignKey(e => e.idSupply)
                .WillCascadeOnDelete();
        }
    }
}
