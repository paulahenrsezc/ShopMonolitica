using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.BL.Services
{
    public class TestsService : ITestsService
    {
        private readonly ITestsDb testDb;
        private readonly ILogger <TestsService> logger;

        public TestsService(ITestsDb testDb, ILogger<TestsService> logger)
        {
            this.testDb = testDb;
            this.logger = logger;
        }

        public ServiceResult GetTest(string id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = testDb.GetTestsModel(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el Tests.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetTests()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = testDb.GetTests();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los Tests.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveTests(TestsRemoveModel testsRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo el Tests.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveTests(TestsSaveModel testsSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (testsSave is null)
                {
                    result.Success = false;
                    result.Message = "El tests no puede ser nulo.";
                    return result;
                }

                if (testsSave.testid.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud testid del test debe ser menos de 10 carácteres.";
                    return result;
                }

                this.testDb.SaveTests(testsSave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un guardando el Test.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
