using Lesson2_Middleware.Hosts.Abstract;
using Lesson2_Middleware.Middlewares.Concretes;

namespace Lesson2_Middleware.Hosts.Concrete;

public class StartUp : IStartUp
{
    public void Configuration(MiddlewareBuilder middleware)
    {
        middleware.UseMiddleware<LoggerMiddleware>();
        middleware.UseMiddleware<AutenticationMiddleware>();
        middleware.UseMiddleware<StaticFileMiddleware>();
    }
}
