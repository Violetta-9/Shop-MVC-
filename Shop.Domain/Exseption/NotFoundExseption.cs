using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Exseption
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string name,Object key):base($"Entity \"{name}\" ({key}) was not found.")
        {

        }
    }
}
