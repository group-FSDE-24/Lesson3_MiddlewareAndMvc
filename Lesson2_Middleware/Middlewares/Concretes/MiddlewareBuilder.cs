using Lesson2_Middleware.Middlewares.Abstracts;
using System.Text.Json;

namespace Lesson2_Middleware.Middlewares.Concretes;

public class MiddlewareBuilder
{
    public Stack<Type> middlewares = new Stack<Type>();

    public void UseMiddleware<T>() where T: IMiddleware
    {
        middlewares.Push(typeof(T));
    }

    public HttpHandler Build()
    {
        HttpHandler end = c => c.Response.Close();

        while (middlewares.Count != 0)
        {
            var removeMiddleware = middlewares.Pop();

            var middleware = Activator.CreateInstance(removeMiddleware) as IMiddleware;

            middleware!.Next = end;
            end = middleware.Handler;
        }

        return end;

    }

}
