using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class UsersExtentions
    {
        public static UsersModel ConvertUsersEntityUsersModel(this Users users)
        {
            UsersModel usersModel = new UsersModel()
            {
                Email = users.Email,
                Password = users.Password,
                Name = users.Name
            };
            return usersModel;

        }

        public static UsersModel ConvertUsersEntityToUsersModel(this Users user)
        {
            return new UsersModel
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }

        public static Users ConvertUsersSaveModelToUsersEntity(this UsersSaveModel usersSave)
        {
            return new Users
            {
                Email = usersSave.Email,
                Password = usersSave.Password,
                Name = usersSave.Name
            };
        }

        public static void UpdateFromModel(this Users user, UsersUpdateModel model)
        {
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
        }

    }   
}
