using System.Web.Mvc;

namespace NewChatClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }

    }
}