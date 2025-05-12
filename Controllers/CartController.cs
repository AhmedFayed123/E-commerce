using eStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CartController : Controller
{
    private readonly eStoreDBContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartController(eStoreDBContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var cartItems = await _context.Carts
            .Include(c => c.Product)
            .Where(c => c.UserId == user.Id)
            .ToListAsync();

        return View(cartItems);
    }

	[HttpPost]
	public async Task<IActionResult> AddToCart(long productId, int quantity = 1)
	{
		var userId = _userManager.GetUserId(User);

		var cartItem = await _context.Carts
			.FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

		if (cartItem != null)
		{
			cartItem.Quantity += quantity;
		}
		else
		{
			cartItem = new Cart
			{
				UserId = userId,
				ProductId = productId,
				Quantity = quantity
			};
			_context.Carts.Add(cartItem);
		}

		await _context.SaveChangesAsync();

		return Redirect("/Cart/Index#indexxx");
	}


	[HttpPost]
    public async Task<IActionResult> RemoveFromCart(long cartId)
    {
        var item = await _context.Carts.FindAsync(cartId);
        if (item != null)
        {
            _context.Carts.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        var user = await _userManager.GetUserAsync(User);
        var cartItems = await _context.Carts
            .Include(c => c.Product)
            .Where(c => c.UserId == user.Id)
            .ToListAsync();

        if (!cartItems.Any())
        {
            return RedirectToAction("Index");
        }

        var order = new Order
        {
            Date = DateTime.Now,
            CreatedDate = DateTime.Now,
            CustomerId = null,
            ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8),
            OrderStatusId = 1,
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        foreach (var item in cartItems)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = order.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                ItemPrice = item.Product.CurrentPrice,
                ItemPriceAfterDiscount = item.Product.CurrentPrice // apply discount if any
            };

            _context.OrderDetails.Add(orderDetail);
        }
        _context.Carts.RemoveRange(cartItems);

        await _context.SaveChangesAsync();

        return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
    }
    public async Task<IActionResult> OrderConfirmation(long orderId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        return View(order);
    }

}
