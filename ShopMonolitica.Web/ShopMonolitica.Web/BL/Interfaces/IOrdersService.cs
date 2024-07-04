using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Models.Orders;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface IOrdersService
    {
        ServiceResult GetOrders();
        ServiceResult GetOrder(int id);
        ServiceResult UpdateOrders(OrdersUpdateModel ordersUpdate);
        ServiceResult RemoveOrders(OrdersRemoveModel ordersRemove);
        ServiceResult SaveOrders(OrdersSaveModel ordersSave);
    }
}
