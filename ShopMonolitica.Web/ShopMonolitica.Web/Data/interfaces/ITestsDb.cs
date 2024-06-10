using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ITestsDb
    {
        void SaveTests(TestsSaveModel tests);
        void RemoveTests();
        List<TestsModel> GetTests();
        TestsModel GetTest(int testid);
    }
}
