using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag(Constants.PlayeTag))
        {
            GoToMenu();
        }
    }

    public void GoToMenu()
    {
        MainCharacter.DestroySingleton();
        SetCheackPoint.Clear();
        SceneManager.LoadScene("WIN_MENU");
    }
}
