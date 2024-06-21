using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.Models.Test;
using static System.Net.Mime.MediaTypeNames;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class TestsExtentions
    {
        public static TestsGetModel ConvertTestEntityTestModel(this Tests customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers), "El parámetro 'tests' no puede ser nulo.");
            }

            TestsGetModel customersModel = new TestsGetModel()
            {
                testid = customers.testid
            };

            return customersModel;
        }

        public static TestsGetModel ConvertTestEntityToTestModel(this Tests tests)
        {
            TestsGetModel testsGetModel  = new TestsGetModel()
            {
                testid = tests.testid
            };
            return testsGetModel;
        }

        public static Tests ConvertTestsSaveModelToTestsEntity(this TestsSaveModel testsSaveModel)
        {
            return new Tests
            {
                testid = testsSaveModel.testid
            };
        }

        public static Tests ValidateTestsExists(this ShopContext context, string testid)
        {
            var test = context.Tests.Find(testid);
            if (test == null)
            {
                throw new OrdersDbException("El test no esta registrado");
            }
            return test;
        }
    }
}
