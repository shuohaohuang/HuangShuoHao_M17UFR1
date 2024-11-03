using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetCheackPoint : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag(Constants.PlayeTag))
        {
            player
                .gameObject.GetComponent<MainCharacter>()
                .SetCheackPoint(this.transform.position.x, this.transform.position.y, sceneName);
            Destroy(gameObject);
        }
    }
}
