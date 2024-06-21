using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Scores;
using static System.Formats.Asn1.AsnWriter;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class ScoresExtentions
    {
        public static ScoresGetModel ConvertScoresEntityScoresModel(this Scores customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers), "El parámetro 'scores' no puede ser nulo.");
            }

            ScoresGetModel customersModel = new ScoresGetModel()
            {
                testid = customers.testid,
                studentid = customers.studentid,
                score = customers.score
            };
            return customersModel;

        }

        public static ScoresGetModel ConvertScoresEntityToScoresModel(this Scores scores)
        {
            ScoresGetModel scoresGetModel = new ScoresGetModel()
            {
                testid = scores.testid,
                studentid = scores.studentid,
                score = scores.score
            };
            return scoresGetModel;
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

        public static void UpdateFromModel(this Scores scores, ScoresUpdateModel model)
        {
            scores.score = model.score;
        }

        public static Scores ValidateScoresExists(this ShopContext context, int studentid)
        {
            var scores = context.Scores.Find(studentid);
            if (scores == null)
            {
                throw new OrdersDbException("El score no esta registrado");
            }
            return scores;
        }
    }
}

