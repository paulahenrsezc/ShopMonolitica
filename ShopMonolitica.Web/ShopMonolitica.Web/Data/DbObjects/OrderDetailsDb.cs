using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.OrderDetails;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class OrderDetailsDb : IOrderDetailsDb
    {
        private readonly ShopContext context;

        public OrderDetailsDb(ShopContext context)
        {
            this.context = context;
        }

        public void AddOrderDetails(OrderDetailsSaveModel addModel)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailsModel> GetOrderDetails()
        {
            throw new NotImplementedException();
        }

        public OrderDetailsModel GetOrderDetails(int idEmployees)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderDetails(OrderDetailsUpdateModel updateModel)
        {
            throw new NotImplementedException();
        }
    }
}
