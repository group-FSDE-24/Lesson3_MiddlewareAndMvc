using Lesson2_Middleware.Middlewares.Concretes;

namespace Lesson2_Middleware.Hosts.Abstract;

public interface IStartUp
{
    void Configuration(MiddlewareBuilder middleware);
}
