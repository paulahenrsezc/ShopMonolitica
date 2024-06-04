using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using System.Runtime.Intrinsics.Arm;

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
            var customers = _shopContext.Customers.Find(custid);

            CustomersModel customersModel = new CustomersModel()
            {
                companyname = customers.companyname,
                contactname = customers.contactname,
                contacttitle = customers.contacttitle,
                address = customers.address,
                email = customers.email,
                city = customers.city,
                region = customers.region,
                postalcode = customers.postalcode,
                country = customers.country,
                phone = customers.phone,
                fax = customers.fax
            };

            return customersModel;
            }
        public List<CustomersModel> GetCustomers()
        {
            return _shopContext.Customers.Select(customers => new CustomersModel() 
            {
                companyname = customers.companyname,
                contactname = customers.contactname,
                contacttitle = customers.contacttitle,
                address = customers.address,
                email = customers.email,
                city = customers.city,
                region = customers.region,
                postalcode = customers.postalcode,
                country = customers.country,
                phone = customers.phone,
                fax = customers.fax
            }).ToList();
        }

        public void RemoveCustomer()
        {
            throw new NotImplementedException();
        }

        public void SaveCustomers(CustomersSaveModel customersSave)
        {
            Customers customers = new Customers()
            {
                companyname = customersSave.companyname,
                contactname = customersSave.contactname,
                contacttitle = customersSave.contacttitle,
                address = customersSave.address,
                email = customersSave.email,
                city = customersSave.city,
                region = customersSave.region,
                postalcode = customersSave.postalcode,
                country = customersSave.country,
                phone = customersSave.phone,
                fax = customersSave.fax
            };
            _shopContext.Customers.Add(customers);
            _shopContext.SaveChanges();
        }

        public void UpdateCustomes(CustomerUpdateModel updateModel)
        {
            Customers customersUpdate = _shopContext.Customers.Find(updateModel.custid);
            customersUpdate.companyname = updateModel.companyname;
            customersUpdate.contactname = updateModel.contactname;
            customersUpdate.contacttitle = updateModel.contacttitle;
            customersUpdate.address = updateModel.address;
            customersUpdate.email = updateModel.email;
            customersUpdate.city = updateModel.city;
            customersUpdate.region = updateModel.region;
            customersUpdate.postalcode = updateModel.postalcode;
            customersUpdate.country = updateModel.country;
            customersUpdate.phone = updateModel.phone;
            customersUpdate.fax = updateModel.companyname;
            _shopContext.Customers.Update(customersUpdate);
            _shopContext.SaveChanges();
        }
    }
}
