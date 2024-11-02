using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField]
    Collider2D trigger;
    [SerializeField]
    Vector2 SpawnPosition;
    [SerializeField]
    string nextScene;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.PlayeTag)
        {
            collision.gameObject.transform.position=SpawnPosition;
            SceneManager.LoadSceneAsync(nextScene);
        }
    }
}
