
using UnityEngine;

public class PlayerPrefsScoreService : IScoreService
{
    private const string BestScoreKey = "DualDash_BestScore";

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void SaveBestScore(int score)
    {
        int currentBest = GetBestScore();

        if (score > currentBest)
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
            PlayerPrefs.Save();
        }
    }
}
