using Microsoft.AspNetCore.Mvc;
using Veterinaria.Turnos.Data.Data;
using Veterinaria.Turnos.Data.Entidades;

namespace Veterinaria.Turnos.Web.Controllers
{
	public class IngresoController : Controller
	{
		private readonly VeterinariaDbContext _context;
		public IngresoController(VeterinariaDbContext context)
		{
			_context = context;
		}

		// GET: Ingreso
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Index(string numeroDocumento, string email)
		{
			Cliente cliente = (from c in _context.Clientes
							   where c.NumeroDocumento.ToString() == numeroDocumento && c.Email == email
							   select c).FirstOrDefault();

			if (cliente == null)
			{
				ViewBag.ErrorMessage = "Cliente no encontrado";
				return View();
			}

			return RedirectToAction("IniciarReservaTurno", "Turnos", new { clienteId = cliente.Id });

		}

	}
}
