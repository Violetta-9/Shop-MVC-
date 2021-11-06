using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
     public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int? OrderId { get; set; }

        public virtual ShopUser User { get;  private set; }
        public virtual Product Products { get; private set; }
        public virtual Order Order { get; set; }
        


        public Cart()
        {

        }

        public Cart(int productId,string userId,int quantity,int? orderId=null)
        {
            SetProductId(productId);
            SetUserId(userId);
            SetQuantity(quantity);
            SetOrderId(orderId);
            

        }

        public void SetUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || !Guid.TryParse(userId, out _))
            {
                throw new ArgumentException("userId is empty or incorrect GUID", nameof(userId));
            }

            UserId = userId;
        }

        public void SetProductId(int productId)
        {
            if (productId < 0)
            {
                throw new ArgumentNullException("productId cannot be less than zero", nameof(productId));
            }

            ProductId = productId;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("quantity cannot be less than zero", nameof(quantity));
            }

            Quantity = quantity;
        }

        public void SetOrderId(int? orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId),orderId,"orderId cannot be less than and equal to zero");
            }
            else if(OrderId>0)
            {
                throw new ArgumentException("the Order has been already make", nameof(OrderId));
            }

            OrderId = orderId;
        }

        public void AddQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity,
                    "quantity cannot be less than zero and equal it");
            }

            if (OrderId > 0) // если заказ уже оформлен
            {
                throw new ArgumentException("order has already been issued");
            }

            Quantity += quantity;
        }
        public void SubQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity,
                    "quantity cannot be less than zero and equal it");
            }

            if (OrderId > 0) // если заказ уже оформлен
            {
                throw new ArgumentException("order has already been issued");
            }

            Quantity -= quantity;
        }
    }
}
