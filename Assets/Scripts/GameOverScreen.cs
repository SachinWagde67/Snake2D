using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreTxt;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreTxt.text = "Score : " + gameManager.WhatIsScore();
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
