using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    string level;

    [SerializeField]
    public static bool isPaused = false;

    public void Startgame()
    {
        MainCharacter.DestroySingleton();
        SceneManager.LoadScene(level);
    }

    public void GoToMenu()
    {
        MainCharacter.DestroySingleton();
        SetCheackPoint.Clear();
        SceneManager.LoadScene("INITIAL_MENU");
    }

    public static void getPause()
    {
        if (isPaused)
        {
            Continue();
        }
        else
        {
            Pause();
        }
    }

    public static void Pause()
    {
        isPaused=true;
        Time.timeScale = 0;
        SceneManager.LoadScene("PAUSE_MENU", LoadSceneMode.Additive);
    }

    public static void Continue()
    {
        isPaused=false;

        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PAUSE_MENU");
    }

}
