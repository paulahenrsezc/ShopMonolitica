using ShopMonolitica.Web.Data.SupplierModelos;

namespace ShopMonolitica.Web.BL.Extension
{
    public static class SuppliersValidaciones
    {
        public static bool SuppliersValid(SupplierSaveModel supplierSaveModel, ref string message)
        {
            bool result = false;

            if (string.IsNullOrEmpty(supplierSaveModel.ContactName))
            {
                message = "El nombre del suplidor es requerido.";
                return result;
            }

            if (supplierSaveModel.ContactName.Length > 30)
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
