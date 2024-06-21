using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.Models.Orders;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using static NuGet.Packaging.PackagingConstants;
using static System.Net.Mime.MediaTypeNames;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class OrdersExtentions
    {
        public static OrdersGetModel ConvertOrdEntityOrdersModel(this Orders customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers), "El parámetro 'orders' no puede ser nulo.");
            }

            OrdersGetModel customersModel = new OrdersGetModel()
            {
                orderid = customers.orderid,
                empid = customers.empid,
                custid = customers.custid,
                shipperid = customers.shipperid,
                orderdate = customers.orderdate,
                requireddate = customers.requireddate,
                shippeddate = customers.shippeddate,
                freight = customers.freight,
                shipname = customers.shipname,
                shipaddress = customers.shipaddress,
                shipcity = customers.shipcity,
                shipregion = customers.shipregion,
                shippostalcode = customers.shippostalcode,
                shipcountry = customers.shipcountry
            };

            return customersModel;
        }

        public static OrdersGetModel ConvertOrdEntityToOrdersModel(this Orders orders)
        {
            OrdersGetModel ordersGetModel = new OrdersGetModel()
            {
                orderid = orders.orderid,
                empid = orders.empid,
                custid = orders.custid,
                shipperid = orders.shipperid,
                orderdate = orders.orderdate,
                requireddate = orders.requireddate,
                shippeddate = orders.shippeddate,
                freight = orders.freight,
                shipname = orders.shipname,
                shipaddress = orders.shipaddress,
                shipcity = orders.shipcity,
                shipregion = orders.shipregion,
                shippostalcode = orders.shippostalcode,
                shipcountry = orders.shipcountry
            };
            return ordersGetModel;
        }

        public static Orders ConvertOrdersSaveModelToOrdersEntity(this OrdersSaveModel ordersSaveModel)
        {
            return new Orders
            {
                empid = ordersSaveModel.empid,
                custid = ordersSaveModel.custid,
                shipperid = ordersSaveModel.shipperid,
                orderdate = ordersSaveModel.orderdate,
                requireddate = ordersSaveModel.requireddate,
                shippeddate = ordersSaveModel.shippeddate,
                freight = ordersSaveModel.freight,
                shipname = ordersSaveModel.shipname,
                shipaddress = ordersSaveModel.shipaddress,
                shipcity = ordersSaveModel.shipcity,
                shipregion = ordersSaveModel.shipregion,
                shippostalcode = ordersSaveModel.shippostalcode,
                shipcountry = ordersSaveModel.shipcountry,
            };
        }

        public static void UpdateFromModel(this Orders orders, OrdersUpdateModel model)
        {
            orders.orderdate = model.orderdate;
            orders.requireddate = model.requireddate;
            orders.shippeddate = model.shippeddate;
            orders.freight = model.freight;
            orders.shipname = model.shipname;
            orders.shipaddress = model.shipaddress;
            orders.shipcity = model.shipcity;
            orders.shipregion = model.shipregion;
            orders.shippostalcode = model.shippostalcode;
            orders.shipcountry = model.shipcountry;
        }

        public static Orders ValidateOrdersExists(this ShopContext context, int orderid)
        {
            var order = context.Orders.Find(orderid);
            if (order == null)
            {
                throw new OrdersDbException("La orden no esta registrada");
            }
            return order;
        }
    }
}
