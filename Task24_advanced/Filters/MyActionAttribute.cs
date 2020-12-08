using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task24_advanced.FIlters
{
    public class MyActionAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }


        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("[{0}]: {1} controller:{2} action:{3}\n",DateTime.UtcNow, methodName, controllerName, actionName);
            FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myLog.txt"), FileMode.Append, FileAccess.Write);
            StreamWriter swr = new StreamWriter(fs);
            swr.Write(message);
            swr.Close();


        }
    }
}