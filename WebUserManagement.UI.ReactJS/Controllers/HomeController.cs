using System.Configuration;
using System.Web.Mvc;

namespace WebUserManagement.UI.ReactJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.BaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrl");
            return View();
        }
    }
}