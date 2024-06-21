using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.SupplierModelos;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ISuppliers
    {
        void SaveSuppliers(SupplierSaveModel suppliersave);
        void UpdatesSuppliers(SupplierUpdateModel suppliers);
        void RemoveSuppliers(SupplierRemoveModel suppliers);
        SuppliersModel GetSupplier(int Supplierid);
        List<SupplierGetModel> GetSuppliers();
        
    }
}
