using System;
using System.Linq;

namespace MarketDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                Product product1 = new Product { Name = "Разработчик в виде порошка", Price = 49f };
                Product product2 = new Product { Name = "Черноголовка Байкал", Price = 89.99f };
                SalesPoint salesPoint1 = new SalesPoint { Name = "Победа" };
                SalesPoint salesPoint2 = new SalesPoint { Name = "Пятерочка" };
                ProvidedProduct providedProduct1 = new ProvidedProduct { SalesPoint = salesPoint1, Product = product1, ProductQuantity = 10 };
                ProvidedProduct providedProduct2 = new ProvidedProduct { SalesPoint = salesPoint1, Product = product2, ProductQuantity = 60 };
                ProvidedProduct providedProduct3 = new ProvidedProduct { SalesPoint = salesPoint2, Product = product1, ProductQuantity = 15 };
                Buyer buyer1 = new Buyer { Name = "Влад" };
                Sale sale1 = new Sale { SalesPoint = salesPoint1, Buyer = buyer1, TotalAmount = product1.Price };
                SaleData saleData1 = new SaleData { Product = product1, Sale = sale1, ProductIdAmount = product1.Price };


                // добавляем их в бд
                db.ProvidedProducts.AddRange(providedProduct1, providedProduct2, providedProduct3);
                db.SalesData.Add(saleData1);
                db.SaveChanges();
            }
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var products = db.Products.ToList();
            //    Console.WriteLine("Users list:");
            //    foreach (Product u in products)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Price}");
            //    }
            //}
        }
    }
}
