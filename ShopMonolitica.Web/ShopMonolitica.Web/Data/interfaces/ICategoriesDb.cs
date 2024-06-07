using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ICategoriesDb
    {
        void Save(CategoriesSaveModel categories);
        void Update(CategoriesUpdateModel updateModel);

        List<CategoriesModel> GetCategories();
        CategoriesModel GetCategoriesModel(int categoryid);
    }
};