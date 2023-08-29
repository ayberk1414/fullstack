using DataGridView.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.BLL.Interfaces
{
    public interface IProductService
    {
       public void CreateProduct(ProductDTO productDTO);
       public  void UpdateProduct(ProductDTO productDTO);
      public void DeleteProduct(ProductDTO productDTO);
        public List<ProductDTO> GetProducts();
        

    }
}
