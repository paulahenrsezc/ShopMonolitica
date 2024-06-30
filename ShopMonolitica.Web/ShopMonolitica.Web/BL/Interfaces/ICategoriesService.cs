using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface ICategoriesService
    {
        ServiceResult SaveCategories(CategoriesSaveModel categories);
        ServiceResult UpdateCategories(CategoriesUpdateModel updateModel);
        ServiceResult RemoveCategories(CategoriesRemoveModel removeModel);
        ServiceResult GetCategories();
        ServiceResult GetCategory(int categoryid);

        
        }

    }
