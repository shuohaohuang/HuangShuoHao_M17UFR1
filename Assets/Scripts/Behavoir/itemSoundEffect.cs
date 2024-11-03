using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSoundEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D collider2)
    {
        if (collider2.CompareTag(Constants.CheakPointTag))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
