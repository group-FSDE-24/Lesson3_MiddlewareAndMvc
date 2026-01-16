using System.Net;
using Lesson2_Middleware.Middlewares.Abstracts;

namespace Lesson2_Middleware.Middlewares.Concretes;

public class StaticFileMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set; }

    // localhost:27001/index.html?username=admin&password=123
    public void Handler(HttpListenerContext httpListenerContext)
    {
        Console.WriteLine("Static File ise basladi....");

        if (Path.HasExtension(httpListenerContext.Request.Url.AbsolutePath.Substring(1)))
        {
            string path = "C:\\Users\\karimzade_k\\source\\repos\\Lesson2_Middleware\\Lesson2_Middleware\\Views\\";

            try
            {
                // / index
                string? fileName = httpListenerContext.Request.Url.AbsolutePath.Substring(1);
                // kamran.png
                path = "C:\\Users\\karimzade_k\\source\\repos\\Lesson2_Middleware\\Lesson2_Middleware\\Views\\" + fileName;

                if (Path.GetExtension(fileName) != ".html")
                    path = $"C:\\Users\\karimzade_k\\source\\repos\\Lesson2_Middleware\\Lesson2_Middleware\\wwwroot\\{fileName}";

                var bytes = File.ReadAllBytes(path);
                httpListenerContext.Response.ContentType = GetContentType(path);
                httpListenerContext.Response.OutputStream.Write(bytes);
            }
            catch (Exception ex)
            {
                path = "C:\\Users\\karimzade_k\\source\\repos\\Lesson2_Middleware\\Lesson2_Middleware\\Views\\NotFound.html";

                var bytes = File.ReadAllBytes(path);
                httpListenerContext.Response.ContentType = GetContentType(path);
                httpListenerContext.Response.OutputStream.Write(bytes);

            }
        }



        Next?.Invoke(httpListenerContext);
    }

    private string GetContentType(string path)
    {
        string contentType = "text/html";

        switch (Path.GetExtension(path).ToLower())
        {
            case ".css":
                contentType = "text/css";
                break;

            case ".js":
                contentType = "text/javascript";
                break;

            // Şəkillər
            case ".png":
                contentType = "image/png";
                break;

            case ".jpg":
            case ".jpeg":
                contentType = "image/jpeg";
                break;

            case ".gif":
                contentType = "image/gif";
                break;

            case ".svg":
                contentType = "image/svg+xml";
                break;

            case ".webp":
                contentType = "image/webp";
                break;

            // PDF
            case ".pdf":
                contentType = "application/pdf";
                break;
        }

        return contentType;
    }
}
