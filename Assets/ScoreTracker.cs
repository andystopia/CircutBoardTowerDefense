using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    public int RushMod;

    private int Scalar;

    private int Score;

    private void Start()
    {
        RushMod = 1;
        Scalar = 2;
        Score = 0;
    }

    public void IncreaseScore(int inc)
    {
        Score += (inc * RushMod) / Scalar;
        ScoreText.text = Score.ToString();
    }

    public int GetScore()
    {
        return Score;
    }

}
