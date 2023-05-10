using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score = 0;
    public static int highScore = 0;
    void Start()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void AddPoint(int value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();
    }
}
