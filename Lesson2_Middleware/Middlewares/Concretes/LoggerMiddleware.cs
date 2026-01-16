using System.Net;
using Lesson2_Middleware.Middlewares.Abstracts;

namespace Lesson2_Middleware.Middlewares.Concretes;

public class LoggerMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set; }

    public void Handler(HttpListenerContext httpListenerContext)
    {
        Console.WriteLine($"Request Loglanir ... {httpListenerContext.Request.RawUrl}");

        Next?.Invoke(httpListenerContext);

        Console.WriteLine("Response Loglandi...");
    }
}
