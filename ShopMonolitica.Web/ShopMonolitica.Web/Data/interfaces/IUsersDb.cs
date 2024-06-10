using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Users;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IUsersDb
    {
        void SaveUsers(UsersSaveModel users);
        void UpdateUsers(UsersUpdateModel updateUsers);
        void RemoveUsers();
        List<UsersModel> GetUsers();
        UsersModel GetUser(int UserId);
    }
}
