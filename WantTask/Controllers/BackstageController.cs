


using Microsoft.AspNetCore.Mvc;

namespace WantTask.Controllers
{
    public class BackstageController : Controller
    {
        public IActionResult Approve()
        {
            return View("Approve");
        }
    }
}
