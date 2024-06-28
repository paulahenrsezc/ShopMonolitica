using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extensions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;


namespace ShopMonolitica.Web.Data.DbObjects
{
    public class CategoriesDb : ICategoriesDb
    {
        private readonly ShopContext _shopContext;

        public CategoriesDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CategoriesModel> GetCategories()
        {
            return _shopContext.Categories
                .Select(category => category.ConvertCatEntityToCategoriesModel())
                .ToList();
        }

        public CategoriesModel GetCategoriesModel(int categoryid)
        {
            var category = _shopContext.Categories.Find(categoryid);
            return category?.ConvertCustEntityCustomersModel();
        }

        public void Save(CategoriesSaveModel categoriesSave)
        {
            Categories categoriesEntity = categoriesSave.ConvertCatSaveModelToCategoriesEntity();
            _shopContext.Categories.Add(categoriesEntity);
            _shopContext.SaveChanges();

        }

        public void Update(CategoriesUpdateModel updateModel)
        {
            Categories categoriesToUpdate = _shopContext.Categories.Find(updateModel.categoryid);
            if (categoriesToUpdate != null)
            {
                categoriesToUpdate.UpdateFromModel(updateModel);
                _shopContext.Categories.Update(categoriesToUpdate);
                _shopContext.SaveChanges();
            }
        }
    }
};
