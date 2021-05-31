using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mwnz.Company.Facade.WebApi.Controllers.Specification;
using Mwnz.Company.Source.Xml.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi.Controllers.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is CompanyXmlApiException)
            {
                CompanyXmlApiException apiException = (CompanyXmlApiException)context.Exception;
                context.Result = new ObjectResult(
                        new Error { Error1 = apiException.StatusCode.ToString(), Error_description = apiException.Response }
                    )
                {
                    StatusCode = apiException.StatusCode,
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception != null)
            {
                context.Result = new ObjectResult("Internal Server Error")
                {
                    StatusCode = 500,
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
