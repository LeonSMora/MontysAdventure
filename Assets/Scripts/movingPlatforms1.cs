using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatforms1 : MonoBehaviour
{
    public float speed = 1.3f;
    float posInicial;
    float rival;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rival < Time.time)
        {
            speed *= -1;
            rival = Time.time + 3.8f;
        }

        rb.velocity = Vector2.right * speed;
        
    }
}
