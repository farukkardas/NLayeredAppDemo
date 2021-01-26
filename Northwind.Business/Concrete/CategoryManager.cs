using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Northwind.Business.Abstract;
using Northwind.DataAcess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete
{
   public class CategoryManager:ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> Getall()
        {
            return _categoryDal.GetAll();
        }
    }
}
