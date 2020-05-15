﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenBehavior : MonoBehaviour
{

    Transform psPosition;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("chickenParticles").GetComponent<ParticleSystem>();
        psPosition = GameObject.Find("chickenParticles").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
            psPosition.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
            ps.Play();
        }
    }

}
