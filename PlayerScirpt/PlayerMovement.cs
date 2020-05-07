using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigi;

    public float moveSpeed = 2f;
    private void Awake()
    {
        myRigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
       if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigi.velocity = new Vector2(moveSpeed, myRigi.velocity.y);
        }
       if(Input.GetAxisRaw("Horizontal")< 0f)
        {
            myRigi.velocity = new Vector2(-moveSpeed, myRigi.velocity.y);
        }
    }
    public void PlatformMove(float x)
    {
        myRigi.velocity = new Vector2(x, myRigi.velocity.y);
    }
}
