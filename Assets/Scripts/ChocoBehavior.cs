using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoBehavior : MonoBehaviour
{
    public float speed = 2.5f;
    Rigidbody2D rb;
    float posInicial;
    float posActual;
    int cambio = 0;
    ParticleSystem ps;
    Transform psPosition;


    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position.x;
        posActual = posInicial + 0.1f;
        rb = GetComponent<Rigidbody2D>();
        psPosition = GameObject.Find("Particles").GetComponent<Transform>();
        ps = GameObject.Find("Particles").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(posActual >= (posInicial + 2) && cambio == 0)
        {
            speed = speed * -1;
            cambio = 1;
        }else if(posActual < (posInicial - 2) && cambio == 1)
        {
            speed = speed * -1;
            cambio = 0;
        }
        rb.velocity = Vector2.right * speed;
        posActual = transform.position.x;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y+0.5)
        {
            psPosition.transform.position = new Vector2(transform.position.x, transform.position.y + 2); 
            ps.Play();
            gameObject.SetActive(false);
        }
    }
}
