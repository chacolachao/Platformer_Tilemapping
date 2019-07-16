﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float height;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       float moveHorizontal = Input.GetAxis("Horizontal");

       Vector2 movement = new Vector2(moveHorizontal, 0);

       rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, height), ForceMode2D.Impulse);
            }
        }
    }
}
