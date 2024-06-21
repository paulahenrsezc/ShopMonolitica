using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
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
        public SuppliersModel GetSupplier(int supplierid)
        {
           var Suppliers = _context.Suppliers.Find(supplierid).ConvertSupplierEntitieModel();

            if (Suppliers is null) 
            {
                throw new SuppliersException($"No se encontro el suplidor con el id {supplierid}");
            }

            return Suppliers;

        }

        public List<SupplierGetModel> GetSuppliers()
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

            _context.SaveChanges();
        }

        public void UpdatesSuppliers(SupplierUpdateModel suppliers)
        {
            var updatedSuppliers = _context.Suppliers.FirstOrDefault(c => c.supplierid == suppliers.supplierid);

            if (updatedSuppliers != null) 
            {
                updatedSuppliers.SupplierUpdateEntitieModel(suppliers);
                _context.Suppliers.Update(updatedSuppliers);
                _context.SaveChanges();
            }
        }
    }
}
