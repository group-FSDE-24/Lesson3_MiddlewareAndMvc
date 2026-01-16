using System.Net;
using Lesson2_Middleware.Hosts.Abstract;
using Lesson2_Middleware.Middlewares.Abstracts;
using Lesson2_Middleware.Middlewares.Concretes;

namespace Lesson2_Middleware.Hosts.Concrete;

public class WebHost
{
    private int _port { get; set; }
    private HttpListener httpListener { get; set; }
    private HttpHandler httpHandler { get; set; } 
    private MiddlewareBuilder middlewareBuilder { get; set; } = new MiddlewareBuilder();


    public WebHost(int port)
    {
        _port = port;

        httpListener = new HttpListener();
        httpListener.Prefixes.Add($"http://localhost:{_port}/");
    }

    public void UseStartUp<T>() where T : IStartUp, new()
    {
        var startUp = new T();

        startUp.Configuration(middlewareBuilder);

        httpHandler = middlewareBuilder.Build();
    }

    public void Run()
    {
        httpListener.Start();

        Console.WriteLine($"Server started on {_port}");

        while (true)
        {
            var context = httpListener.GetContext();

            Task.Run(() =>
            {
                httpHandler.Invoke(context);
                context.Response.Close();
            });
        }




    }



}
