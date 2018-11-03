using SIS.Framework.ActionResults.Base;
using SIS.Framework.Controllers;

namespace SIS.MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
