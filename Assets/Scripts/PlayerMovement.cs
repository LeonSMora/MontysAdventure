using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public int force = 370;
    public int isGrounded;

    int score = 1;
    int onionQuantity = 0;
    int chickenQuantity = 0;
    int firstChicken = 1;

    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public Animator animator;
    public Text scoreText;
    public Text onionText;
    public Text chickenText;
    AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = 0;
        audio = GameObject.Find("watah").GetComponent<AudioSource>();
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

        if (score <= 0)
        {
            audio.Play();
            Invoke("changeSceneTo", 0.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "terrain")
        {
            isGrounded = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "onion")
        {
            score -= 3;
            onionQuantity++;
            scoreText.text = score.ToString();
            onionText.text = onionQuantity.ToString();
        }

        if (collision.tag == "chicken")
        {
            if(firstChicken == 1)
            {
                score += 5;
                score--;
                firstChicken = 0;
                chickenQuantity++;
                scoreText.text = score.ToString();
                chickenText.text = chickenQuantity.ToString();
            }
            else
            {
                score += 5;
                chickenQuantity++;
                scoreText.text = score.ToString();
                chickenText.text = chickenQuantity.ToString();
            }
            
        }
    }

    public void changeSceneTo()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
