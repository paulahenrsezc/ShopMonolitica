using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface ITestsService
    {
        ServiceResult GetTests();
        ServiceResult GetTest(string id);
        ServiceResult RemoveTests(TestsRemoveModel testsRemove);
        ServiceResult SaveTests(TestsSaveModel testsSave);
    }
}
