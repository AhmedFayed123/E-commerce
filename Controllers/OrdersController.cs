using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eStore.Models;

namespace eStore.Controllers
{
	[Authorize]
	public class OrdersController : Controller
	{
		private readonly eStoreDBContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public OrdersController(eStoreDBContext db, UserManager<ApplicationUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);

			// Assume o.CreatedBy is Guid
			var userGuid = Guid.Parse(user.Id);

			var orders = await _db.Orders
				.Where(o => o.CustomerId == null)
				.Include(o => o.OrderDetails)
				.ThenInclude(od => od.Product)
				.OrderByDescending(o => o.Date)
				.ToListAsync();

			return View(orders);
		}
	}
}
