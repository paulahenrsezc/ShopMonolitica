using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extensions
{
    public static class CategoriesExtentions
    {
        //Clase extention para simplificar codigo
        
        public static CategoriesModel ConvertCatEntityCategoriesModel(this Categories categories)
        {
            CategoriesModel categoriesModel = new CategoriesModel()

            {
                categoryid = categories.categoryid,
                categoryname = categories.categoryname,
                description = categories.description,
                creation_date=categories.creation_date,
                creation_user=categories.creation_user


            };
            return categoriesModel;

        }


        public static CategoriesModel ConvertCatEntityToCategoriesModel(this Categories categories)
        {
            return new CategoriesModel
            {
                categoryid = categories.categoryid,
                categoryname = categories.categoryname,
                description = categories.description,
                creation_date = categories.creation_date,
                creation_user = categories.creation_user

            };
        }


        public static Categories ConvertCatSaveModelToCategoriesEntity(this CategoriesSaveModel categoriesSaveModel)
        {
            return new Categories
            {
                
                categoryid = categoriesSaveModel.categoryid,
                categoryname = categoriesSaveModel.categoryname,
                description = categoriesSaveModel.description,
                creation_date = categoriesSaveModel.creation_date,
                creation_user = categoriesSaveModel.creation_user
            };
        }
        public static Categories ConvertCatRemoveModelToCategoriesEntity(this CategoriesRemoveModel categoriesRemoveModel)
        {
            return new Categories
            {
                categoryid = categoriesRemoveModel.categoryid,
                categoryname = categoriesRemoveModel.categoryname,
                description = categoriesRemoveModel.description,
                delete_user = categoriesRemoveModel.delete_user,
                deleted = categoriesRemoveModel.deleted,
                delete_date = categoriesRemoveModel.delete_date,
               
            };
        }

        public static void ConvertCatUpdateModelToCategoriesEntity(this Categories categories, CategoriesUpdateModel categoriesUpdateModel)
        {
            categories.categoryid = categoriesUpdateModel.categoryid;
            categories.categoryname = categoriesUpdateModel.categoryname;
            categories.description = categoriesUpdateModel.description;
            categories.modify_date= categoriesUpdateModel.modify_date;
            categories.modify_user = categoriesUpdateModel.modify_user;
        }
    }
}

