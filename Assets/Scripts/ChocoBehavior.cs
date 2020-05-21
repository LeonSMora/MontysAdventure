using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChocoBehavior : MonoBehaviour
{
    public float speed = 2.5f;
    Rigidbody2D rb;
    public float posInicial;
    float posActual;
    int cambio = 1;
    ParticleSystem ps;
    Transform psPosition;
    SpriteRenderer sr;
    AudioSource audio;
    AudioSource audio2;


    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position.x;
        posActual = posInicial + 0.1f;
        rb = GetComponent<Rigidbody2D>();
        psPosition = GameObject.Find("Particles").GetComponent<Transform>();
        ps = GameObject.Find("Particles").GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        audio = GameObject.Find("chocoAudio").GetComponent<AudioSource>();
        audio2 = GameObject.Find("watah").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (posActual >= (posInicial + 2) && cambio == 0)
        {
            sr.flipX = false;
            speed = speed * -1;
            cambio = 1;
            
        }else if(posActual < (posInicial - 2) && cambio == 1)
        {
            sr.flipX = true;
            speed = speed * -1;
            cambio = 0;
           
        }
        rb.velocity = Vector2.left * speed;
        posActual = transform.position.x;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y+0.5)
        {
            audio.Play(); //debe ir antes de la desactivación del objeto
            psPosition.transform.position = new Vector2(transform.position.x, transform.position.y + 2); 
            ps.Play();
            gameObject.SetActive(false);
        }else if(collision.gameObject.tag == "Player")
        {
            audio2.Play();
            Invoke("changeSceneTo", 0.2f);
        }
    }

    public void changeSceneTo()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
