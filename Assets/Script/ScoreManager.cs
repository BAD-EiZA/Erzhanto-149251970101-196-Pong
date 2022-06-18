using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Script")]
    public BallController bc;

    [Header("Var")]
    public int rightScore;
    public int leftScore;
    public int maxScore;
    

    [Header("Game Object")]
    public Text rgScore;
    public Text lfScore;
    public GameObject rgWin;
    public GameObject lfWin;
    public GameObject overPanel;
    public GameObject bls;
    public GameObject PowerUp;

    public void AddRightScore(int value){
        rightScore += value;
        rgScore.text = rightScore.ToString();
        if (rightScore >= maxScore){
            GameOver();
        }
        else{
            bc.RestartGame();
            bc.isGoal = true;
        }
    }
    public void AddLeftScore(int value){
        leftScore += value;
        lfScore.text = leftScore.ToString();
        if (leftScore >= maxScore){
            GameOver();
        }
        else{
            bc.RestartGame();
            bc.isGoal = true;
        }
    }
    public void ResetScore(){
        rightScore = 0;
        leftScore = 0;
    }
    public void GameOver(){
        if (rightScore == maxScore){
            overPanel.SetActive(true);
            lfWin.SetActive(false);
            rgWin.SetActive(true);
            bls.SetActive(false);
            PowerUpController.instance.isSpawning = true;
            EnemyController.instance.isOver = true;
            
        }
        else if (leftScore == maxScore){
            overPanel.SetActive(true);
            rgWin.SetActive(false);
            lfWin.SetActive(true);
            bls.SetActive(false);
            PowerUpController.instance.isSpawning = true;
            EnemyController.instance.isOver = true;
        }
    }
}
