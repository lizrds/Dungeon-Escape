using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector3 direction, float speed)
    {
        rb.velocity = new Vector2(direction.x, direction.y) * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision logic here
        //Destroy(gameObject);
    }
}
