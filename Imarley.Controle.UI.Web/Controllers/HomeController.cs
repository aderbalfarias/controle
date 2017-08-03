using System.Web.Mvc;

namespace Imarley.Controle.UI.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}