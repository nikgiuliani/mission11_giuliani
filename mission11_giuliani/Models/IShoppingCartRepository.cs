using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission11_giuliani.Models
{
    public interface IShoppingCartRepository
    {
        IQueryable<ShoppingCart> ShoppingCart { get; }

        void SaveShoppingCart(ShoppingCart shoppingCart);
    }
}
