using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript Logic;
    public bool Alive = true;
    bool dead = true;

    public float maxTiltAngle = 20f; // Maximum tilt angle when flying up or down
    public float tiltSpeed = 1f; // Speed of tilting
    public int score = 0;


    public AudioClip flapSound;
    public AudioSource flapSource;
    public AudioClip deadSound;
    public AudioSource deadSource;



    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && Alive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            flapSource.Play();
          

        }
        // Calculate tilt angle based on velocity
        float tiltAngle = Mathf.Lerp(0, maxTiltAngle, myRigidbody.velocity.y / 5f);
        if (myRigidbody.velocity.y < 0)
        {
            tiltAngle = Mathf.Lerp(0, -maxTiltAngle, -myRigidbody.velocity.y / 5f);
        }

        transform.rotation = Quaternion.Euler(0, 0, tiltAngle);

        if ((transform.position.y - 2) > Camera.main.orthographicSize || (transform.position.y + 2) < -Camera.main.orthographicSize)
        {
            if (Alive)
            {
                Logic.gameOver();
                GameOver();
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Logic.gameOver();
        GameOver();
    }

    public void GameOver()
    {
        Alive = false;
        if (dead == true)
        {
            deadSource.Play();
            dead = false;

      
        }
    }

    public void Restart()
    {
        Alive = true;
    }

    public void Flap()
    {
        if (Alive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            flapSource.Play(); // Assuming you have an AudioSource for flapping sound
        }
    }


}
