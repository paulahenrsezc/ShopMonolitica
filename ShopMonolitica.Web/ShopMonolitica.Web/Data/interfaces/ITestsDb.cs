using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ITestsDb
    {
        void SaveTests(TestsSaveModel tests);
        List<TestsGetModel> GetTests();
        TestsGetModel GetTestsModel(int testid);
    }
}
