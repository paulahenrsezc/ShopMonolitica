using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
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

        public CategoriesModel GetCategory(int categoryid)
        {
            var category = _shopContext.Categories.Find(categoryid);
            if (category == null) 
            { 
                throw new CategoriesDbException($"ID no encontrado, {categoryid}"); 
            }
           
             return category.ConvertCatEntityCategoriesModel(); 
        }

        public void RemoveCategories(CategoriesRemoveModel removeModel)
        {
            var category = _shopContext.Categories.Find(removeModel.categoryid);
            if (category == null)
            {
                throw new CategoriesDbException("ID no encontrado");
            }

            Categories categoriesRemove = removeModel.ConvertCatRemoveModelToCategoriesEntity();
            _shopContext.Categories.Remove(categoriesRemove);
            _shopContext.SaveChanges();

        }

        public void SaveCategories(CategoriesSaveModel categoriesSave)
        {
            Categories categoriesEntity = categoriesSave.ConvertCatSaveModelToCategoriesEntity();
            _shopContext.Categories.Add(categoriesEntity);
            _shopContext.SaveChanges();

        }

        public void UpdateCategories(CategoriesUpdateModel categoriesUpdate)
        {
            Categories categoriesToUpdate = _shopContext.Categories.Find(categoriesUpdate.categoryid);
            if (categoriesToUpdate != null)
            {
                categoriesToUpdate.ConvertCatUpdateModelToCategoriesEntity(categoriesUpdate);
                _shopContext.Categories.Update(categoriesToUpdate);
                _shopContext.SaveChanges();
            }
        }
    }
};
