using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Filter/SameBoids")]
public class BoidsFilter : ContextFilter
{
    public override List<Transform> Filter(BoidAgent boidAgent, List<Transform> originalNeighbors)
    {
        List<Transform> filtered = new();

        foreach (Transform neighbor in originalNeighbors)
        {
            BoidAgent agent = neighbor.GetComponent<BoidAgent>();
            if(agent != null && agent.AgentBoids == agent.AgentBoids)
                filtered.Add(neighbor);
        }

        return filtered;
    }
}
