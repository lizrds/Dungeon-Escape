using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public Transform player;
    public float maxWanderRange = 5f;
    private Vector2 wanderTarget;

    private bool canSee;
    private bool colided = false;
    
    void Start()
    {
        SetNewWanderTarget();
    }

    void Update()
    {
        if (canSee) transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wanderTarget, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wanderTarget) < 0.1f || colided)
            {
                SetNewWanderTarget();
            }

        }
    }

    private void FixedUpdate()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Weapon"));
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            canSee = ray.collider.CompareTag("Player");
            if (canSee)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
    void SetNewWanderTarget()
    {
        float wanderX = Random.Range(transform.position.x - maxWanderRange, transform.position.x + maxWanderRange);
        float wanderY = Random.Range(transform.position.y - maxWanderRange, transform.position.y + maxWanderRange);
        wanderTarget = new Vector2(wanderX, wanderY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        colided = true;
    }
}
