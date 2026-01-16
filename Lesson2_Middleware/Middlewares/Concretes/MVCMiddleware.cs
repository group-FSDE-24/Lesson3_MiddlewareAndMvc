using Lesson2_Middleware.Middlewares.Abstracts;
using Lesson3_MiddlewareAndMvc.Controllers.Abstract;
using System.Net;
using System.Reflection;

namespace Lesson3_MiddlewareAndMvc.Middlewares.Concretes;

public class MVCMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set; }

    public void Handler(HttpListenerContext httpListenerContext)
    {
        string? url = httpListenerContext.Request.Url.AbsolutePath;

        var data = url.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var controllerName = $"Lesson3_MiddlewareAndMvc.Controllers.Concretes.{data[0]}Controller";

        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly.GetType(controllerName);

        if (type is not null)
        {
            var controolerObj = Activator.CreateInstance(type) as Controller;

            if (controolerObj is not null)
            {
                var actionName = data[1];
                var action = type.GetMethod(actionName);

                if (action is not null)
                {
                    controolerObj.Context = httpListenerContext;

                    action.Invoke(controolerObj, null);
                }

            }

            Next?.Invoke(httpListenerContext);
        }
    }
}
