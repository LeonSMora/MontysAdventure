using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccomplishedGoal : MonoBehaviour
{

    ParticleSystem ps;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("LoveParticles").GetComponent<ParticleSystem>();
        audio = GameObject.Find("Finish").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audio.Play();
            ps.Play();
            Invoke("changeSceneTo", 1);
        }
    }

    public void changeSceneTo()
    {
        SceneManager.LoadScene("WinScene");
    }
}
