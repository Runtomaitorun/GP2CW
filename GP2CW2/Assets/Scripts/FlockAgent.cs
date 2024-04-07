using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Collider2D agentCollider;
    public Collider2D AgentCollider {  get { return agentCollider; } }

    
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector3 velocity)
    {
        // set direction for flock velocity
        transform.forward = velocity;//transform.forward for 3D

        // set velocity for flocks
        transform.position += velocity * Time.deltaTime;
        
    }


}
