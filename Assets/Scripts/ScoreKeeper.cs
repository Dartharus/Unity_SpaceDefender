using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    int score;
    public int GetScore()
    {
        return score;
    }
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log("Score: " + score);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
