﻿using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Users 
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
