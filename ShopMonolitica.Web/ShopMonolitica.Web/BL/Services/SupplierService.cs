using Microsoft.AspNetCore.Mvc.Filters;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.ProductModelos;
using ShopMonolitica.Web.Data.SupplierModelos;
using ShopMonolitica.Web.BL.Extension;

namespace ShopMonolitica.Web.BL.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISuppliers suppliersDb;

        public SupplierService(ISuppliers suppliersDb)
        {
            this.suppliersDb = suppliersDb;
        }
        public ServiceResult GetSuplier(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = suppliersDb.GetSupplier(id);
               
            }
            catch (Exception)
            {
                result.Succes = false;
                result.message = "ocurrio un error obteniendo los suplidores";
            }
            return result;
        }

        public ServiceResult GetSupliers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = suppliersDb.GetSuppliers();
            }
            catch (Exception)
            {
                result.Succes = false;
                result.message = "ocurrio un error obteniendo los suplidores";
            }
            return result;
        }

        public ServiceResult RemoveSupliers(SupplierRemoveModel supplierRemoveModel)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (supplierRemoveModel == null)
                {
                    result.Succes = false;
                    result.message = "Indicar el campo a eliminar.";
                    return result;
                }
                suppliersDb.RemoveSuppliers(supplierRemoveModel);
                result.Succes = true;
            }
            catch (Exception)
            {
                result.Succes = false;
                result.message = "Ocurrió un error removiendo los productos";
            }
            return result;
        }

        public ServiceResult SaveSupliers(SupplierSaveModel supplierSaveModel)
        {
            throw new NotImplementedException();
        }

        public ServiceResult UpdateSupliers(SupplierUpdateModel supplierUpdateModel)
        {
            throw new NotImplementedException();
        }
        private bool SuppliersValid(SupplierSaveModel supplierSaveModel, ref string message, Operations operations)
        {
            bool result = false;
            if (string.IsNullOrEmpty(supplierSaveModel.ContactName))
            {
                message = "El nombre del suplidor es requerido.";
                return result;
            }

            if (supplierSaveModel.ContactName.Length > 40)
            {
                message = "El nombre del suplidor no puede ser mayor de 40 caracteres.";
                return result;
            }
            if (supplierSaveModel.Address.Length > 60)
            {
                message = "La dirección no puede ser mayor de 60 caracteres.";
                return result;
            }
            else
                result = false;

            return result;

        }
    }
}
