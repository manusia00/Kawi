using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float checkRadius;

    [SerializeField]
    private LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;

    private Vector2 movement;
    
    private Vector3 dir;

    public Collider2D body;

    private bool isInChaseRange;

    private float angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        dir = target.position - transform.position;
        angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        Flip();
        
    }

    private void FixedUpdate()
    {
        if(isInChaseRange)
        {
            MoveCharacter(movement);
        }
        if(body.IsTouchingLayers(whatIsPlayer))
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    private void Flip()
    {
        if(angle < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else if(angle > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        }
    }

}
