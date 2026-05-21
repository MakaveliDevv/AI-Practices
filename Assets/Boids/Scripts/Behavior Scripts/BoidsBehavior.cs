using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

public abstract class BoidsBehavior : ScriptableObject
{
    public abstract Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids);
}
