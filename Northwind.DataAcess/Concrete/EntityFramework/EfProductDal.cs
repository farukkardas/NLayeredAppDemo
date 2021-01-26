using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAcess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcess.Concrete.EntityFramework
{
    public class EfProductDal :EFEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        
    }
}
