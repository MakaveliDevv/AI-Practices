using UnityEngine;
using System.Collections.Generic;
using Assets.Boids.Scripts;

[CreateAssetMenu(fileName = "AlignmentBehavior", menuName = "Boids/Behavior/Alignment Behavior")]
public class AlignmentBehavior : FilteredBoidsBehavior
{
    public override Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids)
    {
        if(context.Count == 0)
            // return agent.transform.up;
            return agent.transform.forward;
        
        // Vector2 alignmentMove = Vector2.zero;
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null)
        ? context
        :
        filter.Filter(agent, context);

        foreach (Transform boid in filteredContext)
        {
            // alignmentMove += boid.transform.up;
            alignmentMove += boid.transform.forward;
        }

        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
