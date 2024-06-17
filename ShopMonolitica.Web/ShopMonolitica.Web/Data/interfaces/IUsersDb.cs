using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IUsersDb
    {
        void SaveUser(UsersSaveModel users);
        void UpdateUser(UsersUpdateModel usersModel);

        void RemoveUser();
        List<UsersModel> GetUsers();
        UsersModel GetUsers(int UserId);
    }
}
