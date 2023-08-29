using DataGridView.DAL.Interfaces;
using DataGridView.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.DAL
{
    public class DataServiceRegistraiton
    {

        ServiceProvider serviceProvider;
        public DataServiceRegistraiton()
        {
            serviceProvider = new ServiceCollection().AddScoped<IProduct,ProductRepository>().BuildServiceProvider();
        }
        // Microsoft  

        //new ServiceCollection

        public IProduct GetProductInstance()
        {
            return serviceProvider.GetRequiredService<IProduct>();
        }
    }
}
