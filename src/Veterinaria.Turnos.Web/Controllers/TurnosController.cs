using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Veterinaria.Turnos.Data.Data;
using Veterinaria.Turnos.Data.Entidades;

namespace Veterinaria.Turnos.Web.Controllers
{
	public class TurnosController : Controller
	{
		private readonly VeterinariaDbContext _context;

		public TurnosController(VeterinariaDbContext context)
        {
			_context = context;
		}

        public IActionResult Index()
		{
			return RedirectToAction("Index", "Ingreso");
		}

		public IActionResult IniciarReservaTurno(int clienteId)
		{
			Cliente cliente = ObtenerClientePorId(clienteId);
			return View();
		}


		private Cliente ObtenerClientePorId(int clienteId)
		{
			Cliente cliente = (from c in _context.Clientes
							   where c.Id == clienteId
							   select c).FirstOrDefault();

			return cliente;
		}
	}
}
