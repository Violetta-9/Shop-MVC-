using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
     public class Order
    {
        public int  Id{ get;  private set; }
        public DateTime OrderDate { get; set; }
        public double Cost { get;  private set; }
        public string UserId { get;  private set; }
        public virtual ShopUser User { get; set; }

        public Order()
        {
            OrderDate=DateTime.UtcNow;
        }

        public Order(double cost,string userId) : this()
        {
            SetCost(cost);
            SetUserId(userId);

        }
        public void SetUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || !Guid.TryParse(userId, out _))
            {
                throw new ArgumentException("userId is empty or incorrect GUID", nameof(userId));
            }

            UserId = userId;
        }

        public void SetCost(double cost)
        {
            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cost),"gost cannot be less than zero" );
            }

            Cost = cost;
        }
    }
}
