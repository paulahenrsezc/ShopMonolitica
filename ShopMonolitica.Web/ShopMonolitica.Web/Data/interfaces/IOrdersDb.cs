using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models.Orders;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IOrdersDb
    {
        void SaveOrders(OrdersSaveModel orders);
        void UpdateOrders(OrdersUpdateModel updateOrders);
        void RemoveOrders();
        List<OrdersModel> GetOrders();
        OrdersModel GetOrder(int orderid);
    }
}
