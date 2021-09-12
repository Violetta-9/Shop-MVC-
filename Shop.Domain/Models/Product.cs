using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
     public class Product
    { 
        public int Id { get;  private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public string Image { get; private set; }

        public Product()
        {

        }

        public Product(string name, string description, double price, string imagepath)
        {
            SetProductName(name);
            SetProductDiscription(description);
            SetProductPrice(price);
            SetProductImage(imagepath);

        }

        private void  SetProductName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name of Product cannot be empty",nameof(name));
            }

            Name = name;
        }
        private void SetProductDiscription(string discription)
        {
            if (string.IsNullOrWhiteSpace(discription))
            {
                throw new ArgumentException("Discription of Product cannot be empty", nameof(discription));
            }

            Description = discription;
        }
        private void SetProductPrice(double price)
        {
            if (price<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "price cannot be less than or equal to 0");
            }

            Price = price;
        }
        private void SetProductImage(string imagepath)
        {
            if (string.IsNullOrWhiteSpace(imagepath))
            {
                throw new ArgumentException("Name of Product cannot be empty", nameof(imagepath));
            }

            Image = imagepath;
        }
    }
}
