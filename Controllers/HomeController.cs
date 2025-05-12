using eStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace eStore.Controllers
{
	public class HomeController : Controller
	{
        eStoreDBContext db = new eStoreDBContext();
        public IActionResult Index()
		{
			return View(Index);
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Cart()
		{
			return View();
		}
		public IActionResult Categories()
		{ 
			var cats = db.Categories.ToList();
			return View(cats);
		}
		public IActionResult Products()
		{
			var prods = db.Products
			.Include(p => p.Brand)
			.Include(p => p.Category)
			.Include(p => p.ProductImages)
			.ToList();

			return View(prods);
		}
		//public IActionResult Products(string? search, string? category, decimal? minPrice, decimal? maxPrice)
		//{
		//	// Start with queryable to apply filters
		//	var productsQuery = db.Products
		//		.Include(p => p.Brand)
		//		.Include(p => p.Category)
		//		.Include(p => p.ProductImages)
		//		.AsQueryable();

		//	// Apply search filter
		//	if (!string.IsNullOrEmpty(search))
		//	{
		//		productsQuery = productsQuery.Where(p =>
		//			p.Name.Contains(search) ||
		//			p.ShortDescription.Contains(search));
		//	}

		//	// Apply category filter
		//	if (!string.IsNullOrEmpty(category))
		//	{
		//		// turn "mobile-phones" -> "mobile phones"
		//		var categoryName = category.Replace("-", " ");
		//		productsQuery = productsQuery.Where(p =>
		//			p.Category.Name.ToLower() == categoryName.ToLower());
		//	}


		//	// Apply price filters
		//	if (minPrice.HasValue)
		//	{
		//		productsQuery = productsQuery.Where(p => p.CurrentPrice >= minPrice.Value);
		//	}

		//	if (maxPrice.HasValue)
		//	{
		//		productsQuery = productsQuery.Where(p => p.CurrentPrice <= maxPrice.Value);
		//	}

		//	// Execute the query
		//	var products = productsQuery.ToList();

		//	// Return to view with list of filtered products
		//	return View(products);
		//}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
