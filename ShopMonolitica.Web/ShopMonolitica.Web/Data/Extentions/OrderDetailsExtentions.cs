using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models.OrderDetails;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class OrderDetailsExtentions
    {
        public static OrderDetailsModel ConvertOrdEntityOrderDetailsModel(this OrderDetails orderdetails)
        {
            OrderDetailsModel orderdetailsModel = new OrderDetailsModel()
            {
                unitPrice = orderdetails.unitPrice,
                qty = orderdetails.qty,
                discount = orderdetails.discount
            };

            return orderdetailsModel;
        }

        public static OrderDetailsModel ConvertOrdEntityToOrderDetailsModel(this OrderDetails orderdetails)
        {
            return new OrderDetailsModel
            {
                unitPrice = orderdetails.unitPrice,
                qty = orderdetails.qty,
                discount = orderdetails.discount
            };
        }

        public static OrderDetails ConvertOrderDetailsSaveModelToEmployeesEntity(this OrderDetailsSaveModel orderdetailsSave)
        {
            return new OrderDetails
            {
                unitPrice = orderdetailsSave.unitPrice,
                qty = orderdetailsSave.qty,
                discount = orderdetailsSave.discount
            };
        }

        public static void UpdateFromModel(this OrderDetails orderdetails, OrderDetailsUpdateModel updateModel)
        {
            orderdetails.unitPrice = orderdetails.unitPrice;
            orderdetails.qty = orderdetails.qty;
            orderdetails.discount = orderdetails.discount;

        }
    }
}
