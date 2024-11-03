using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
    public static Stack<SpikeProjectile> stack = new();

    [SerializeField]
    private SpikeProjectile projectile;

    [SerializeField]
    Rigidbody2D rigid2d;

    [SerializeField]
    float speed = 30f;

    public void Push(SpikeProjectile projectile)
    {
        projectile.gameObject.SetActive(false);
        stack.Push(projectile);
    }

    public void Pop()
    {
        stack.Pop().gameObject.SetActive(true);
    }

    public void GetProjectile(Vector3 direction, Vector3 position, Quaternion rotation)
    {
        SpikeProjectile newProjectile;
        if (stack.Count > 0)
        {
            newProjectile = stack.Pop();
            newProjectile.gameObject.SetActive(true);
            newProjectile.gameObject.transform.SetPositionAndRotation(position, rotation);
        }
        else
        {
            newProjectile = Instantiate(projectile, position, rotation);
        }

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag(Constants.PlayeTag))
        {
            player.gameObject.GetComponent<MainCharacter>().HandleDead();
        }
        Push(this);
    }
    void OnDestroy(){
        stack.Clear();
    }
}
