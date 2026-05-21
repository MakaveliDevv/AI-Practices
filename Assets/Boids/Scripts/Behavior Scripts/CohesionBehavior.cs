using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "CohesionBehavior", menuName = "Boids/Behavior/Cohesion Behavior")]
public class CohesionBehavior : FilteredBoidsBehavior
{
    public float agentSmoothTime = .5f;
    // private Vector2 currentVelocity;
    private Vector3 currentVelocity;

    public override Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids)
    {
        if(context.Count == 0)
            // return Vector2.zero;
            return Vector3.zero;

        // Vector2 cohesionMove = Vector2.zero;
        Vector3 cohesionMove = Vector3.zero;

        // List<Transform> filteredContext = new();

        // if(filter == null) 
        //     filteredContext = context;
        // else
        //     filteredContext = filter.Filter(agent, context);

        List<Transform> filteredContext = (filter == null) 
        ? context
        : filter.Filter(agent, context);

        foreach (Transform boid in filteredContext)
        {
            cohesionMove += boid.position;          
        }

        // Avarage
        cohesionMove /= context.Count;

        // Creates offset from agent position
        cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref currentVelocity, agentSmoothTime);

        return cohesionMove;
    }
}
