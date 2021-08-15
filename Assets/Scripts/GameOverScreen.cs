using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Snake1Scoretxt;
    [SerializeField] private TextMeshProUGUI Snake2Scoretxt;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        Snake1Scoretxt.text = "Score : " + gameManager.WhatIsScore1();
        Snake2Scoretxt.text = "Score : " + gameManager.WhatIsScore2();
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
