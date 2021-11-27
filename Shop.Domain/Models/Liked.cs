using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
     public class Liked
    {
        public int  Id { get;  private set; }
        public string UserId { get; private set; }
        public int ProductId { get; private set; }
        public virtual Product Products { get;  private set; }
        public virtual ShopUser User { get; private set; }

        public Liked()
        {

        }

        public Liked(string userId, int productId)
        {
            SetProductId(productId);
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

        public void SetProductId(int productId)
        {
            if (productId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId),"productId cannot be less than zero");
            }

            ProductId = productId;
        }
    }
}
