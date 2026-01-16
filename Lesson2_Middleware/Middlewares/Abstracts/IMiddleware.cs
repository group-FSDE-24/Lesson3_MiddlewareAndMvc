using System.Net;

namespace Lesson2_Middleware.Middlewares.Abstracts;


public delegate void HttpHandler(HttpListenerContext listenerContext);

public interface IMiddleware
{
    void Handler(HttpListenerContext httpListenerContext);
    HttpHandler? Next { get; set; }
}
