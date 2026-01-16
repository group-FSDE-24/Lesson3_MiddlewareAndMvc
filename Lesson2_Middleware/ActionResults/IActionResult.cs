using System.Net;

namespace Lesson3_MiddlewareAndMvc.ActionResults;

public interface IActionResult
{
    void ExecuteResult(HttpListenerContext context);
}
