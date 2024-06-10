﻿using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models.Scores;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IScoresDb
    {
        void SaveScores(ScoresSaveModel scores);
        void UpdateScores(ScoresUpdateModel updateScores);
        void RemoveScores();
        List<ScoresModel> GetScores();
        ScoresModel GetScore(int studenid);
    }
}