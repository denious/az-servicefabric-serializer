using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class CartContext : DbContext
    {
        public CartContext()
        {
        }

        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("FabricSerializer");
            }
        }

        public virtual DbSet<CartDetail> CartDetail { get; set; }
        public virtual DbSet<CartHeader> CartHeader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CartDetail>(
                entity =>
                {
                    entity.HasOne(d => d.Cart)
                          .WithMany(p => p.CartDetail)
                          .HasForeignKey(d => d.CartID)
                          .OnDelete(DeleteBehavior.ClientSetNull)
                          .HasConstraintName("FK_CartDetail_CartHeader");

                    entity.HasData(
                        new CartDetail
                        {
                            CartDetailID = 100,
                            CartID       = 36,
                            ProductID    = 476,
                            Qty          = 3,
                            CreatedOn    = DateTime.Now,
                            ModifiedOn   = DateTime.Now,
                            CreatedBy    = "d9e7d1eb-58f5-4679-9409-65d5c19d5f56",
                            ModifiedBy   = "d9e7d1eb-58f5-4679-9409-65d5c19d5f56"
                        });
                });

            modelBuilder.Entity<CartHeader>(
                entity =>
                {
                    entity.HasKey(e => e.CartID)
                          .HasName("PK_Cart");

                    entity.HasData(
                        new CartHeader
                        {
                            CartID     = 36,
                            IdentityID = "d9e7d1eb-58f5-4679-9409-65d5c19d5f56",
                            Status     = "Closed",
                            CreatedOn  = DateTime.Now,
                            ModifiedOn = DateTime.Now,
                            CreatedBy  = "d9e7d1eb-58f5-4679-9409-65d5c19d5f56",
                            ModifiedBy = "d9e7d1eb-58f5-4679-9409-65d5c19d5f56"
                        });
                });
        }
    }
}
