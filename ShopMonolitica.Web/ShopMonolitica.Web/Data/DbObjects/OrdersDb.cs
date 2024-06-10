using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Orders;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class OrdersDb : IOrdersDb
    {
        private readonly ShopContext _shopcontext;

        public OrdersDb(ShopContext context)
        {
            _shopcontext = context;
        }
        public OrdersModel GetOrder(int orderid)
        {
            var orders = _shopcontext.Orders.Find(orderid).ConvertOrdEntityOrdersModel();
            return orders;
        }

        public List<OrdersModel> GetOrders()
        {
            return _shopcontext.Orders.Select(orders => orders.ConvertOrdEntityToOrdersModel())
            .ToList();
        }

        public void RemoveOrders()
        {
            throw new NotImplementedException();
        }

        public void SaveOrders(OrdersSaveModel ordersSave)
        {
            Orders ordersEntity = ordersSave.ConvertOrdersSaveModelToOrdersEntity();
            _shopcontext.Orders.Add(ordersEntity);
            _shopcontext.SaveChanges();
        }

        public void UpdateOrders(OrdersUpdateModel updateOrders)
        {
            Orders ordersToUpdate = _shopcontext.Orders.Find(updateOrders.orderid);

            if (ordersToUpdate != null)
            {
                ordersToUpdate.UpdateFromModel(updateOrders);
                _shopcontext.Orders.Update(ordersToUpdate);
                _shopcontext.SaveChanges();
            }
        }
    }
}
