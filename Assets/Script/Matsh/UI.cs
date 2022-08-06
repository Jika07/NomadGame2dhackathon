using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public static UI instance;

    public Text textScore, textMoves, WinText;
    private int score = 0;
    private int moves = 20;

    public GameObject panelGameOver;
    public Text gTextScore, gTextBestScore;

    private void Awake()
    {
        instance = this;
    }

    public void Score(int value)
    {
        score += value;
        textScore.text = "Score: " + score.ToString();
    }
    public void Moves(int value)
    {
        moves -= value;
        if(moves <= 0)
        {
            GameOver();
        }
        textMoves.text = "Moves: " + moves.ToString();
    }
    private void GameOver()
    {
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
            gTextBestScore.text = "New Best: " + score.ToString();
            WinText.text = "у вас одна струна";
        }
        else
        {
            gTextBestScore.text = "Best: " + PlayerPrefs.GetInt("Score");
        }
        gTextScore.text = "Score: " + score.ToString();
        panelGameOver.SetActive(true);
    }
}
