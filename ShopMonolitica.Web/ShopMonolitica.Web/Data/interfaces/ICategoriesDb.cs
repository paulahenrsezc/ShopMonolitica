using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;


namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ICategoriesDb
    {
        void SaveCategories(CategoriesSaveModel categories);
        void UpdateCategories(CategoriesUpdateModel updateModel);
        void RemoveCategories(CategoriesRemoveModel removeModel);
        List<CategoriesModel> GetCategories();
        CategoriesModel GetCategory(int categoryid);
    }
};