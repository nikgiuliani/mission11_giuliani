using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission11_giuliani.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {  
        public BookstoreContext context { get; set; }

        public EFBookstoreRepository(BookstoreContext val)
        {
            context = val;
        }

        public IQueryable<Books> Books => context.Books;
    } 
}