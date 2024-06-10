using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;
using ShopMonolitica.Web.Data.Models.Orders;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class OrdersExtentions
    {
        public static OrdersModel ConvertOrdEntityOrdersModel(this Orders orders)
        {
            OrdersModel ordersModel = new OrdersModel()
            {
                orderid = orders.orderid,
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

            return ordersModel;
        }

        public static OrdersModel ConvertOrdEntityToOrdersModel(this Orders orders)
        {
            return new OrdersModel
            {
                orderid = orders.orderid,
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
        }

        public static Orders ConvertOrdersSaveModelToOrdersEntity(this OrdersSaveModel ordersSaveModel)
        {
            return new Orders
            {
                orderid = ordersSaveModel.orderid,
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

        public static void UpdateFromModel(this Orders orders, OrdersUpdateModel updateModel)
        {
            orders.orderdate = orders.orderdate;
            orders.requireddate = orders.requireddate;
            orders.shippeddate = orders.shippeddate;
            orders.freight = orders.freight;
            orders.shipname = orders.shipname;
            orders.shipaddress = orders.shipaddress;
            orders.shipcity = orders.shipcity;
            orders.shipregion = orders.shipregion;
            orders.shippostalcode = orders.shippostalcode;
            orders.shipcountry = orders.shipcountry;
        }
    }
}
