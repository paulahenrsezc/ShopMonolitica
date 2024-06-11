using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extension;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.SupplierModelos;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class SuppliersDb : ISuppliers
    {
        private readonly ShopContext _context;

        public SuppliersDb(ShopContext context)
        {
            _context = context;
        }
        public SuppliersModel GetSuppliers(int SupplierId)
        {
           var Suppliers = _context.Suppliers.Find(SupplierId).ConvertSupplierEntitieModel();

            return Suppliers;

        }

        public List<SuppliersModel> GetSuppliers()
        {
            return _context.Suppliers.Select(suppliers =>suppliers.ConvertSupplierEntitieModel()).ToList();
        }

        public void RemoveSuppliers(SupplierRemoveModel suppliers)
        {
            throw new NotImplementedException();
        }

        public void SaveSuppliers(SupplierSaveModel suppliersave)
        {
            Suppliers suppliersentity = suppliersave.ConvertSupplierSaveEntitieModel();

            _context.Suppliers.Add(suppliersentity);
        }

        public void UpdatesSuppliers(SupplierUpdateModel suppliers)
        {
            Suppliers supplierToUpdate = _context.Suppliers.Find(suppliers.SupplierId);

            if (supplierToUpdate != null)

            supplierToUpdate.ConvertSupplierEntitieModel();
            _context.Suppliers.Update(supplierToUpdate);
            _context.SaveChanges();

            

        }

        
    }
}
