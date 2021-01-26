using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolver.Ninject;
using Northwind.DataAcess.Concrete.EntityFramework;
using Northwind.DataAcess.Concrete.NHibernate;
using Northwind.Entities.Concrete;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.Getall();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";


            cbxCategoryAdd.DataSource = _categoryService.Getall();
            cbxCategoryAdd.DisplayMember = "CategoryName";
            cbxCategoryAdd.ValueMember = "CategoryId";


            cbxUpdateCategory.DataSource = _categoryService.Getall();
            cbxUpdateCategory.DisplayMember = "CategoryName";
            cbxUpdateCategory.ValueMember = "CategoryId";

        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxSearch.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxSearch.Text);
            }
            else
            {
                LoadProducts();
            }

        }

        private void lblCategoryId_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxCategoryAdd.SelectedValue),
                    ProductName = tbxName.Text,
                    QuantityPerUnit = tbxQuantityAdd.Text,
                    UnitPrice = Convert.ToDecimal(tbxPriceAdd.Text),
                    UnitsInStock = Convert.ToInt16(tbxStockAdd.Text)
                });
                MessageBox.Show("Ürün kaydedildi!");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
     
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxUpdateName.Text,
                CategoryId = Convert.ToInt32(cbxUpdateCategory.SelectedValue),
                UnitsInStock = Convert.ToInt16(tbxUpdateStock.Text),
                QuantityPerUnit = tbxUpdateQuantity.Text,
                UnitPrice = Convert.ToDecimal(tbxUpdatePrice.Text)

            });
            MessageBox.Show("Ürün güncellendi!");
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var row = dgwProduct.CurrentRow;
            tbxUpdateName.Text = row.Cells[2].Value.ToString();
            cbxUpdateCategory.SelectedValue = row.Cells[1];
            tbxUpdatePrice.Text = row.Cells[3].Value.ToString();
            tbxUpdateQuantity.Text = row.Cells[4].Value.ToString();
            tbxUpdateStock.Text = row.Cells[5].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwProduct.CurrentRow != null)
                {
                    _productService.Delete(new Product { ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value) });

                    MessageBox.Show("Ürün silindi!");
                    LoadProducts();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }



        }
    }

}
