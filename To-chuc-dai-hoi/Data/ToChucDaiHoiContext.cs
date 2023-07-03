using Microsoft.EntityFrameworkCore;
namespace To_chuc_dai_hoi.Data
{
    public class ToChucDaiHoiContext : DbContext
    {
        public ToChucDaiHoiContext(DbContextOptions<ToChucDaiHoiContext> options) : base(options) { }
        #region Dbset
        public DbSet<DaiBieu> DaiBieus { get; set; }
        public DbSet<Tintuc> Tintucs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PeopleChooseProduct> PeopleChooseProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategorys)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(pc => pc.CategoryId);
        }

        #endregion


    }
}
