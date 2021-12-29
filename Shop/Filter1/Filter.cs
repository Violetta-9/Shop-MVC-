using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Domain.Exseption;


namespace Shop.Filter1
{
    public class Filter : System.Attribute, IExceptionFilter
    {

        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is NotFoundException)
            {
                exceptionContext.Result = new RedirectResult("/Views/Shared/ExceptionFound.cshtml");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
