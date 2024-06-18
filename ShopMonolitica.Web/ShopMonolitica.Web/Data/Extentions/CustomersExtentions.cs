using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class CustomersExtentions
    {


        public static CustomersModel ConvertCustEntityCustomersModel(this Customers customers)
        {
            CustomersModel customersmodel = new CustomersModel()
            {
                custid = customers.custid,
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
            return customersmodel;

        }

        public static CustomersModel ConvertCustEntityToCustomersModel(this Customers customers)
        {
            return new CustomersModel
            {
                custid = customers.custid,
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
        }


        public static void UpdateFromModels(this Customers customers, CustomersUpdateModel model)
        {
            model.custid = model.custid;
            model.companyname = model.companyname;
            model.contactname = model.contactname;
            model.contacttitle = model.contacttitle;
            model.address = model.address;
            model.email = model.email;
            model.city = model.city;
            model.region = model.region;
            model.postalcode = model.postalcode;
            model.country = model.country;
            model.phone = model.phone;
            model.fax = model.fax;
        }
        public static Customers ConvertCustomersSaveModelToCustomersEntity(this CustomersSaveModel customersSave)
        {
            return new Customers
            {
                custid = customersSave.custid,
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
        }

        public static Customers ValidateCustomerExists(this ShopContext context, int custid)
        {
            var customer = context.Customers.Find(custid);
            if (customer == null)
            {
                throw new CustomersDbException("El cliente no está registrado");
            }
            return customer;
        }



    }
}

