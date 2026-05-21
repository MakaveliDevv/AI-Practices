using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "AvoidanceBehavior", menuName = "Boids/Behavior/Avoidance Behavior")]
public class AvoidanceBehavior : FilteredBoidsBehavior
{
    public override Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids)
    {
        if(context == null)
            // return Vector2.zero;
            return Vector3.zero;

        // Vector2 avoidanceMove = Vector2.zero;
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;

        List<Transform> filteredContext = (filter == null)
        ? context
        : filter.Filter(agent, context);

        foreach (Transform boid in filteredContext)
        {
            // if(Vector2.SqrMagnitude(boid.position - agent.transform.position) < boids.SquareAvoidanceRadius)
            // {
            //     nAvoid ++;
            //     avoidanceMove += (Vector2)(agent.transform.position - boid.position);
            // }

            if(Vector3.SqrMagnitude(boid.position - agent.transform.position) < boids.SquareAvoidanceRadius)
            {
                nAvoid ++;
                avoidanceMove += agent.transform.position - boid.position;
            }
        }

        if(nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
