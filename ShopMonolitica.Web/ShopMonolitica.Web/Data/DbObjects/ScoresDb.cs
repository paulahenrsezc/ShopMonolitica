using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Scores;
using System.Linq;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class ScoresDb : IScoresDb
    {
        private readonly ShopContext _shopcontext;

        public ScoresDb(ShopContext context)
        {
            _shopcontext = context;
        }
        public ScoresModel GetScore(int studenid)
        {
            var scores = _shopcontext.Scores.Find(studenid).ConvertScoresEntityScoresModel();
            return scores;
        }

        public List<ScoresModel> GetScores()
        {
            return _shopcontext.Scores.Select(scores => scores.ConvertScoresEntityToScoresModel())
            .ToList();
        }

        public void RemoveScores()
        {
            throw new NotImplementedException();
        }

        public void SaveScores(ScoresSaveModel ScoresSave)
        {
            Scores scoreEntity = ScoresSave.ConvertScoresSaveModelToScoresEntity();
            _shopcontext.Scores.Add(scoreEntity);
            _shopcontext.SaveChanges();
        }

        public void UpdateScores(ScoresUpdateModel updateScores)
        {
            Scores scoreToUpdate = _shopcontext.Scores.Find(updateScores.studentid);

            if (scoreToUpdate != null)
            {
                scoreToUpdate.UpdateFromModel(updateScores);
                _shopcontext.Scores.Update(scoreToUpdate);
                _shopcontext.SaveChanges();
            }
        }
    }
}
