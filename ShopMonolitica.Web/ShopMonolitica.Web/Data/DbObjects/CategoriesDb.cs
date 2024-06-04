using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.BL.Exceptions;

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
            return _shopContext.Categories.Select(categories=> new CategoriesModel()
            {
                categoryname = categories.categoryname,
                description = categories.description,
                creation_date = categories.creation_date


            }).ToList();
        }

        public CategoriesModel GetCategoriesModel(int categoryid)
        {
            var shipper = _shopContext.Categories.Find(categoryid);

            CategoriesModel categoriesModel = new CategoriesModel();
            {
                categoryname = categories.categoryname,
                description = categories.description,
                creation_date = categories.creation_date

            };

        }

        public void Save(CategoriesSaveModel categories)
        {
            Categories categories = new Categories();
            {
                categoryname = categories.categoryname,
                description = categories.description,
                creation_date = categories.creation_date

            };
            _shopContext.Categories.Add(categories1);
            _shopContext.SaveChanges();

        }
       
        public void Update(CategoriesUpdateModel updateModel)
        {
            Categories categories1 = new Categories();
            {
            categoryname = categories1.categoryname,
            description = categories1.description,
            creation_date = categories1.creation_date

            };
            _shopContext.Categories.Update(categories1);
            _shopContext.SaveChanges();
        }
    }

}