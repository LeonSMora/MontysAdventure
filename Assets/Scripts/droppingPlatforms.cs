using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droppingPlatforms : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("dropping", 0.95f);

        }
    }

    void dropping()
    {
        rb.isKinematic = false;
    }
}
