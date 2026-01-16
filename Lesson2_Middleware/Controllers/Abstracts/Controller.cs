using System.Net;

namespace Lesson3_MiddlewareAndMvc.Controllers.Abstract;

public abstract class Controller
{
    public HttpListenerContext Context { get; set; }


}
