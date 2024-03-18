using Bakery.Context;
using Bakery.Models;

namespace Bakery.Data
{
    public class SeedData
    {
        public void Seed(MyDbContext db)
        {
            var order1 = new Orders { Date = new DateOnly(), DeliveryPlace = "" };
            var order2 = new Orders { Date = new DateOnly(), DeliveryPlace = "" };

            db.Orders.Add(order1);
            db.Orders.Add(order2);

            var bakingGood1 = new BakingGoods { Name = "", Price = 2, Quantity = 3 };
            var bakingGood2 = new BakingGoods { Name = "", Price = 2, Quantity = 3 };

            db.BakingGoods.Add(bakingGood1);
            db.BakingGoods.Add(bakingGood2);

            var batch1 = new Batches { StartTime = new TimeOnly(), FinishTime = new TimeOnly(), ScheduledFinishTime = new TimeOnly() };
            var batch2 = new Batches { StartTime = new TimeOnly(), FinishTime = new TimeOnly(), ScheduledFinishTime = new TimeOnly() };

            db.Batches.Add(batch1);
            db.Batches.Add(batch2);

            var delivery1 = new Deliveries { TrackId = 1, Location = "", OrderId = 1, SupermarketId = 1 };
            var delivery2 = new Deliveries { TrackId = 2, Location = "", OrderId = 2, SupermarketId = 2 };

            db.Deliveries.Add(delivery1);
            db.Deliveries.Add(delivery2);

            var ingredient1 = new Ingredients { Name = "", Quantity = 2 };
            var ingredient2 = new Ingredients { Name = "", Quantity = 3 };

            db.Ingredients.Add(ingredient1);
            db.Ingredients.Add(ingredient2);

            var supermarket1 = new Supermarkets { Name = "", Address = "" };
            var supermarket2 = new Supermarkets { Name = "", Address = "" };

            db.Supermarkets.Add(supermarket1);
            db.Supermarkets.Add(supermarket2);

            db.SaveChanges();
        }
    }
}
