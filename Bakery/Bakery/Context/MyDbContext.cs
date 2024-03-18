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
    internal DbSet<Address> Addresses{ get; set; }
    internal DbSet<Batches> Batches{ get; set; }
    internal DbSet<Ingredients> Ingredients{ get; set; }
    internal DbSet<BatchIngredient> IngredientBatches{ get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}