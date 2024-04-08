using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // If no neighbors return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        // Add all points together and average
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        foreach (Transform item in context)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SqrAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += agent.transform.position - item.position;
            }
        }

        // Average out the avoidance, it could be the case that everyonen is just in right position
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }

}
