using Shop.DataAccess;
using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests
{
    public class DateBaseTest
    {
        public string UserId { get; private set; }
        private readonly ApplicationDbContext _db;

       
        public DateBaseTest()
        {
            _db = GetDate();
        }

        public ApplicationDbContext GetDate()
        {
            if(_db!=null)
            {
                return _db;
            }

            var conection = new SqliteConnection("DataSource=:memory:");
            conection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(conection).Options;
             var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            InitDbContext(context);
            return context;

        }

        public void InitDbContext(ApplicationDbContext context)
        {
            var firstVendor = new Vendor("Sdoba", "Fast delivery");
            var secondVendor = new Vendor("Word", "3 day warranty");
            context.Vendors.AddRange(firstVendor,secondVendor);
            context.SaveChanges();
            var firstCategory = new Category("Food");
            var secondCategory = new Category("Technic");
            context.Categories.AddRange(firstCategory,secondCategory);

            var firstProduct = new Product("Apple", "testy", 2.0, "test/test.png", 1 ,1);
            var secondProduct = new Product("Banana", "testy", 4.0, "test/test.png", 2, 2);
            context.Products.AddRange(firstProduct,secondProduct);
            InitUser(context);

            var review = new Review("test", 3, UserId, firstProduct.Id);
            context.Reviews.Add(review);

            var productInCart = new Cart(firstProduct.Id, UserId, 1);
            context.Carts.Add(productInCart);

            var productInLikedCart = new Liked(UserId, firstProduct.Id);
            context.Likeds.Add(productInLikedCart);

            var order = new Order(4.1, UserId);
            context.Orders.Add(order);

            context.SaveChanges();


        }

        public void InitUser(ApplicationDbContext context)
        {
            var user = new ShopUser("DS", "Vasja", "Pupkin", "Thalow", "45567", "rttp@gmail.com");
            context.Users.Add(user);
            context.SaveChanges();
            UserId = user.Id;
        }
    }
}
