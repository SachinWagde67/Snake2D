using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Snake1ScoreTxt;
    [SerializeField] private TextMeshProUGUI Snake2ScoreTxt;
    [SerializeField] public float Score1 = 0;
    [SerializeField] public float Score2 = 0;

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void Score1Increment(float score)
    {
        Score1 += score;
        UpdateUI();
    }

    public void Score2Increment(float score)
    {
        Score2 += score;
        UpdateUI();
    }

    public void Score1Decrement(float score)
    {
        Score1 -= score;
        if(Score1 < 0)
        {
            Score1 = 0;
        }
        UpdateUI();
    }

    public void Score2Decrement(float score)
    {
        Score2 -= score;
        if (Score2 < 0)
        {
            Score2 = 0;
        }
        UpdateUI();
    }

    public void Score1Double(float score)
    {
        score *= 2;
        Score1 = score;
        UpdateUI();
    }

    public void Score2Double(float score)
    {
        score *= 2;
        Score2 = score;
        UpdateUI();
    }

    public float WhatIsScore1()
    {
        return Score1;
    }

    public float WhatIsScore2()
    {
        return Score2;
    }

    private void UpdateUI()
    {
        Snake1ScoreTxt.text = "Score : " + Score1;
        Snake2ScoreTxt.text = "Score : " + Score2;
    }
}
