using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mission11_giuliani.Models
{
    public class EFShoppingCartRepository : IShoppingCartRepository
    {
        private BookstoreContext context;

        public EFShoppingCartRepository(BookstoreContext val)
        {
            context = val;
        }

        public IQueryable<ShoppingCart> ShoppingCart => context.ShoppingCart.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            context.AttachRange(shoppingCart.Lines.Select(x => x.Book));

            if (shoppingCart.ShoppingCartId == 0)
            {
                context.ShoppingCart.Add(shoppingCart);
            }

            context.SaveChanges();
        }
    }
}
