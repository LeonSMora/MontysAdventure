﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public int force = 370;
    public int isGrounded;

    int score = 0;
    int onionQuantity = 0;
    int chickenQuantity = 0;

    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public Animator animator;
    public Text scoreText;
    public Text onionText;
    public Text chickenText;
    
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = 0;   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else if (Input.GetAxis("Horizontal") >= 1)
        {
            if(isGrounded == 1) { 
                spr.flipX = false;
                animator.SetBool("isWalking", true);
            }
        }

        else if (Input.GetAxis("Horizontal") <= -1)
        {
            if (isGrounded == 1){
                spr.flipX = true;
                animator.SetBool("isWalking", true);
            }
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetButtonDown(KeyCode.Space.ToString()) && isGrounded == 1){

            animator.SetTrigger("isJumping"); //debe ir antes de la ejecución del salto para que se vea
            animator.SetBool("isWalking", false);
            isGrounded = 0;
            rb.AddForce(Vector2.up * force);
        
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "terrain")
        {
            isGrounded = 1;
        }

        if(collision.gameObject.tag == "onion")
        {
            score--;
            onionQuantity++;
            scoreText.text = score.ToString();
            onionText.text = onionQuantity.ToString();
        }

        if (collision.gameObject.tag == "chicken")
        {
            score++;
            chickenQuantity++;
            scoreText.text = score.ToString();
            chickenText.text = chickenQuantity.ToString();
        }
    }
}