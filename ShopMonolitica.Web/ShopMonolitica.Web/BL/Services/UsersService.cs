using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.BL.Exceptions;
using ShopMonolitica.Web.BL.Validator;
using ShopMonolitica.Web.Data.DbObjects;

namespace ShopMonolitica.Web.BL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersDb _usersDb;
        private readonly ILogger<UsersService> _logger;


        public UsersService(IUsersDb usersDb, ILogger<UsersService> logger)
        {
            _usersDb = usersDb;
            _logger = logger;

        }

        public ServiceResult GetUsers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var users = _usersDb.GetUsers();
                if (users == null || !users.Any())
                {
                    result.Success = false;
                    result.Menssage = "No se encontraron usuarios.";
                    return result;
                }
                result.Data = users;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error obteniendo los datos de los usuarios.";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetUsers(int UserId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var user = _usersDb.GetUsers(UserId);
                if (user == null)
                {
                    result.Success = false;
                    result.Menssage = $"No se encontró el usuario con ID {UserId}.";
                    return result;
                }
                result.Data = user;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error obteniendo los datos del usuario.";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveUsers(UsersRemoveModel usersRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (usersRemove is null)
                    throw new CustomersServiceException("No se ha encontrado el usuario");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error eliminando los datos del usuario";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveUsers(UsersSaveModel usersSave)
        {
            ServiceResult result = EntityValidator<UsersSaveModel>.Validate(usersSave, 50);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                _usersDb.SaveUser(usersSave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error guardando los datos del cliente";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateUsers(UsersUpdateModel usersUpdate)
        {
            ServiceResult result = EntityValidator<UsersUpdateModel>.Validate(usersUpdate, 50);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                _usersDb.UpdateUser(usersUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error actualizando los datos del cliente";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }
    }
}











