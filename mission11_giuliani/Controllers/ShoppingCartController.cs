using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mission11_giuliani.Models;

namespace mission11_giuliani.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartRepository repo { get; set; }
        private Basket basket { get; set; }

        public ShoppingCartController(IShoppingCartRepository val, Basket b)
        {
            repo = val;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new ShoppingCart());
        }
        [HttpPost]
        public IActionResult Checkout(ShoppingCart shoppingCart)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            if (ModelState.IsValid)
            {
                shoppingCart.Lines = basket.Items.ToArray();
                repo.SaveShoppingCart(shoppingCart);
                basket.ClearBasket();

                return RedirectToPage("/CartSubmitted");
            }
            else
            {
                return View();
            }
        }
    }
}
