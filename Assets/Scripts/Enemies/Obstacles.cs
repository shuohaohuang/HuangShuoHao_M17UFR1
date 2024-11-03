using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D player) {
        if(player.gameObject.tag==Constants.PlayeTag){
            player.gameObject.GetComponent<MainCharacter>().HandleDead();
        }
    }
}
