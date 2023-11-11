using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBussiness
    {
        public List<Customer> GetCustomers()
        {
            // Aquí puedes realizar lógica adicional antes de acceder a la capa de datos, si es necesario.

            List<Customer> products = new List<Customer>();

            CustomerDataAccess productDataAccess = new CustomerDataAccess();
            products = productDataAccess.GetCustomers().ToList();

            //var results = products.Where(x => x.Name == productName).ToList();

            return products;
        }
    }
}
