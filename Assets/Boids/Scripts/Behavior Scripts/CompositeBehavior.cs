using System.Collections.Generic;
using Assets.Boids.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "CompositeBehavior", menuName = "Boids/Behavior/Composite Behavior")]
public class CompositeBehavior : BoidsBehavior
{
    public BoidsBehavior[] behaviors;
    public float[] weights;

    public override Vector3 CalculateMove(BoidAgent agent, List<Transform> context, Boids boids)
    {
        // Handle data mismatch
        if(weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            // return Vector2.zero;
            return Vector3.zero;
        }

        // Vector2 compositeMove = Vector2.zero;
        Vector3 compositeMove = Vector3.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            // Vector2 partialMove = behaviors[i].CalculateMove(agent, context, boids) * weights[i];
            Vector3 partialMove = behaviors[i].CalculateMove(agent, context, boids) * weights[i];

            // Confirm this partial move is limited to the extend of the weight
            if(partialMove != Vector3.zero)
            {
                if(partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                compositeMove += partialMove;
            }
        }

        return compositeMove;
    }
}
