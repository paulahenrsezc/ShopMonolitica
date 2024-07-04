using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Scores;

namespace ShopMonolitica.Web.BL.Services
{
    public class ScoresService : IScoresService
    {
        private readonly IScoresDb scoresDb;
        private readonly ILogger <ScoresService> logger;

        public ScoresService(IScoresDb scoresDb, ILogger<ScoresService> logger)
        {
            this.scoresDb = scoresDb;
            this.logger = logger;
        }
        public ServiceResult GetScore(string id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = scoresDb.GetScoresModel(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el Score.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetScores()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = scoresDb.GetScores();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el Score.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveScores(ScoresRemoveModel scoresRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
 
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo el Score.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveScores(ScoresSaveModel scoresSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (scoresSave is null)
                {
                    result.Success = false;
                    result.Message = "El score no puede ser nulo.";
                    return result;
                }

                if (string.IsNullOrEmpty(scoresSave.testid))
                {
                    result.Success = false;
                    result.Message = "El campo testid es requerido.";
                    return result;
                }

                if (string.IsNullOrEmpty(scoresSave.studentid))
                {
                    result.Success = false;
                    result.Message = "El campo studentid es requerido.";
                    return result;
                }

                if (scoresSave.score > 255)
                {
                    result.Success = false;
                    result.Message = "El campo score debe ser menor a 255";
                    return result;
                }

                this.scoresDb.SaveScores(scoresSave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando el Score.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateScores(ScoresUpdateModel scoresUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (scoresUpdate is null)
                {
                    result.Success = false;
                    result.Message = "El score no puede ser nulo.";
                    return result;
                }

                if (string.IsNullOrEmpty(scoresUpdate.testid))
                {
                    result.Success = false;
                    result.Message = "El campo testid es requerido.";
                    return result;
                }

                if (string.IsNullOrEmpty(scoresUpdate.studentid))
                {
                    result.Success = false;
                    result.Message = "El campo studentid es requerido.";
                    return result;
                }

                if (scoresUpdate.score > 255)
                {
                    result.Success = false;
                    result.Message = "El campo score debe ser menor a 255";
                    return result;
                }

                this.scoresDb.UpdateScores(scoresUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando el Score.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
