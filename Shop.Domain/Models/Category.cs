using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
     public class Category
     {
         public int Id { get; private set; }
         public string Name { get; set; }

         public Category(){}
         public Category(string name)
         {
             SetName(name);

         }
         private void SetName(string name)
         {
             if (string.IsNullOrWhiteSpace(name))
             {
                 throw new ArgumentNullException("name can not be empty", nameof(name));
             }

             Name = name;
         }
    }
     
}
