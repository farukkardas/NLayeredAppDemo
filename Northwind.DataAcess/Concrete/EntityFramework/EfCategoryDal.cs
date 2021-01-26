using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAcess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcess.Concrete.EntityFramework
{
    public class EfCategoryDal:EFEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
