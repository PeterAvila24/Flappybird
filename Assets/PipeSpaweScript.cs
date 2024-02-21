using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PipeSpaweScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 5;
    private double timer = 0;
    public float heightOffset = 20;

    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {


        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime / 1.5;
        }
        else
        {
            spawnPipe();
            timer = 0;  
        }
       
    }

    void spawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;


        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

    }

    public void ResetPipeSpawner()
    {
        timer = 0;
    }


}
