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


        public static Shippers ConvertShipSaveModelToShipperEntity(this ShippersSaveModel shipperModel)
        {
            return new Shippers
            {
                companyname = shipperModel.companyname,
                phone = shipperModel.phone
            };
        }

        public static void UpdateFromModel(this Shippers shipperModel, ShippersUpdateModel model)
        {
            model.shipperid = model.shipperid;
            model.companyname = model.companyname;
            model.phone = model.phone;
            model.modify_date = model.modify_date;
        }


    }

}