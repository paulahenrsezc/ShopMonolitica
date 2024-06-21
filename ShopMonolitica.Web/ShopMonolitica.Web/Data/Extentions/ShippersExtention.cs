using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;



namespace ShopMonolitica.Web.Data.Extentions
{
    public static class ShippersExtention
    {
        public static ShippersModel ConvertShipEntityShippersModel(this Shippers shipper)
        {
            ShippersModel shipperModel = new ShippersModel()
            {
                companyname = shipper.companyname,
                phone = shipper.phone
            };
            return shipperModel;
        }


        public static ShippersModel ConvertShipEntityToShippersModel(this Shippers shipper)
        {
            return new ShippersModel
            {
                companyname = shipper.companyname,
                phone = shipper.phone
            };
        }



    }

}