using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.SupplierModelos;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;

namespace ShopMonolitica.Web.Data.Extension
{
    public static class SupplierExtension
    {
        public static SupplierGetModel ConvertSupplierEntitieModel(this Suppliers suppliers)
        {
            return new SupplierGetModel()
            {
                supplierid = suppliers.supplierid,
                CompanyName = suppliers.CompanyName,
                ContactName = suppliers.ContactName,
                ContactTitle = suppliers.ContactTitle,
                Address = suppliers.Address,
                City = suppliers.City,
                PostalCode = suppliers.PostalCode,
                Country = suppliers.Country,
                Region = suppliers.Region,
                Phone = suppliers.Phone,
                Fax = suppliers.Fax,

            };
        }
        
        public static Suppliers ConvertSupplierSaveEntitieModel(this SupplierSaveModel supplierSaveModel)
        {
            return new Suppliers()
            {
                supplierid = supplierSaveModel.supplierid,
                CompanyName = supplierSaveModel.CompanyName,
                ContactName = supplierSaveModel.ContactName,
                creation_date = supplierSaveModel.creation_date,
                creation_user = supplierSaveModel.creation_user,
                ContactTitle = supplierSaveModel.ContactTitle,
                Address = supplierSaveModel.Address,
                City = supplierSaveModel.City,
                PostalCode = supplierSaveModel.PostalCode,
                Country = supplierSaveModel.Country,
                Region = supplierSaveModel.Region,
                Phone = supplierSaveModel.Phone,
                Fax = supplierSaveModel.Fax,

            };

        }
        public static void SupplierUpdateEntitieModel(this Suppliers suppliers,SupplierUpdateModel supplierUpdateModel) 

        {


            suppliers.supplierid = supplierUpdateModel.supplierid;
            suppliers.CompanyName = supplierUpdateModel.CompanyName;
            suppliers.ContactName = supplierUpdateModel.ContactName;
            suppliers.ContactTitle = supplierUpdateModel.ContactTitle;
            suppliers.Address = supplierUpdateModel.Address;
            suppliers.City = supplierUpdateModel.City;
            suppliers.PostalCode = supplierUpdateModel.PostalCode;
            suppliers.Country = supplierUpdateModel.Country;
            suppliers.Region = supplierUpdateModel.Region;
            suppliers.Phone = supplierUpdateModel.Phone;
            suppliers.Fax = supplierUpdateModel.Fax;     
            suppliers.modify_date = supplierUpdateModel.modify_date;
        

        }
    }
}
