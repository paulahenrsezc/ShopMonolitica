using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models.OrderDetails;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class OrderDetailsExtentions
    {
        public static OrderDetailsBaseModel ConvertOrdEntityOrderDetailsModel(this OrderDetails orderdetails)
        {
            OrderDetailsBaseModel orderdetailsModel = new OrderDetailsBaseModel()
            {
                orderid = orderdetails.orderid,
                productid = orderdetails.productid,
                unitPrice = orderdetails.unitPrice,
                qty = orderdetails.qty,
                discount = orderdetails.discount
            };

            return orderdetailsModel;
        }

        public static OrderDetailsBaseModel ConvertOrdEntityToOrderDetailsModel(this OrderDetails orderdetails)
        {
            return new OrderDetailsBaseModel
            {
                orderid = orderdetails.orderid,
                productid = orderdetails.productid,
                unitPrice = orderdetails.unitPrice,
                qty = orderdetails.qty,
                discount = orderdetails.discount
            };
        }

        public static OrderDetails ConvertOrderDetailsSaveModelToEmployeesEntity(this OrderDetailsSaveModel orderdetailsSave)
        {
            return new OrderDetails
            {
                orderid = orderdetailsSave.orderid,
                productid = orderdetailsSave.productid,
                unitPrice = orderdetailsSave.unitPrice,
                qty = orderdetailsSave.qty,
                discount = orderdetailsSave.discount
            };
        }

        public static OrderDetails ValidateOrderDetailsExists(this ShopContext context, int orderid)
        {
            var orderdetails = context.OrderDetails.Find(orderid);
            if (orderdetails == null)
            {
                throw new OrderDetailsDbException("La orden no fue encontrada");
            }
            return orderdetails;
        }

        public static void UpdateFromModels(this OrderDetails orderdetails, OrderDetailsUpdateModel orderdetailsUpdate)
        {
            orderdetailsUpdate.orderid = orderdetailsUpdate.orderid;
            orderdetailsUpdate.productid = orderdetailsUpdate.productid;
            orderdetailsUpdate.unitPrice = orderdetailsUpdate.unitPrice;
            orderdetailsUpdate.qty = orderdetailsUpdate.qty;
            orderdetailsUpdate.discount = orderdetailsUpdate.discount;

        }
    }
}
