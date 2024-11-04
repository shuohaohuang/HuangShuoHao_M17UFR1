using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCheackPoint : MonoBehaviour
{
    [SerializeField]
    bool destroyOntrigger;

    [SerializeField]
    int id;
    static Dictionary<int, bool> cheakPoints = new();

    void Awake()
    {
        if (cheakPoints.ContainsKey(id))
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag(Constants.PlayeTag))
        {
            player
                .gameObject.GetComponent<MainCharacter>()
                .SetCheackPoint(
                    this.transform.position.x,
                    this.transform.position.y,
                    SceneManager.GetActiveScene().name
                );
            if (destroyOntrigger)
            {
                cheakPoints.Add(id, true);

                Destroy(gameObject);
            }
        }
    }

    public static void Clear()
    {
        cheakPoints.Clear();
    }
}
