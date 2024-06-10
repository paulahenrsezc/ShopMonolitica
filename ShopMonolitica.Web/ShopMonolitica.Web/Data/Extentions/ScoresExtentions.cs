using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Scores;
using static System.Formats.Asn1.AsnWriter;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class ScoresExtentions
    {
        public static ScoresModel ConvertScoresEntityScoresModel(this Scores scores)
        {
            ScoresModel scoresModel = new ScoresModel()
            {
                testid = scores.testid,
                studentid = scores.studentid,
                score = scores.score
            };
            return scoresModel;

        }

        public static ScoresModel ConvertScoresEntityToScoresModel(this Scores scores)
        {
            return new ScoresModel
            {
                testid = scores.testid,
                studentid = scores.studentid,
                score = scores.score
            };
        }

        public static Scores ConvertScoresSaveModelToScoresEntity(this ScoresSaveModel scoresSaveModel)
        {
            return new Scores
            {
                testid = scoresSaveModel.testid,
                studentid = scoresSaveModel.studentid,
                score = scoresSaveModel.score
            };
        }

        public static void UpdateFromModel(this Scores scores, ScoresUpdateModel updateModel)
        {
            scores.testid = scores.testid;
            scores.studentid = scores.studentid;
            scores.score = scores.score;
        }

    }
}

