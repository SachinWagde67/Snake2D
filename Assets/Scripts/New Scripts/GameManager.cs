using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreTxt;
    [SerializeField] public float Score = 0;

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void ScoreIncrement(float score)
    {
        Score += score;
        UpdateUI();
    }

    public void ScoreDecrement(float score)
    {
        Score -= score;
        if(Score < 0)
        {
            Score = 0;
        }
        UpdateUI();
    }

    public void ScoreDouble(float score)
    {
        score *= 2;
        Score = score;
        UpdateUI();
    }

    public float WhatIsScore()
    {
        return Score;
    }

    private void UpdateUI()
    {
        ScoreTxt.text = "Score : " + Score;
    }
}
