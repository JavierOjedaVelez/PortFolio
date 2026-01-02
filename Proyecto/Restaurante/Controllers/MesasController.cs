using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    public class MesasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
