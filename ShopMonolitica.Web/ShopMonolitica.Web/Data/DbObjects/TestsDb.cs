using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Test;
using System.Data;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class TestsDb : ITestsDb
    {
        private readonly ShopContext _shopcontext;
        public TestsDb(ShopContext context)
        {
            _shopcontext = context;
        }
        public TestsGetModel GetTestsModel(int testid)
        {
            var sqlQuery = $"SELECT * FROM Stats.Tests WHERE testid = @testid";
            var parameters = new[] { new SqlParameter("@testid", SqlDbType.VarChar) { Value = testid.ToString() } };
            var tests = _shopcontext.Tests.FromSqlRaw(sqlQuery, parameters).FirstOrDefault().ConvertTestEntityTestModel();
            return tests;
        }

        public List<TestsGetModel> GetTests()
        {
            return _shopcontext.Tests
                .Select(tests => tests.ConvertTestEntityToTestModel())
                .ToList();
        }

        public void SaveTests(TestsSaveModel testsSave)
        {
            Tests testsEntity = testsSave.ConvertTestsSaveModelToTestsEntity();
            _shopcontext.Tests.Add(testsEntity);
            _shopcontext.SaveChanges();
        }
    }
}
