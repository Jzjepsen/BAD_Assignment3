﻿using Bakery.Context;
using Bakery.Models;

namespace Bakery.Data
{
    public class SeedData
    {
        public SeedData()
        { }

        public void Seed(MyDbContext db)
        {
            // Independent entities
            
            var supermarket1 = new Supermarkets { Name = "Netto", Address = "Thorvaldsensgade 22" };
            var supermarket2 = new Supermarkets { Name = "Meny", Address = "Skanderborgvej 18" };
            var supermarket3 = new Supermarkets { Name = "Rema 1000", Address = "Frederiksgade 82" };
            var supermarket4 = new Supermarkets { Name = "Føtex", Address = "Frederiks Allé 22" };
            var supermarket5 = new Supermarkets { Name = "Coop365", Address = "Vestergade 55B" };

            db.Supermarkets.Add(supermarket1);
            db.Supermarkets.Add(supermarket2);
            db.Supermarkets.Add(supermarket3);
            db.Supermarkets.Add(supermarket4);
            db.Supermarkets.Add(supermarket5);
            
            var ingredient1 = new Ingredients { Name = "Flour", Quantity = 100 };
            var ingredient2 = new Ingredients { Name = "Sugar", Quantity = 200 };
            var ingredient3 = new Ingredients { Name = "Butter", Quantity = 150 };
            var ingredient4 = new Ingredients { Name = "Eggs", Quantity = 300 };
            var ingredient5 = new Ingredients { Name = "Milk", Quantity = 200 };

            db.Ingredients.Add(ingredient1);
            db.Ingredients.Add(ingredient2);
            db.Ingredients.Add(ingredient3);
            db.Ingredients.Add(ingredient4);
            db.Ingredients.Add(ingredient5);
            
            var order1 = new Orders { Date = new DateOnly(2023, 1, 1), DeliveryPlace = "Aarhus" };
            var order2 = new Orders { Date = new DateOnly(2023, 1, 2), DeliveryPlace = "Aarhus" };
            var order3 = new Orders { Date = new DateOnly(2023, 1, 3), DeliveryPlace = "Aarhus" };
            var order4 = new Orders { Date = new DateOnly(2023, 1, 4), DeliveryPlace = "Aarhus" };
            var order5 = new Orders { Date = new DateOnly(2023, 1, 5), DeliveryPlace = "Aarhus" };

            db.Orders.Add(order1);
            db.Orders.Add(order2);
            db.Orders.Add(order3);
            db.Orders.Add(order4);
            db.Orders.Add(order5);
            
            db.SaveChanges();
            
            // Entities dependent on independent entities

            var bakingGood1 = new BakingGoods { Name = "Bread", Price = 10, Quantity = 100 };
            var bakingGood2 = new BakingGoods { Name = "Cake", Price = 30, Quantity = 150 };
            var bakingGood3 = new BakingGoods { Name = "Cookies", Price = 15, Quantity = 200 };
            var bakingGood4 = new BakingGoods { Name = "Muffins", Price = 20, Quantity = 300 };
            var bakingGood5 = new BakingGoods { Name = "Pies", Price = 60, Quantity = 200 };

            db.BakingGoods.Add(bakingGood1);
            db.BakingGoods.Add(bakingGood2);
            db.BakingGoods.Add(bakingGood3);
            db.BakingGoods.Add(bakingGood4);
            db.BakingGoods.Add(bakingGood5);

            var batch1 = new Batches { StartTime = new TimeOnly(8,00), FinishTime = new TimeOnly(10,00), ScheduledFinishTime = new TimeOnly(9,30) };
            var batch2 = new Batches { StartTime = new TimeOnly(9,00), FinishTime = new TimeOnly(11,00), ScheduledFinishTime = new TimeOnly(10,00) };
            var batch3 = new Batches { StartTime = new TimeOnly(10,00), FinishTime = new TimeOnly(12,00), ScheduledFinishTime = new TimeOnly(11,50) };
            var batch4 = new Batches { StartTime = new TimeOnly(11,00), FinishTime = new TimeOnly(13,00), ScheduledFinishTime = new TimeOnly(12,30) };
            var batch5 = new Batches { StartTime = new TimeOnly(12,00), FinishTime = new TimeOnly(14,00), ScheduledFinishTime = new TimeOnly(13,40) };
            
            db.Batches.Add(batch1);
            db.Batches.Add(batch2);
            db.Batches.Add(batch3);
            db.Batches.Add(batch4);
            db.Batches.Add(batch5);
            
            db.SaveChanges();
            
            var delivery1 = new Deliveries { Location = "Aarhus", OrderId = 1, SupermarketId = 1 };
            var delivery2 = new Deliveries { Location = "Aarhus", OrderId = 2, SupermarketId = 2 };
            var delivery3 = new Deliveries { Location = "Aarhus", OrderId = 3, SupermarketId = 3 };
            var delivery4 = new Deliveries { Location = "Aarhus", OrderId = 4, SupermarketId = 4 };
            var delivery5 = new Deliveries { Location = "Aarhus", OrderId = 5, SupermarketId = 5 };

            db.Deliveries.Add(delivery1);
            db.Deliveries.Add(delivery2);
            db.Deliveries.Add(delivery3);
            db.Deliveries.Add(delivery4);
            db.Deliveries.Add(delivery5);
            
            // Relational entities
            
            var batchIngredient1 = new BatchIngredient { BatchId = 1, IngredientId = 1};
            var batchIngredient2 = new BatchIngredient { BatchId = 1, IngredientId = 2, };
            var batchIngredient3 = new BatchIngredient { BatchId = 1, IngredientId = 4, };
            
            var batchIngredient4 = new BatchIngredient { BatchId = 2, IngredientId = 2, };
            var batchIngredient5 = new BatchIngredient { BatchId = 2, IngredientId = 3, };
            var batchIngredient6 = new BatchIngredient { BatchId = 2, IngredientId = 5, };
            
            var batchIngredient7 = new BatchIngredient { BatchId = 3, IngredientId = 3, };
            var batchIngredient8 = new BatchIngredient { BatchId = 3, IngredientId = 4, };
            var batchIngredient9 = new BatchIngredient { BatchId = 3, IngredientId = 1, };
            
            var batchIngredient10 = new BatchIngredient { BatchId = 4, IngredientId = 4, };
            var batchIngredient11 = new BatchIngredient { BatchId = 4, IngredientId = 5, };
            var batchIngredient12 = new BatchIngredient { BatchId = 4, IngredientId = 1, };
            
            var batchIngredient13 = new BatchIngredient { BatchId = 5, IngredientId = 1, };
            var batchIngredient14 = new BatchIngredient { BatchId = 5, IngredientId = 2, };
            var batchIngredient15 = new BatchIngredient { BatchId = 5, IngredientId = 3, };
            var batchIngredient16 = new BatchIngredient { BatchId = 5, IngredientId = 4, };
            var batchIngredient17 = new BatchIngredient { BatchId = 5, IngredientId = 5, };
            
            db.BatchIngredients.Add(batchIngredient1);
            db.BatchIngredients.Add(batchIngredient2);
            db.BatchIngredients.Add(batchIngredient3);
            db.BatchIngredients.Add(batchIngredient4);
            db.BatchIngredients.Add(batchIngredient5);
            db.BatchIngredients.Add(batchIngredient6);
            db.BatchIngredients.Add(batchIngredient7);
            db.BatchIngredients.Add(batchIngredient8);
            db.BatchIngredients.Add(batchIngredient9);
            db.BatchIngredients.Add(batchIngredient10);
            db.BatchIngredients.Add(batchIngredient11);
            db.BatchIngredients.Add(batchIngredient12);
            db.BatchIngredients.Add(batchIngredient13);
            db.BatchIngredients.Add(batchIngredient14);
            db.BatchIngredients.Add(batchIngredient15);
            db.BatchIngredients.Add(batchIngredient16);
            db.BatchIngredients.Add(batchIngredient17);
            
            var bakingGoodBatch1 = new BakingGoodBatch { BakingGoodId = 1, BatchId = 1 };
            var bakingGoodBatch2 = new BakingGoodBatch { BakingGoodId = 2, BatchId = 2 };
            var bakingGoodBatch3 = new BakingGoodBatch { BakingGoodId = 3, BatchId = 3 };
            var bakingGoodBatch4 = new BakingGoodBatch { BakingGoodId = 4, BatchId = 4 };
            var bakingGoodBatch5 = new BakingGoodBatch { BakingGoodId = 5, BatchId = 5 };
            
            db.BakingGoodBatches.Add(bakingGoodBatch1);
            db.BakingGoodBatches.Add(bakingGoodBatch2);
            db.BakingGoodBatches.Add(bakingGoodBatch3);
            db.BakingGoodBatches.Add(bakingGoodBatch4);
            db.BakingGoodBatches.Add(bakingGoodBatch5);
            
            var orderBakingGood1 = new OrderBakingGood { OrderId = 1, BakingGoodId = 1 };
            var orderBakingGood2 = new OrderBakingGood { OrderId = 1, BakingGoodId = 2 };
            var orderBakingGood3 = new OrderBakingGood { OrderId = 1, BakingGoodId = 3 };
            
            var orderBakingGood4 = new OrderBakingGood { OrderId = 2, BakingGoodId = 2 };
            var orderBakingGood5 = new OrderBakingGood { OrderId = 2, BakingGoodId = 4 };
            
            var orderBakingGood6 = new OrderBakingGood { OrderId = 3, BakingGoodId = 3 };
            var orderBakingGood7 = new OrderBakingGood { OrderId = 3, BakingGoodId = 4 };
            var orderBakingGood8 = new OrderBakingGood { OrderId = 3, BakingGoodId = 5 };
            
            var orderBakingGood9 = new OrderBakingGood { OrderId = 4, BakingGoodId = 4 };
            var orderBakingGood10 = new OrderBakingGood { OrderId = 4, BakingGoodId = 5 };
            
            var orderBakingGood11 = new OrderBakingGood { OrderId = 5, BakingGoodId = 1 };
            var orderBakingGood12 = new OrderBakingGood { OrderId = 5, BakingGoodId = 2 };
            var orderBakingGood13 = new OrderBakingGood { OrderId = 5, BakingGoodId = 3 };
            var orderBakingGood14 = new OrderBakingGood { OrderId = 5, BakingGoodId = 4 };
            var orderBakingGood15 = new OrderBakingGood { OrderId = 5, BakingGoodId = 5 };
            
            db.OrderBakingGoods.Add(orderBakingGood1);
            db.OrderBakingGoods.Add(orderBakingGood2);
            db.OrderBakingGoods.Add(orderBakingGood3);
            db.OrderBakingGoods.Add(orderBakingGood4);
            db.OrderBakingGoods.Add(orderBakingGood5);
            db.OrderBakingGoods.Add(orderBakingGood6);
            db.OrderBakingGoods.Add(orderBakingGood7);
            db.OrderBakingGoods.Add(orderBakingGood8);
            db.OrderBakingGoods.Add(orderBakingGood9);
            db.OrderBakingGoods.Add(orderBakingGood10);
            db.OrderBakingGoods.Add(orderBakingGood11);
            db.OrderBakingGoods.Add(orderBakingGood12);
            db.OrderBakingGoods.Add(orderBakingGood13);
            db.OrderBakingGoods.Add(orderBakingGood14);
            db.OrderBakingGoods.Add(orderBakingGood15);
            
            db.SaveChanges();
        }
    }
}