using Microsoft.AspNetCore.Mvc;
using Mission9_mitch921.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_mitch921.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Cart cart { get; set; }

        public OrderController(IOrderRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();
                repo.SaveOrder(order);
                cart.ClearCart();

                return RedirectToPage("/OrderCompleted"); 
            }
            else
            {
                return View();
            }
        }
    }
}
