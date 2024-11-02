using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Bunny : MonoBehaviour
{
    [SerializeField] Rigidbody2D bunny;
    [SerializeField] int runSpeed,direction;
    [SerializeField] int distance;

RaycastHit2D raycastHit2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrol());

    }

    IEnumerator Patrol()
    {
        while (true)
        {
            Vector3 movement = new(runSpeed* direction * Time.deltaTime,0,0);
            bunny.position = transform.position+movement;
            yield return null;

        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 foward=Vector2.right;
        
        raycastHit2= Physics2D.Raycast(new(transform.position.x,transform.position.y-1),foward,1);
        Debug.DrawRay(transform.position,foward*1,Color.red);
    }
}
