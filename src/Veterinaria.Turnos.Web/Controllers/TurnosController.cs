using Microsoft.AspNetCore.Mvc;

namespace Veterinaria.Turnos.Web.Controllers
{
	public class TurnosController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
