using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public Transform player;

    private bool canSee;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (canSee) transform.position = 
                Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
}
