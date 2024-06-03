using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

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
            var users = _shopContext.Users.Find(UserId);

            UsersModel usersModel = new UsersModel()
            {
                Email = users.Email,
                Password = users.Password,
                Name = users.Name
            };
            return usersModel;
        }

        public List<UsersModel> GetUsers()
        {
            return _shopContext.Users.Select(users => new UsersModel()
            {
                Email = users.Email,
                Password = users.Password,
                Name = users.Name
            }).ToList();
        }

        public void RemoveUser()
        {
            Users userDelete = _shopContext.Users.Find()
        }

        public void SaveUser(UsersSaveModel usersSave)
        {
            Users users = new Users()
            {
                Email = usersSave.Email,
                Password = usersSave.Password,
                Name = usersSave.Name
            };
            _shopContext.Users.Add(users);
            _shopContext.SaveChanges();
        }

        public void UpdateUser(UsersUpdateModel usersModel)
        {
            Users usersUpdate = _shopContext.Users.Find(usersModel.UserId);
            usersUpdate.Email = usersModel.Email;
            usersUpdate.Password = usersModel.Password;
            usersUpdate.Name = usersModel.Name;
            _shopContext.Users.Update(usersUpdate);
            _shopContext.SaveChanges();
        }
    }
}
