using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IOrdersDb
    {
        void Add(Orders orders);
    }
}
