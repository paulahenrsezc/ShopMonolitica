using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.OrderDetails;
using ShopMonolitica.Web.Data.Extentions;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class OrderDetailsDb : IOrderDetailsDb
    {
        private readonly ShopContext _shopContext;

        public OrderDetailsDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }


        public List<OrderDetailsBaseModel> GetOrderDetails()
        {
            return _shopContext.OrderDetails.Select(orderdetails => orderdetails.ConvertOrdEntityToOrderDetailsModel())
            .ToList();
        }

        public OrderDetailsBaseModel GetOrderDetails(int orderid)
        {
            var orderdetails = _shopContext.OrderDetails.Find(orderid).ConvertOrdEntityOrderDetailsModel();

            if (orderdetails is null)
            {
                throw new OrderDetailsDbException($"No se pudo encontrar la orden con el id{orderid}");
            }

            return orderdetails;
        }

        public void RemoveOrderDetails(OrderDetailsRemoveModel orderdetailsRemove)
        {
            var orderdetails = ValidateOrderDetailsExists(orderdetailsRemove.orderid);
            _shopContext.OrderDetails.Remove(orderdetails);
            _shopContext.SaveChanges();
        }

        public void SaveOrderDetails(OrderDetailsSaveModel orderdetailsSave)
        {
            OrderDetails orderdetailsEntity = orderdetailsSave.ConvertOrderDetailsSaveModelToEmployeesEntity();
            _shopContext.OrderDetails.Add(orderdetailsEntity);
            _shopContext.SaveChanges();
        }

        public void UpdateOrderDetails(OrderDetailsUpdateModel orderDetailsUpdate)
        {
            OrderDetails orderdetailsToUpdate = OrderDetailsGetById(orderDetailsUpdate.orderid);

            if (orderdetailsToUpdate != null)
            {
                UpdateOrderDetailsFields(orderdetailsToUpdate,
                                 orderDetailsUpdate.orderid,
                                 orderDetailsUpdate.productid,
                                 orderDetailsUpdate.unitprice,
                                 orderDetailsUpdate.qty,
                                 orderDetailsUpdate.discount);

                _shopContext.SaveChanges();
            }
        }

        private void UpdateOrderDetailsFields(OrderDetails orderdetailsToUpdate, int orderid, int productid, decimal unitprice, short qty, decimal discount)
        {
            orderdetailsToUpdate.orderid = orderid;
            orderdetailsToUpdate.productid = productid;
            orderdetailsToUpdate.unitprice = unitprice;
            orderdetailsToUpdate.qty = qty;
            orderdetailsToUpdate.discount = discount;
        }

        private OrderDetails OrderDetailsGetById(int orderid)
        {
            return _shopContext.OrderDetails.FirstOrDefault(od => od.orderid == orderid);
        }

        private OrderDetails ValidateOrderDetailsExists(int orderid)
        {
            var orderdetails = _shopContext.OrderDetails.Find(orderid);
            return orderdetails;
        }

    }
}
