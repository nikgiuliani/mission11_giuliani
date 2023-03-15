using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission11_giuliani.Models;
using mission11_giuliani.Models.ViewModels;

namespace mission11_giuliani.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository val) => repo = val;

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var booksViewModel = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize), 

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum 
                }
            };

            return View(booksViewModel);
        }
    }
}
