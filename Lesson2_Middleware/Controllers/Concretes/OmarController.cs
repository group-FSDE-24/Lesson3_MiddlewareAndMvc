using Lesson3_MiddlewareAndMvc.ActionResults;
using Lesson3_MiddlewareAndMvc.Controllers.Abstract;
using System.ComponentModel.Design;

namespace Lesson3_MiddlewareAndMvc.Controllers.Concretes;

public class OmarController : Controller
{

    public IActionResult Index() => View();

}
