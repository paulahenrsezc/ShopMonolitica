using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.OrderDetails;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IOrderDetailsDb
    {
        void SaveOrderDetails(OrderDetailsSaveModel orderdetailsSave);
        void UpdateOrderDetails(OrderDetailsUpdateModel updateModel);
        void RemoveOrderDetails(OrderDetailsRemoveModel orderdetailsRemove);
        List<OrderDetailsModel> GetOrderDetails();
        OrderDetailsModel GetOrderDetails(int idOrderDetails);
    }
}
