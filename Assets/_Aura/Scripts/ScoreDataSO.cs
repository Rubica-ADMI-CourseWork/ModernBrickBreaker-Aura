using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName ="ScoreData")]
public class ScoreDataSO : ScriptableObject
{
    public List<int> currentScore;
    public void SetCurrentScore(int _score)
    {
        currentScore.Add(_score);
        FindObjectOfType<UIManager>().SetScoreText(currentScore.Count);
    }
    public int GetCurrentScore()
    {
        return currentScore.Count;
    }

    public void ResetScore()
    {
        currentScore.Clear();
        FindObjectOfType<UIManager>().SetScoreText(currentScore.Count);
    }

}
