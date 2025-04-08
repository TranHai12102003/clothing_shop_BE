using Clothing_shop.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<VariantPromotion> VariantPromotions { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CustomerType)
                .WithMany(ct => ct.Users)
                .HasForeignKey(u => u.CustomerTypeId);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(v => v.ProductId);

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Size)
                .WithMany(s => s.Variants)
                .HasForeignKey(v => v.SizeId);

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Color)
                .WithMany(c => c.Variants)
                .HasForeignKey(v => v.ColorId);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Variant)
                .WithMany(v => v.ProductImages)
                .HasForeignKey(pi => pi.VariantId);

            modelBuilder.Entity<VariantPromotion>()
                .HasOne(vp => vp.Variant)
                .WithMany(v => v.VariantPromotions)
                .HasForeignKey(vp => vp.VariantId);

            modelBuilder.Entity<VariantPromotion>()
                .HasOne(vp => vp.Promotion)
                .WithMany(p => p.VariantPromotions)
                .HasForeignKey(vp => vp.PromotionId);

            modelBuilder.Entity<Voucher>()
                .HasOne(v => v.CustomerType)
                .WithMany(ct => ct.Vouchers)
                .HasForeignKey(v => v.CustomerTypeId);

            modelBuilder.Entity<Banner>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Banners)
                .HasForeignKey(b => b.ProductId);

            modelBuilder.Entity<Banner>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Banners)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Banner>()
                .HasOne(b => b.Promotion)
                .WithMany(p => p.Banners)
                .HasForeignKey(b => b.PromotionId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Order>(o => o.PaymentId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Voucher)
                .WithMany(v => v.Orders)
                .HasForeignKey(o => o.VoucherId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(it => it.Variant)
                .WithMany(v => v.InventoryTransactions)
                .HasForeignKey(it => it.VariantId);

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(it => it.Warehouse)
                .WithMany(w => w.InventoryTransactions)
                .HasForeignKey(it => it.WarehouseId);

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(it => it.Order)
                .WithMany(o => o.InventoryTransactions)
                .HasForeignKey(it => it.OrderId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Variant)
                .WithMany(v => v.Carts)
                .HasForeignKey(c => c.VariantId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Variant)
                .WithMany(v => v.OrderDetails)
                .HasForeignKey(od => od.VariantId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Order)
                .WithMany(o => o.Notifications)
                .HasForeignKey(n => n.OrderId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Promotion)
                .WithMany(p => p.Notifications)
                .HasForeignKey(n => n.PromotionId);

            // Cấu hình ràng buộc duy nhất
            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique();
            modelBuilder.Entity<CustomerType>().HasIndex(ct => ct.TypeName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Size>().HasIndex(s => s.SizeName).IsUnique();
            modelBuilder.Entity<Color>().HasIndex(c => c.ColorName).IsUnique();
            modelBuilder.Entity<Variant>().HasIndex(v => new { v.ProductId, v.SizeId, v.ColorId }).IsUnique();
            modelBuilder.Entity<Voucher>().HasIndex(v => v.VoucherCode).IsUnique();
        }
    }
}
