using System.Collections.Generic;
using UnityEngine;
using Assets.Boids.Scripts;

[CreateAssetMenu(fileName = "MouseAttractionBehavior", menuName = "Boids/Behavior/Mouse Attraction")]
public class MouseAttractionBehavior : BoidsBehavior
{
    // public float weight = 1f;

    public override Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids)
    {
        Vector3 mousePos = MouseMovement.Instance.GetMouseWorldPosition();

        Vector3 direction = mousePos - agent.transform.position;

        return direction.normalized;
    }
}