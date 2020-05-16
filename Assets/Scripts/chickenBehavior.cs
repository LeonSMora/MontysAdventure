﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenBehavior : MonoBehaviour
{

    Transform psPosition;
    ParticleSystem ps;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("chickenParticles").GetComponent<ParticleSystem>();
        psPosition = GameObject.Find("chickenParticles").GetComponent<Transform>();
        audio = GameObject.Find("chickenAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audio.Play();
            gameObject.SetActive(false);
            psPosition.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
            ps.Play();
        }
    }

}
