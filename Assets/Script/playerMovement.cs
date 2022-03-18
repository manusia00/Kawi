using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]private float speed;
    [SerializeField]private float jumpForce;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if(Input.GetButtonDown("Jump")){
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }
}
