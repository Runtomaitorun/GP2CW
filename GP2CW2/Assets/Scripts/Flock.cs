using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    [Header("FlockGroup")]
    [Range(10, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Header("Neighbors")]
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    [Header("AccessiveMath")]
    float sqrMaxSpeed;
    float sqrNeighborRadius;
    float sqrAvoidanceRadius;
    public float SqrAvoidanceRadius { get { return sqrAvoidanceRadius; } }


    void Start()
    {
        // To simplify further math
        sqrMaxSpeed = maxSpeed * maxSpeed;
        sqrNeighborRadius = neighborRadius * neighborRadius;
        sqrAvoidanceRadius = sqrNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        // Properties in each flockAgent
        for ( int i = 0; i < startingCount; i++ )
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * startingCount * AgentDensity,// the size of the circle is based on the number and density of our flock
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform// set the parent of all agents
                );
            newAgent.name = "Agent" + i;
            agents.Add(newAgent);

        }
    }

}
