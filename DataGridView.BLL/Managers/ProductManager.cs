using DataGridView.BLL.Interfaces;
using DataGridView.DAL;
using DataGridView.DAL.Interfaces;
using DataGridView.DAL.Repositories;
using DataGridView.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.BLL.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProduct product;
        public ProductManager()
        {
            var container = new DataServiceRegistraiton();
            product = container.GetProductInstance();
        }
        public void CreateProduct(ProductDTO productDTO)
        {

            product.Create(new Entities.Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
            });




        }

        public void DeleteProduct(ProductDTO productDTO)
        {
            product.Delete(new Entities.Product
            {
                Id = productDTO.Id,
                
            });
        }

        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();

            var productList = product.GetProduct(); // Burada gerçek veri kaynağından ürünleri almalısınız.

            foreach (var item in productList)
            {
                products.Add(new ProductDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price
                });
            }

            return products;
        }


        public void UpdateProduct(ProductDTO productDTO)
        {

            product.Update(new Entities.Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            });

        }
    }
}