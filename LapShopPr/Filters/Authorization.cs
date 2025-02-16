﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace LapShopPr.Filters
{
    public class Authorization:ActionFilterAttribute
    {

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string actionName = context.HttpContext.Request.RouteValues["action"].ToString();
            string controllerName = context.HttpContext.Request.RouteValues["controller"].ToString();
            // check in database if user has permnisstion
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
