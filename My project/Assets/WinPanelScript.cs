using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class WinPanelScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Update()
    {
        scoreText.text = "Score : " + ScoreManager.score.ToString();
    }
    public void NextLevel()
    {
        int scorePoint = ScoreManager.score;
        SceneManager.LoadScene(1);
        LevelManager.canMove = true;
        scoreText.text = scorePoint.ToString();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
