using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class CustomersExtentions
    {


        public static CustomersModel ConvertCustEntityCustomersModel(this Customers customers)
        {
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

        public static CustomersModel ConvertCustEntityToCustomersModel(this Customers customers)
        {
            return new CustomersModel
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
        }


        public static Customers ConvertCustomersSaveModelToCustomersEntity(this CustomersSaveModel customersSave)
        {
            return new Customers
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
        }


        public static void UpdateFromModel(this Customers customers, CustomerUpdateModel model)
        {
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
            model.fax = model.companyname;
        }



    }
}

