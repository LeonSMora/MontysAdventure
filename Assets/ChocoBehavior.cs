using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoBehavior : MonoBehaviour
{
    public float speed = 0.1f;
    Rigidbody2D rb;
    float posInicial;
    float posActual;
    int cambio = 0;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position.x;
        posActual = posInicial + 0.1f;
        rb = GetComponent<Rigidbody2D>();
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
            gameObject.SetActive(false);
        }
    }
}
