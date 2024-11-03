using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    List<GameObject> cameras;

    [SerializeField]
    int activeCamera;


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(Constants.PlayeTag) && !cameras[activeCamera].activeSelf)
        {
            cameras.ForEach(cam => cam.SetActive(false));
            cameras[activeCamera].SetActive(true);
        }
    }
}
