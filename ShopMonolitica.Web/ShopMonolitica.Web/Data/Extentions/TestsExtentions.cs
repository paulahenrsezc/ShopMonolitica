using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models.Test;
using static System.Net.Mime.MediaTypeNames;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class TestsExtentions
    {
        public static TestsModel ConvertTestEntityTestModel(this Tests tests)
        {
            TestsModel testsModel = new TestsModel()
            {
                testid = tests.testid
            };

            return testsModel;
        }

        public static TestsModel ConvertTestEntityToTestModel(this Tests tests)
        {
            return new TestsModel
            {
                testid = tests.testid
            };
        }

        public static Tests ConvertTestsSaveModelToTestsEntity(this TestsSaveModel testsSaveModel)
        {
            return new Tests
            {
                testid = testsSaveModel.testid
            };
        }
    }
}
