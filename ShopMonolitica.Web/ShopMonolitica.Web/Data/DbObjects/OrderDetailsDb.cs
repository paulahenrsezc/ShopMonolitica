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
        private readonly ShopContext _shopcontext;

        public OrderDetailsDb(ShopContext context)
        {
            _shopcontext = context;
        }

        public List<OrderDetailsModel> GetOrderDetails()
        {
            return _shopcontext.OrderDetails.Select(orderdetails => orderdetails.ConvertOrdEntityToOrderDetailsModel())
            .ToList();
        }

        public OrderDetailsModel GetOrderDetails(int idOrderDetails)
        {
            var orderdetails = _shopcontext.OrderDetails.Find(idOrderDetails).ConvertOrdEntityOrderDetailsModel();
            return orderdetails;
        }

        public void RemoveOrderDetails(OrderDetailsRemoveModel orderdetailsRemove)
        {
            throw new NotImplementedException();
        }

        public void SaveOrderDetails(OrderDetailsSaveModel orderdetailsSave)
        {
            OrderDetails orderdetailsEntity = orderdetailsSave.ConvertOrderDetailsSaveModelToEmployeesEntity();
            _shopcontext.OrderDetails.Add(orderdetailsEntity);
            _shopcontext.SaveChanges();
        }

        public void UpdateOrderDetails(OrderDetailsUpdateModel updateModel)
        {
            OrderDetails orderdetailsToUpdate = _shopcontext.OrderDetails.Find(updateModel.orderid);

            if (orderdetailsToUpdate != null)
            {
                orderdetailsToUpdate.UpdateFromModel(updateModel);
                _shopcontext.OrderDetails.Update(orderdetailsToUpdate);
                _shopcontext.SaveChanges();
            }
        }
    }
}
