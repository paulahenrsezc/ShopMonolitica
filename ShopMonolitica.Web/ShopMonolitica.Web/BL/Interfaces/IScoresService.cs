using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Models.Scores;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface IScoresService
    {
        ServiceResult GetScores();
        ServiceResult GetScore(string id);
        ServiceResult UpdateScores(ScoresUpdateModel scoresUpdate);
        ServiceResult RemoveScores(ScoresRemoveModel scoresRemove);
        ServiceResult SaveScores(ScoresSaveModel scoresSave);
    }
}
