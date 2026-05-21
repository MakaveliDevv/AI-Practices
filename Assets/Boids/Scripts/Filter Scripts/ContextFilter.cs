using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

public abstract class ContextFilter : ScriptableObject
{
    public abstract List<Transform> Filter(BoidAgent agent, List<Transform> originalNeighbors);
}
