using System.Collections;
using UnityEngine;

public class BoomerangBullet : MonoBehaviour
{
    public float spinSpeed = 50f;
    public bool isReturning;
    public float speed = 10f;
    public Transform player;

    

    void Start()
    {
        
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

        if (!isReturning && Vector3.Distance(transform.position, player.position) > 10f)
        {
            speed += 5f;
            isReturning = true;
        }

        if (isReturning)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isReturning)
        {
            isReturning = true;   
        }
    }

   
}
