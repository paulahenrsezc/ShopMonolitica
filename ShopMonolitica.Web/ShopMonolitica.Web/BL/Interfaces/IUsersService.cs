using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface IUsersService
    {
        ServiceResult GetUsers();
        ServiceResult GetUsers(int UserId);
        ServiceResult UpdateUsers(UsersUpdateModel usersUpdate);
        ServiceResult RemoveUsers(UsersRemoveModel usersRemove);
        ServiceResult SaveUsers(UsersSaveModel usersSave);


    }
}
