using System.Collections;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class FlappyBirdAgent : Agent
{
    public BirdScript bird;
    public PipeSpaweScript pipeSpawner;

    public override void OnEpisodeBegin()
    {
        // Reset the environment when a new episode begins
        bird.Restart();
        pipeSpawner.ResetPipeSpawner();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Collect observations from the environment
        sensor.AddObservation(bird.transform.position);
        sensor.AddObservation(bird.myRigidbody.velocity);
        sensor.AddObservation(pipeSpawner.transform.position);
        // Add more observations as needed
    }

    public void OnActionReceived(float[] vectorAction)
    {
        // Take actions based on the neural network's output
        int action = Mathf.FloorToInt(vectorAction[0]);
        if (action == 1)
        {
            // Flap the bird
            bird.Flap();
        }

        // Optionally, penalize the agent for taking too long to complete an episode
        AddReward(-0.001f);

        // Check for game over conditions
        if (!bird.Alive)
        {
            EndEpisode();
        }
    }

    public void Heuristic(float[] actionsOut)
    {
        // Define a manual control for testing (optional)
        actionsOut[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }
}
