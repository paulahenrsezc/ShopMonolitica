using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using static ShopMonolitica.Web.Data.Entities.Entity;

namespace ShopMonolitica.Web.BL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesDb categoriesDb;
        private readonly ILogger<CategoriesService> logger;

        public CategoriesService(ICategoriesDb categoriesDb, ILogger<CategoriesService> logger)
        {
            this.categoriesDb = categoriesDb;
            this.logger = logger;
        }

        public ServiceResult GetCategories()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = categoriesDb.GetCategories();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las categorías.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetCategory(int categoryid)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = categoriesDb.GetCategory(categoryid);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult UpdateCategories(CategoriesUpdateModel updateModel)
        {
            var result = EntityValidator<CategoriesUpdateModel>.Validate(updateModel);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                categoriesDb.UpdateCategories(updateModel);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveCategories(CategoriesSaveModel categories)
        {
            var result = EntityValidator<CategoriesSaveModel>.Validate(categories);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                categoriesDb.SaveCategories(categories);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult RemoveCategories(CategoriesRemoveModel removeModel)
        {
            var result = new ServiceResult();
            try
            {
                if (removeModel == null)
                {
                    result.Success = false;
                    result.Message = "Indicar el campo a eliminar.";
                    return result;
                }
                categoriesDb.RemoveCategories(removeModel);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }
        // Log que más se van a utilizar
        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }

        public void LogError(Exception ex, string message)
        {
            logger.LogError(ex, message);
        }
    }
}
