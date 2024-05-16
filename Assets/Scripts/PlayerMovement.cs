using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    Vector2 movement;

    private float dashingCooldown = 2f;
    private float dashTime = 0.2f;
    private bool canDash = true;
    private float dashingStrenght = 40f;
    private bool isDashing = false;
    private bool isFacingRight = true;

    private float horizontal, vertical;


    [SerializeField] private TrailRenderer rr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        //rb.velocity = new Vector2(transform.localScale.x * dashingStrenght, 0f);
        Vector2 dashDirection = new Vector2(horizontal, vertical).normalized;

        // Apply the dash velocity
        rb.velocity = dashDirection * dashingStrenght;
        rr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        rr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
