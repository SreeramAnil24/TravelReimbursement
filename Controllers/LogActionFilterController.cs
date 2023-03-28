using Microsoft.AspNetCore.Mvc;
using EmpManage.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Empmanage.Controllers;
public class LogAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        Log("OnActionExecuted", filterContext.RouteData); 
    }

   

    private void Log(string methodName, RouteData routeData)
    {
        var controllerName = routeData.Values["controller"];
        var actionName = routeData.Values["action"];
        var message = String.Format("{0}-    controller:{1}    action:{2}", methodName, controllerName,actionName);
        Console.WriteLine(message);
    }
}