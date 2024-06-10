using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class TestsDb : ITestsDb
    {
        private readonly ShopContext _shopcontext;
        public TestsDb(ShopContext context)
        {
            _shopcontext = context;
        }
        public TestsModel GetTest(int testid)
        {
            var tests = _shopcontext.Tests.Find(testid).ConvertTestEntityTestModel();
            return tests;
        }

        public List<TestsModel> GetTests()
        {
            return _shopcontext.Tests.Select(tests => tests.ConvertTestEntityToTestModel())
            .ToList();
        }

        public void RemoveTests()
        {
            throw new NotImplementedException();
        }

        public void SaveTests(TestsSaveModel testsSave)
        {
            Tests testsEntity = testsSave.ConvertTestsSaveModelToTestsEntity();
            _shopcontext.Tests.Add(testsEntity);
            _shopcontext.SaveChanges();
        }
    }
}
