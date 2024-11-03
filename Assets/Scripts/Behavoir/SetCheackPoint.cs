using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCheackPoint : MonoBehaviour
{
    [SerializeField]
    bool destroyOntrigger;
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
            if (destroyOntrigger) Destroy(gameObject);
        }
    }
}
