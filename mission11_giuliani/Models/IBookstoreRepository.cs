using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission11_giuliani.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Books> Books { get; }
    } 
}