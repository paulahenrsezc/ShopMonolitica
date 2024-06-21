using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Scores;
using System.Data;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class ScoresDb : IScoresDb
    {
        private readonly ShopContext _shopcontext;

        public ScoresDb(ShopContext context)
        {
            _shopcontext = context;
        }
        public ScoresGetModel GetScoresModel(int studentid)
        {
            var sqlQuery = $"SELECT * FROM Stats.Scores WHERE studentid = @studentid";
            var parameters = new[] { new SqlParameter("@studentid", SqlDbType.VarChar) { Value = studentid.ToString() } };
            var scores = _shopcontext.Scores.FromSqlRaw(sqlQuery, parameters).FirstOrDefault().ConvertScoresEntityScoresModel();
            return scores;
        }

        public List<ScoresGetModel> GetScores()
        {
            return _shopcontext.Scores
                .Select(scores => scores.ConvertScoresEntityToScoresModel())
                .ToList();
        }

        public void SaveScores(ScoresSaveModel ScoresSave)
        {
            Scores scoreEntity = ScoresSave.ConvertScoresSaveModelToScoresEntity();
            _shopcontext.Scores.Add(scoreEntity);
            _shopcontext.SaveChanges();
        }

        public void UpdateScores(ScoresUpdateModel updateModel)
        {
            Scores scoreToUpdate = _shopcontext.Scores.Find(updateModel.studentid);

            if (scoreToUpdate != null)
            {
                scoreToUpdate.UpdateFromModel(updateModel);
                _shopcontext.Scores.Update(scoreToUpdate);
                _shopcontext.SaveChanges();
            }
        }
    }
}
