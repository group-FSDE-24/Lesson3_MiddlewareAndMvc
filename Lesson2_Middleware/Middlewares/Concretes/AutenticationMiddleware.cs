using System.Net;
using System.Text;
using Lesson2_Middleware.Middlewares.Abstracts;

namespace Lesson2_Middleware.Middlewares.Concretes;

// localhost:27001/contact?username=admin&password=123
public class AutenticationMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set; }

    public void Handler(HttpListenerContext httpListenerContext)
    {
        Console.WriteLine("Authentication ise baslayir ....");

        var username = httpListenerContext.Request.QueryString["username"];
        var password = httpListenerContext.Request.QueryString["password"];


        if(username=="admin" && password == "123")
        {
            Next?.Invoke(httpListenerContext);

            Console.WriteLine("Authentication ugurlu basa catdi");
        }
        else
        {
            httpListenerContext.Response.StatusCode = 401;
            httpListenerContext.Response.OutputStream.Write(Encoding.UTF8.GetBytes("Admin sisteme login ola bilmedi..."));
        }


    }
}
