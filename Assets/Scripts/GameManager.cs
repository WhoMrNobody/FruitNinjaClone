using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [Header("Score Elements")]
    public int score;
    public int highScore;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    [Header("Game Over Elements")]
    public GameObject gameOverPanel;
    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;
    private void Start() {

        audioSource=GetComponent<AudioSource>();
        GetHighScore();
    }
    public void IncreaseScore(int scoreValue){

        score += scoreValue;
        scoreText.text = score.ToString();

        if(score > highScore){

            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Best : " + score.ToString();
        }
    }

    public void OnBombHit(){

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
    }

    private void GetHighScore(){

        highScore =  PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best : " + highScore.ToString();
    }

    public void PlayRandomSliceSounds(){

        AudioClip s = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(s);
    }
}
