using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.BL.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ShopContext _shopContext;

        public CustomersService(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public List<CustomersModel> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void GetCustomers(int custid)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomers(CustomersRemoveModel removeModel)
        {
            throw new NotImplementedException();
        }

        public void SaveCustomers(CustomersSaveModel customers)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomers(CustomersUpdateModel updateModel)
        {
            throw new NotImplementedException();
        }
    }
}
