using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Extentions;
namespace ShopMonolitica.Web.Data.DbObjects
{
    public class UsersDb : IUsersDb
    {
        private readonly ShopContext _shopContext;

        public UsersDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public UsersModel GetUsers(int UserId)
        {
            var user = _shopContext.Users.Find(UserId).ConvertUsersEntityToUsersModel();
            return user;
        }

        public List<UsersModel> GetUsers()
        {
            return _shopContext.Users
                .Select(user => user.ConvertUsersEntityToUsersModel())
                .ToList();
        }

        public void RemoveUser()
        {
            throw new NotImplementedException();
        }

        public void SaveUser(UsersSaveModel usersSave)
        {
            Users userEntity = usersSave.ConvertUsersSaveModelToUsersEntity();
            _shopContext.Users.Add(userEntity);
            _shopContext.SaveChanges();
        }

        public void UpdateUser(UsersUpdateModel usersModel)
        {
            Users userToUpdate = _shopContext.Users.Find(usersModel.UserId);

            if (userToUpdate != null)
            {
                userToUpdate.UpdateFromModel(usersModel); 
                _shopContext.Users.Update(userToUpdate);
                _shopContext.SaveChanges();
            }
        }
    }
}
