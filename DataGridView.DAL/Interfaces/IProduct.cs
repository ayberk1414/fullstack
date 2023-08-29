using DataGridView.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.DAL.Interfaces
{
    public interface IProduct
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetProduct();
    }
}
