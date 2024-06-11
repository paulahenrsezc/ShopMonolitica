using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.SupplierModelos;

namespace ShopMonolitica.Web.Data.Extension
{
    public static class SupplierExtension
    {
        public static SuppliersModel ConvertSupplierEntitieModel(this Suppliers suppliers)
        {
            return new SuppliersModel()
            {
                SupplierId = suppliers.SupplierId,
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
        
        public static Suppliers ConvertSupplierSaveEntitieModel(this SuppliersModel supplierSaveModel)
        {
            return new Suppliers()
            {
                
                CompanyName = supplierSaveModel.CompanyName,
                ContactName = supplierSaveModel.ContactName,
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
    }
}
