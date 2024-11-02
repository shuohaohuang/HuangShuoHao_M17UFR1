using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag==Constants.PlayeTag){
            other.gameObject.GetComponent<MainCharacter>().hitted=true;
        }
    }
}
