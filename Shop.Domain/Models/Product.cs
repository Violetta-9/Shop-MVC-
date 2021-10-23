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
        public int VendorId { get; private set; }
        public int CategoryId { get; private set; }
        public virtual Vendor Vendors { get; private set; }
        public virtual Category Categories { get; private set; }

        public Product()
        {

        }

        public Product(string name, string description, double price, string imagepath,int vendorId,int categoryId)
        {
            SetProductName(name);
            SetProductDiscription(description);
            SetProductPrice(price);
            SetProductImage(imagepath);
            SetProductCategory(categoryId);
            SetProductVendor(vendorId);

        }

        public void  SetProductName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name of Product cannot be empty",nameof(name));
            }

            Name = name;
        }
        public  void SetProductDiscription(string discription)
        {
            if (string.IsNullOrWhiteSpace(discription))
            {
                throw new ArgumentException("Discription of Product cannot be empty", nameof(discription));
            }

            Description = discription;
        }
        public void SetProductPrice(double price)
        {
            if (price<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "price cannot be less than or equal to 0");
            }

            Price = price;
        }
        public  void SetProductImage(string imagepath)
        {
            if (string.IsNullOrWhiteSpace(imagepath))
            {
                throw new ArgumentException("Name of Product cannot be empty", nameof(imagepath));
            }

            Image = imagepath;
        }
        public void SetProductCategory(int category)
        {
            if (category <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(category), category, "categoryId cannot be less than or equal to 0");
            }

            CategoryId = category;
        }
        public void SetProductVendor(int vendor)
        {
            if (vendor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vendor), vendor, "VendorId cannot be less than or equal to 0");
            }

            VendorId = vendor;
        }
    }
}
