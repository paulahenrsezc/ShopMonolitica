﻿namespace ShopMonolitica.Web.Data.Models
{
    public class UsersSaveModel : UsersModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}