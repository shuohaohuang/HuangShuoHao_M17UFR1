using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D bunny;

    [SerializeField]
    float runSpeed;
    private readonly float raycastXDistance = 0.8f;
    private readonly float raycastYDistance = 0.8f;
    private float rayYOffset = 0.8f;
    private readonly float rayXOffSet = 0.5f;

    [SerializeField]
    int distance,
        direction;

    RaycastHit2D rayY;
    Vector2 facing;

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
        TurnArround();
    }

    void TurnArround()
    {
        bool hasPath = CheakHasPath();

        bool hasObstacle = CheakHasObstacle();

        if (hasObstacle || !hasPath)
        {
            direction = -direction;
            rayYOffset = -rayYOffset;
            transform.Rotate(0, 180, 0);
        }
    }

    bool CheakHasObstacle()
    {
        facing = direction > 0 ? Vector2.right : Vector2.left;

        return Physics2D.Raycast(
            new Vector3(transform.position.x, transform.position.y - rayXOffSet),
            facing,
            raycastYDistance
        );
    }

    bool CheakHasPath()
    {
        rayY = Physics2D.Raycast(
            new(transform.position.x + rayYOffset, transform.position.y),
            Vector2.down,
            raycastXDistance
        );

        if (rayY.collider != null)
        {
            return rayY.collider.CompareTag(Constants.GroundTag);
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D player) {
        if(player.gameObject.tag==Constants.PlayeTag){
            player.gameObject.GetComponent<MainCharacter>().HandleDead();
        }
    }
}
