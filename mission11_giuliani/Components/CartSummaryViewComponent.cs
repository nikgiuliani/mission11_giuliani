using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mission11_giuliani.Models;

namespace mission11_giuliani.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket repo { get; set; }

        public CartSummaryViewComponent(Basket val)
        {
            repo = val;
        }

        public IViewComponentResult Invoke()
        {
            return View(repo);
        }
    }
}
