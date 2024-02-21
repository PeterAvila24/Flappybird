using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript Logic;
    

    public AudioClip scoreSound;
    public AudioSource scoreSource;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        { 
            if (Logic.GOver == false)
            {
                Logic.addScore(1);
                scoreSource.Play();
            }
        }
       
    }
}
