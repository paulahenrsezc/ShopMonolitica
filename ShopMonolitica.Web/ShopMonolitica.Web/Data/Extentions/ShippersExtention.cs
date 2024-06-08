using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;



namespace ShopMonolitica.Web.Data.Extentions
{
    public static class ShippersExtention
    {
        public static ShipperModel ConvertShipEntityShippersModel(this ShipperModel shipper)
        {
            ShipperModel shipperModel = new ShipperModel()
            {
                companyname = shipper.companyname,
                phone = shipper.phone
            };
            return shipperModel;
        }


        public static ShipperModel ConvertShipEntityToShippersModel(this ShipperModel shipper)
        {
            return new ShipperModel
            {
                companyname = shipper.companyname,
                phone = shipper.phone
            };
        }


        public static ShipperModel ConvertShipSaveModelToShipperEntity(this ShipperModel shipperModel)
        {
            return new ShipperModel
            {
                companyname = shipperModel.companyname,
                phone = shipperModel.phone
            };
        }

        public static void UpdateFromModel(this ShipperModel shipperModel, ShipperUpdateModel model)
        {
            model.shipperid = model.shipperid;
            model.companyname = model.companyname;
            model.phone = model.phone;
            model.modify_date = model.modify_date;
        }


    }

}