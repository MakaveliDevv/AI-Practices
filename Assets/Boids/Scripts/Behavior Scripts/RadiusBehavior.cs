using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "RadiusBehavior", menuName = "Boids/Behavior/Radius Behavior")]
public class RadiusBehavior : FilteredBoidsBehavior
{
    public Transform centerPlane;
    public Vector3 center;
    public float radius = 15f;

    public override Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids)
    {
        Collider collider = centerPlane.GetComponent<Collider>();
        center = collider.bounds.center;

        Vector3 centerOffset = center - agent.transform.position;
        float t = centerOffset.magnitude / radius;

        if(t < 0.9f)
            // return Vector2.zero;
            return Vector3.zero;

        return t * t * centerOffset;
    }
}
