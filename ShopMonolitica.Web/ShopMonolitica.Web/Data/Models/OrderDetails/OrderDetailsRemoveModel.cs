﻿namespace ShopMonolitica.Web.Data.Models.OrderDetails
{
    public class OrderDetailsRemoveModel : OrderDetailsBaseModel
    {
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }
    }
}