using Lesson3_MiddlewareAndMvc.ActionResults;
using System.Net;

namespace Lesson3_MiddlewareAndMvc.Controllers.Abstract;

public abstract class Controller
{
    public HttpListenerContext Context { get; set; }

    public IActionResult View()
    {
        var viewResult = new ViewResult();

        viewResult.ExecuteResult(Context);
        return viewResult;
    }
}
