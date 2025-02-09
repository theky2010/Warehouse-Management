using Microsoft.EntityFrameworkCore;
using WareHouseManagment.Models;
namespace WareHouseManagment.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseLocation> WarehouseLocations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InboundTransaction> InboundTransactions { get; set; }
        public DbSet<InboundTransactionDetail> InboundTransactionDetails { get; set; }
        public DbSet<OutboundTransaction> OutboundTransactions { get; set; }
        public DbSet<OutboundTransactionDetail> OutboundTransactionDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Inventory
            modelBuilder.Entity<Inventory>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Product)
                .WithMany(p => p.inventories)
                .HasForeignKey(i => i.ProductId);
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.WarehouseLocation)
                .WithMany(w => w.inventories)
                .HasForeignKey(i => i.WarehouseLocationId);


            //InboundTransactionDetail
            modelBuilder.Entity<InboundTransactionDetail>()
                .HasKey(itd => itd.Id);

            modelBuilder.Entity<InboundTransactionDetail>()
                .HasOne(itd => itd.Product)
                .WithMany(p => p.inboundDetails)
                .HasForeignKey(itd => itd.ProductId);

            modelBuilder.Entity<InboundTransactionDetail>()
                .HasOne(itd => itd.WarehouseLocation)
                .WithMany(p=>p.inboundTransactionDetails)
                .HasForeignKey(itd => itd.WarehouseLocationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InboundTransactionDetail>()
                .HasOne(itd => itd.InboundTransaction)
                .WithMany(p=> p.inboundTransactionDetails)
                .HasForeignKey(itd => itd.InboundTransactionId);

            //OutboundTransactionDetail
            modelBuilder.Entity<OutboundTransactionDetail>()
                .HasKey(otd => otd.Id);

            modelBuilder.Entity<OutboundTransactionDetail>()
                .HasOne(otd => otd.Product)
                .WithMany(p => p.outboundTransactionDetails)
                .HasForeignKey(otd => otd.ProductId);

            modelBuilder.Entity<OutboundTransactionDetail>()
                .HasOne(itd => itd.WarehouseLocation)
                .WithMany(p=>p.outboundTransactionDetails)
                .HasForeignKey(itd => itd.WarehouseLocationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OutboundTransactionDetail>()
                .HasOne(otd => otd.OutboundTransaction)
                .WithMany(ot => ot.outboundTransactionDetails)
                .HasForeignKey(otd => otd.OutboundTransactionId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.CategoryId);
            //UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>() 
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
