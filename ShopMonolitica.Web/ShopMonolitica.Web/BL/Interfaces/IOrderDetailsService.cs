using ShopMonolitica.Web.Data.Models.OrderDetails;

namespace ShopMonolitica.Web.BL.Core
{
    public interface IOrderDetailsService
    {
        ServiceResult GetOrderDetails();
        ServiceResult GetOrderDetails(int id);
        ServiceResult UpdateOrderDetails(OrderDetailsUpdateModel orderDetailsUpdate);
        ServiceResult RemoveOrderDetails(OrderDetailsRemoveModel orderDetailsRemove);
        ServiceResult SaveOrderDetails(OrderDetailsSaveModel orderDetailsSave);

    }
}
