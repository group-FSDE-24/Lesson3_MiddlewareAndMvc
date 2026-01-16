using System.Net;

namespace Lesson3_MiddlewareAndMvc.ActionResults;

public class ViewResult : IActionResult
{

    // localhost:27001/Omar/Index?username=admin&password=123
    public void ExecuteResult(HttpListenerContext context)
    {
        var section = context.Request.Url.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);

        var folderName = section[0];
        var fileName = section[1];

        var path = $"../../../Views/{folderName}/{fileName}.html";

        if(File.Exists(path))
        {
            var bytes = File.ReadAllBytes(path);

            context.Response.ContentType = "text/html";
            context.Response.OutputStream.Write(bytes, 0 , bytes.Length);
        }

    }
}
