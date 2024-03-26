using System.Runtime.Loader;
using Bakery.Context;
using Bakery.Models;

namespace Bakery.Data
{
    public class SeedData
    {
        public SeedData()
        { }

        public void Seed(MyDbContext db)
        {  

            // Seeding allergens Migration1
            var allergenGluten = new Allergen { Name = "Flour" };
            var allergenEggs = new Allergen { Name = "Eggs" };
            var allergenDairy = new Allergen { Name = "Milk" };
            var allergenNuts = new Allergen { Name = "Nuts" };
            
            addAllergenIfNotExists(db, allergenGluten);
            addAllergenIfNotExists(db, allergenEggs);
            addAllergenIfNotExists(db, allergenDairy);
            addAllergenIfNotExists(db, allergenNuts);
            db.SaveChanges();

            void addAllergenIfNotExists(MyDbContext db, Allergen allergen)
            {
                if (!db.Allergens.Any(a => a.Name == allergen.Name))
                {
                    db.Allergens.Add(allergen);
                }
            }

            db.SaveChanges();
            
            // Seeding ingredients with validation
            AddIngredientIfNotExists(db, new Ingredients { Name = "Flour", Quantity = 100 });
            AddIngredientIfNotExists(db, new Ingredients { Name = "Sugar", Quantity = 200 });
            AddIngredientIfNotExists(db, new Ingredients { Name = "Butter", Quantity = 150 });
            AddIngredientIfNotExists(db, new Ingredients { Name = "Eggs", Quantity = 300 });
            AddIngredientIfNotExists(db, new Ingredients { Name = "Milk", Quantity = 200 });
            AddIngredientIfNotExists(db, new Ingredients { Name = "Nuts", Quantity = 4000 });

            db.SaveChanges();
            
            void AddIngredientIfNotExists(MyDbContext db, Ingredients ingredient)
            {
                if (!db.Ingredients.Any(i => i.Name == ingredient.Name))
                {
                    db.Ingredients.Add(ingredient);
                }
                else
                {
                    // Optionally, update the quantity of existing ingredients
                    var existingIngredient = db.Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
                    if (existingIngredient != null)
                    {
                        existingIngredient.Quantity += ingredient.Quantity;
                    }
                }
            }
            
            // associate allergens w. ingredients
            AssociateIngredientAllergen(db, "Flour", "Flour");
            AssociateIngredientAllergen(db, "Eggs", "Eggs");
            AssociateIngredientAllergen(db, "Milk", "Milk");
            AssociateIngredientAllergen(db, "Nuts", "Nuts");

            void AssociateIngredientAllergen(MyDbContext db, string ingredientName, string allergenName)
            {
                var ingredient = db.Ingredients.FirstOrDefault(i => i.Name == ingredientName);
                var allergen = db.Allergens.FirstOrDefault(a => a.Name == allergenName);

                if (ingredient != null && allergen != null)
                {
                    var exists = db.IngredientAllergens.Any(ia =>
                        ia.IngredientId == ingredient.IngredientId && ia.AllergenId == allergen.AllergenId);
                    if (!exists)
                    {
                        db.IngredientAllergens.Add(new IngredientAllergen
                        {
                            IngredientId = ingredient.IngredientId,
                            AllergenId = allergen.AllergenId
                        });
                    }
                }
            }
            
            AddOrderIfNotExists(db, new Orders { Date = "01022024 1030"});
            AddOrderIfNotExists(db, new Orders { Date = "01032024 1130"});
            AddOrderIfNotExists(db, new Orders { Date = "01042024 1230"});
            AddOrderIfNotExists(db, new Orders { Date = "01052024 1330"});
            AddOrderIfNotExists(db, new Orders { Date = "01062024 1430"});

            db.SaveChanges();
            
            void AddOrderIfNotExists(MyDbContext db, Orders order)
            {
                if (!db.Orders.Any(o => o.Date == order.Date && o.DeliveryPlace == order.DeliveryPlace))
                {
                    db.Orders.Add(order);
                }
            }
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
            
            // Seeding deliveries with validation
            AddDeliveryIfNotExists(db, new Deliveries { DeliveryOrderId = 1, SupermarketId = 1 });
            AddDeliveryIfNotExists(db, new Deliveries { DeliveryOrderId = 2, SupermarketId = 2 });
            AddDeliveryIfNotExists(db, new Deliveries { DeliveryOrderId = 3, SupermarketId = 3 });
            AddDeliveryIfNotExists(db, new Deliveries { DeliveryOrderId = 4, SupermarketId = 4 });
            AddDeliveryIfNotExists(db, new Deliveries { DeliveryOrderId = 5, SupermarketId = 5 });

            db.SaveChanges();
            
            void AddDeliveryIfNotExists(MyDbContext db, Deliveries delivery)
            {
                if (!db.Deliveries.Any(d => d.DeliveryOrderId == delivery.DeliveryOrderId && d.SupermarketId == delivery.SupermarketId))
                {
                    db.Deliveries.Add(delivery);
                }
                
            }
            
            
            //addresses
            var address1 = new Address{Street = "Thorvaldsensgade", Zip = "8600", Latitude = 55.6761, Longitude = 12.5683, DeliveryId = 1};
            var address2 = new Address{Street = "Nygade", Zip = "8600", Latitude = 54.6761, Longitude = 11.5683, DeliveryId = 2};
            var address3 = new Address{Street = "Nørregade", Zip = "8000", Latitude = 53.6761, Longitude = 13.5683, DeliveryId = 3};
            var address4 = new Address{Street = "Bagerivej", Zip = "8200", Latitude = 51.6761, Longitude = 11.5683, DeliveryId = 4};
            var address5 = new Address{Street = "Lærkevej", Zip = "8210", Latitude = 54.6761, Longitude = 11.5443, DeliveryId = 5};

            
            addAddressIfNotExists(db, address1);
            addAddressIfNotExists(db, address2);
            addAddressIfNotExists(db, address3);
            addAddressIfNotExists(db, address4);
            addAddressIfNotExists(db, address5);
            db.SaveChanges();

            void addAddressIfNotExists(MyDbContext db, Address address)
            {
                // Checking if an address already exists based on Street and Zip
                if (!db.Addresses.Any(a => a.Street == address.Street && a.Zip == address.Zip))
                {
                    db.Addresses.Add(address);
                }
            }
            
            
            // Supermarkets
            AddSupermarketIfNotExists(db, new Supermarkets { Name = "Netto", AddressId = address1.AddressId});
            AddSupermarketIfNotExists(db, new Supermarkets { Name = "Netto", AddressId = address2.AddressId });
            AddSupermarketIfNotExists(db, new Supermarkets { Name = "Meny", AddressId = address3.AddressId });
            AddSupermarketIfNotExists(db, new Supermarkets { Name = "Rema 1000", AddressId = address4.AddressId });
            AddSupermarketIfNotExists(db, new Supermarkets { Name = "Føtex", AddressId = address5.AddressId});
            db.SaveChanges();

            void AddSupermarketIfNotExists(MyDbContext db, Supermarkets supermarket)
            {
                if (!db.Supermarkets.Any(s => s.AddressId == supermarket.AddressId))
                {
                    db.Supermarkets.Add(supermarket);
                }
            }
            
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
