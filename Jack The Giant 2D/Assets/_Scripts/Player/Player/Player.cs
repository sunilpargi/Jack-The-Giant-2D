using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    public float maxVelocity, speed;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
    }

    private void PlayerMoveKeyBoard()
    {
        float forceX = 0;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");


        if(h > 0)
        {
            if (vel < maxVelocity)
            {
                Vector2 tempScale = transform.localScale;
                tempScale.x = 1.3f;
                transform.localScale = tempScale;

                forceX = speed;

                anim.SetBool("Walk", true);
            }
        }

       else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                Vector2 tempScale = transform.localScale;
                tempScale.x = -1.3f;
                transform.localScale = tempScale;

                forceX = -speed;

                anim.SetBool("Walk", true);

            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));


    }

 
}
