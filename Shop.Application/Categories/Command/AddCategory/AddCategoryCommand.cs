using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.Categories.Command
{
   public  class AddCategoryCommand:IRequest<int>
   { 
       public string Name { get; set; }

       public AddCategoryCommand(string name)
       {
           Name = name;
       }
   }
}
