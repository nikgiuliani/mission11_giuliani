using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission11_giuliani.Infrastructure;
using mission11_giuliani.Models;

namespace mission11_giuliani.Pages
{
    public class ShopModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShopModel(IBookstoreRepository val, Basket b)
        {
            repo = val;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(string title, string returnUrl)
        {
            Books book = repo.Books.FirstOrDefault(x => x.Title == title);

            basket.AddItem(book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(string title, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.Title == title).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
