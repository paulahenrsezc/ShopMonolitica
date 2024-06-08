using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extensions
{
    public static class CategoryExtensions
    {

        public static CategoriesModel ConvertCustEntityCustomersModel(this Categories customers)
        {
            CategoriesModel customersModel = new CategoriesModel()
            {
                categoryid = customers.categoryid,
                categoryname = customers.categoryname,
                description = customers.description
            };
            return customersModel;

        }


        public static CategoriesModel ConvertCatEntityToCategoriesModel(this Categories categories)
        {
            return new CategoriesModel
            {
                categoryid = categories.categoryid,
                categoryname = categories.categoryname,
                description = categories.description
            };
        }


        public static Categories ConvertCatSaveModelToCategoriesEntity(this CategoriesSaveModel categoriesModel)
        {
            return new Categories
            {
                categoryname = categoriesModel.categoryname,
                description = categoriesModel.description
            };
        }

        public static void UpdateFromModel(this Categories categories, CategoriesUpdateModel model)
        {
            categories.categoryid = model.categoryid;
            categories.categoryname = model.categoryname;
            categories.description = model.description;
        }
    }
}

