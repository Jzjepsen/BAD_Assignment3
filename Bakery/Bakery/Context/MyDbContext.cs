using Bakery.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Context;

public class MyDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public MyDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    internal DbSet<Orders> Orders{ get; set; }
    internal DbSet<Deliveries> Deliveries{ get; set; }
    internal DbSet<Supermarkets> Supermarkets{ get; set; }
    internal DbSet<BakingGoods> BakingGoods{ get; set; }
    internal DbSet<OrderBakingGood> OrderBakingGoods{ get; set; }
    internal DbSet<BakingGoodBatch> BakingGoodBatches{ get; set; }
    internal DbSet<Batches> Batches{ get; set; }
    internal DbSet<Ingredients> Ingredients{ get; set; }
    internal DbSet<BatchIngredient> BatchIngredients{ get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // BakingGoodBatch
       modelBuilder.Entity<BakingGoodBatch>()
           .HasKey(i => new { i.BakingGoodId, i.BatchId });

       modelBuilder.Entity<BakingGoodBatch>()
           .HasOne(e => e.BakingGood)
           .WithMany(e => e.BakingGoodBatches)
           .HasForeignKey(e => e.BakingGoodId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<BakingGoodBatch>()
           .HasOne(e=>e.Batch)
           .WithMany(e => e.BakingGoodBatches)
           .HasForeignKey(e=>e.BatchId)
           .OnDelete(DeleteBehavior.Cascade);
       
       // BatchIngredient
       modelBuilder.Entity<BatchIngredient>()
           .HasKey(i => new { i.BatchId, i.IngredientId });
       
       modelBuilder.Entity<BatchIngredient>()
           .HasOne(e=>e.Batch)
           .WithMany(e => e.BatchIngredients)
           .HasForeignKey(e=>e.BatchId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<BatchIngredient>()
           .HasOne(e=>e.Ingredient)
           .WithMany(e => e.BatchIngredients)
           .HasForeignKey(e=>e.IngredientId)
           .OnDelete(DeleteBehavior.Cascade);
       
       // OrderBakingGood
       modelBuilder.Entity<OrderBakingGood>()
           .HasKey(i => new { i.OrderId, i.BakingGoodId });
       
       modelBuilder.Entity<OrderBakingGood>()
           .HasOne(e=>e.Order)
           .WithMany(e => e.OrderBakingGoods)
           .HasForeignKey(e=>e.OrderId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<OrderBakingGood>()
           .HasOne(e=>e.BakingGood)
           .WithMany(e => e.OrderBakingGoods)
           .HasForeignKey(e=>e.BakingGoodId)
           .OnDelete(DeleteBehavior.Cascade);

    }
}