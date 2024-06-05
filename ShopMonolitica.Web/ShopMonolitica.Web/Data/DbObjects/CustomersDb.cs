using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using System.Runtime.Intrinsics.Arm;
using ShopMonolitica.Web.Data.Extentions;
namespace ShopMonolitica.Web.Data.DbObjects
{
    public class CustomersDb : ICustomersDb
    {
        private readonly ShopContext _shopContext;

        public CustomersDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public CustomersModel GetCustomers(int custid)
        {
            var customers = _shopContext.Customers.Find(custid).ConvertCustEntityToCustomersModel();
            return customers;
        }
        public List<CustomersModel> GetCustomers()
        {
            return _shopContext.Customers
                .Select(customers => customers.ConvertCustEntityToCustomersModel())
                .ToList();
        }

        public void RemoveCustomer()
        {
            throw new NotImplementedException();
        }

        public void SaveCustomers(CustomersSaveModel customersSave)
        {
            Customers customerEntity = customersSave.ConvertCustomersSaveModelToCustomersEntity();
            _shopContext.Customers.Add(customerEntity);
            _shopContext.SaveChanges(); ;
        }

        public void UpdateCustomes(CustomerUpdateModel updateModel)
        {
            Customers customersToUpdate = _shopContext.Customers.Find(updateModel.custid);

            if (customersToUpdate != null)
            {
                customersToUpdate.UpdateFromModel(updateModel);
                _shopContext.Customers.Update(customersToUpdate);
                _shopContext.SaveChanges();
            }
        }
    }
}
