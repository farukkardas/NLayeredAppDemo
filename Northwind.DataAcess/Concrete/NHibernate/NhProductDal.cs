using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAcess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcess.Concrete.NHibernate
{
   public class NhProductDal : IProductDal
    {
        
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>()
            {
                new Product() {ProductId = 1, CategoryId = 1 ,ProductName =  "Laptop", QuantityPerUnit = "1 in a box",UnitsInStock = 11}
            };
            return products;
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
