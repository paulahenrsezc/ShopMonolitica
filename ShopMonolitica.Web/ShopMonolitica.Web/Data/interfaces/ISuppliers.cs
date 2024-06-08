using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ISuppliers
    {
        void SaveSuppliers(Suppliers suppliers);
        void UpdatesSuppliers(Suppliers suppliers);
        void RemoveSuppliers(Suppliers suppliers);
        Suppliers GetSuppliers(int id);
        List<Suppliers> GetSuppliers(Func<Suppliers, bool> filter);
        bool ExitSuppliers(Func<Suppliers, bool> filter);
    }
}
