using System.Web.Mvc;


namespace Dental.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult CheckSession()
        {
            if (Session["Sesja"] == null)
            {
                return RedirectToAction("Login", "Logowanie");
            }
            return View();
        }
    }
}