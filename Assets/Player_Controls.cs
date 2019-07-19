using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controls : MonoBehaviour

{
    private Rigidbody2D rb2d;
    public float speed;
    public float height;
    public Animator animator;
    private int count;
    public Text ScoreCount;
    private int lives;
    public Text LivesCount;
    public Text winText;
    public Text loseText;

    private bool jump;
    private bool facingRight;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jump = false;
        facingRight = true;
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText ();
        
        
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("Anti"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetCountText ();
           
        }
    }

    void FixedUpdate()
    {
       float moveHorizontal = Input.GetAxis("Horizontal");

       Vector2 movement = new Vector2(moveHorizontal, 0);

       rb2d.AddForce(movement * speed);

       animator.SetFloat("Speed",Mathf.Abs(moveHorizontal));

       Flip(moveHorizontal);

        if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
         if (lives == 0 || count >= 5 ) 
        {
            moveHorizontal = 0;
            rb2d.velocity = Vector2.zero;
        }
    }

    private void Flip(float Horizontal)
    {
        if (Horizontal > 0 && !facingRight || Horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

        }
    }
    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, height), ForceMode2D.Impulse);

                jump = true;

                animator.SetBool("Jumping", true);
            }
            if(!Input.GetKey(KeyCode.UpArrow))
            {
                jump = false;

                animator.SetBool("Jumping", false);
            }
        }
    }

    void SetCountText ()
    {
       ScoreCount.text = "Points: " + count.ToString ();
       LivesCount.text = "Lives: " + lives.ToString ();
       if (count >= 5)
        {
            winText.text = "You Win!";
        }
        if (lives <= 0)
        {
            loseText.text = "GAME OVER";
        }
    }
}
