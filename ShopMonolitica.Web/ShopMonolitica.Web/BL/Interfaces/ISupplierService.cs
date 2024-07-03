using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.ProductModelos;
using ShopMonolitica.Web.Data.SupplierModelos;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface ISupplierService
    {
        ServiceResult GetSupliers();
        ServiceResult GetSuplier(int id);
        ServiceResult UpdateSupliers(SupplierUpdateModel supplierUpdateModel);
        ServiceResult RemoveSupliers(SupplierRemoveModel supplierRemoveModel);
        ServiceResult SaveSupliers(SupplierSaveModel supplierSaveModel);
    }
}
