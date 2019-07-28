using System.Web.Mvc;

namespace Dental.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult MenuAdmin()
        {
            return View();
        }
    }
}