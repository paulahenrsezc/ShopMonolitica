using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;
using ShopMonolitica.Web.Data.Models.OrderDetails;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IOrderDetailsDb
    {
        void SaveOrderDetails(OrderDetailsSaveModel orderdetailsSave);
        void UpdateOrderDetails(OrderDetailsUpdateModel updateModel);
        void RemoveEmployees(OrderDetailsRemoveModel orderdetailsRemove);
        List<OrderDetailsModel> GetOrderDetails();
        OrderDetailsModel GetOrderDetails(int idEmployees);
    }
}
