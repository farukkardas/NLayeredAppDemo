using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.ValidationRules.FluentValidation   
{
    class ProductValidator:AbstractValidator<Product>
    {
        //fluent validation
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz.");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori boş olamaz.");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Birim adedi boş olamaz.");
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Stok adedi boş girilemez.");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Fiyat boş bırakılamaz.");

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThan((short)0);
            RuleFor(p=>p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);

           // Ürünlerin adı A ile başlamalı diye kendi rulemizi oluşturduk.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adı a ile başlamalı.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
