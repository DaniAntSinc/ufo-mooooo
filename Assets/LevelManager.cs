using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float minutes = 1, seconds = 30;
    public Text TimeRemaining;
    bool stopCountDown;
    public static int score, goldScore, humanScore;

    public Text cowsCollected, goldCollected, humanCollected, totalCollected;
    public int scoreStar1, scoreStar2, scoreStar3;
    public GameObject levelFinished, star1, star2, star3;
    public GameObject Continue;
    private void Start()
    {
        score = 0;
        goldScore = 0;
        humanScore = 0;
    }

    void Update()
    {
        if (!stopCountDown)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 10)
            {
                TimeRemaining.text = minutes + ":0" + seconds.ToString("F0");
            }
            else
            {
                TimeRemaining.text = minutes + ":" + seconds.ToString("F0");
            }

            if (seconds <= 0)
            {
                if (minutes <= 0 && seconds <= 0)
                {
                    TimeRemaining.text = "0:00";
                    stopCountDown = true;
                    print("Play end of level sound effect");
                    levelFinished.SetActive(true);
                    StartCoroutine(EndScreen());
                }
                else
                {
                    minutes--;
                    seconds = 59;

                    TimeRemaining.text = minutes + ":" + seconds.ToString("F0");
                }
            }        
        }
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(3);
        cowsCollected.text = score.ToString();
        goldCollected.text = goldScore.ToString();
        humanCollected.text = humanScore.ToString();

        totalCollected.text = (score + goldScore + humanScore).ToString(); 
        if (score >= scoreStar1)
        {
            yield return new WaitForSeconds(1);
            star1.SetActive(true);
        }
        if (score >= scoreStar2)
        {
            yield return new WaitForSeconds(1);
            star2.SetActive(true);
        }
        if (score >= scoreStar3)
        {
            yield return new WaitForSeconds(1);
            star2.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        Continue.SetActive(true);
    }

    public void ContinueButton()
    {
        score = 0;
        goldScore = 0;
        humanScore = 0;
        SceneManager.LoadScene("LevelSelect");
    }
}
