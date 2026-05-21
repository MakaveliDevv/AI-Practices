using UnityEngine;

namespace Assets.Boids.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class BoidAgent : MonoBehaviour
    {
        public Boids AgentBoids { get { return agentBoids;}}
        // public Collider2D AgentCollider { get { return agentCollider; } }
        public Collider AgentCollider { get { return AgentCollider; }}
        public Boids agentBoids;
        // public Collider2D agentCollider;
        public Collider agentCollider;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            agentCollider = GetComponent<Collider>();
        }

        public void Initialize(Boids boid)
        {
            agentBoids = boid;
        }

        // public void Move(Vector2 velocity)
        // {
        //     transform.up = velocity.normalized;
        //     transform.position += (Vector3)velocity * Time.deltaTime;
        // }

        public void Move(Vector3 velocity)
        {
            transform.forward = velocity.normalized;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
