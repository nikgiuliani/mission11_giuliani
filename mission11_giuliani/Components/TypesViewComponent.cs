using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mission11_giuliani.Models;

namespace mission11_giuliani.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository val) 
        {
            repo = val;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CurrCategory = RouteData?.Values["category"];

            var types = repo.Books
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x);

            return View("Default", types);
        }
    }
}