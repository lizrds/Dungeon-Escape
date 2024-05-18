using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float attackCD;
    float startAttackCD;
    public Health hp;

    private void Start()
    {
        startAttackCD = attackCD;
    }

    private void Update()
    {
        attackCD -= Time.deltaTime;
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && attackCD <= 0)
        {
            attackCD = startAttackCD;
            collision.gameObject.GetComponent<Health>().TakeDamage(20);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            hp.TakeDamage(20);
        }
    }
}
