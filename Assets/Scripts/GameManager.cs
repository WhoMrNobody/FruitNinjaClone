using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    
    public void IncreaseScore(int scoreValue){

        score += scoreValue;
        scoreText.text = score.ToString();
    }

    public void OnBombHit(){

        Time.timeScale = 0f;
    }
}
