using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void SingleGame(){
        SceneManager.LoadScene("SinglePlayer");
        Debug.Log("Created by Erzhanto - 149251970101-196");
    }
    public void MultiGame()
    {
        SceneManager.LoadScene("MultiPlayer");
        Debug.Log("Created by Erzhanto - 149251970101-196");
    }
    public void Author(){
        Debug.Log("Created by Erzhanto - 149251970101-196");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Menu(){
        SceneManager.LoadScene("Main Menu");
    }
}
