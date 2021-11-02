
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using Microsoft.VisualBasic;

    namespace Shop.Domain.Models
    {
        public class Review
        {

            public int Id { get; private set; }
            public DateTime Data { get; set; }
        public string UserId { get; private set; }
            public int ProductId { get; private set; }
            public string Text { get;  private set; }
            public int Rating { get;private set; }
           


            public virtual Product Product { get; private set; }
            public virtual ShopUser User { get; private set; }

            public Review()
            {
                Data = DateTime.UtcNow;
            }

            public Review(string text, int rating, string userId, int productId)
            {
                SetText(text);
                SetRating(rating);
                SetUserId(userId);
                SetProductId(productId);
                Data = DateTime.UtcNow;
            }

            public void SetText(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentNullException("review text cannot be empty", nameof(text));
                }

                Text = text;
            }

            public void SetRating(int rating)
            {
                if (rating < 0)
                {
                    throw new ArgumentException("rating cannot be less than zero", nameof(rating));
                }

                Rating = rating;
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
        }
    }


