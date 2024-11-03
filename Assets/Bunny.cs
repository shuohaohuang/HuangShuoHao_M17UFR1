using System;
using System.Collections;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D bunny;

    [SerializeField]
    float runSpeed,
        raycast;

    [SerializeField]
    int distance,
        direction;

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
            Vector3 movement = new(runSpeed * direction * Time.deltaTime, 0, 0);
            bunny.position = transform.position + movement;
            yield return null;
        }
    }

    void Update()
    {
        turnArround();
    }

    void turnArround()
    {
        Vector2 foward = new(direction, 0);

        bool end = raycastHit2 = Physics2D.Raycast(
            new(transform.position.x, transform.position.y - raycast),
            foward,
            1
        );

        if (end)
        {
            direction = -direction;
            transform.Rotate(0, 180, 0);
        }
    }
}
