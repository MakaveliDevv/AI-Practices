using System.Collections.Generic;
using UnityEngine;

namespace Assets.Boids.Scripts
{
    public class Boids : MonoBehaviour
    {
        public BoidAgent agentPrefab;
        public BoidsBehavior boidsBehavior;

        [SerializeField] private List<BoidAgent> agents = new();

        [Range(10, 500)]
        public int startingCount = 250;
        const float AgentDensity = 0.08f;

        [Range(1f, 100f)] public float driveFactor = 10f;
        [Range(1f, 100f)] public float maxSpeed = 5f;
        [Range(1f, 100f)] public float neighborRadius = 1.5f;
        [Range(0f, 1f)] public float avoidanceMultiplier = .5f;

        private float sqrMaxSpeed;
        private float sqrNeighborRadius;
        private float sqrAvoidanceRadius;
        public float SquareAvoidanceRadius { get { return sqrAvoidanceRadius; }}

        public int expectedNeighbors = 50;
        private Collider[] _contextBuffer;

        void Awake()
        {
            _contextBuffer = new Collider[expectedNeighbors];
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            sqrMaxSpeed = maxSpeed * maxSpeed;
            sqrNeighborRadius = neighborRadius * neighborRadius;
            sqrAvoidanceRadius = sqrNeighborRadius * avoidanceMultiplier * avoidanceMultiplier;

            for (int i = 0; i < startingCount; i++)
            {
                BoidAgent newAgent = Instantiate
                (
                    agentPrefab,
                    startingCount * AgentDensity * Random.insideUnitCircle,
                    Quaternion.Euler(Vector3.forward * Random.Range(0, 360f)),
                    transform
                );

                newAgent.name = "Agent" + i;
                newAgent.Initialize(this);
                agents.Add(newAgent);
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);

                Vector3 move = boidsBehavior.CalculateMove(agent, context, this);
                move *= driveFactor;

                if(move.sqrMagnitude > sqrMaxSpeed) 
                    move = move.normalized * maxSpeed;
                
                agent.Move(move);
            }
        }

        private List<Transform> GetNearbyObjects(BoidAgent agent)
        {
            List<Transform> context = new();

            int count = Physics.OverlapSphereNonAlloc(
                agent.transform.position,
                neighborRadius,
                _contextBuffer
            );

            for (int i = 0; i < count; i++)
            {
                Collider col = _contextBuffer[i];

                if (col != agent.AgentCollider)
                {
                    context.Add(col.transform);
                }
            }

            return context;
        }

        // private List<Transform> GetNearbyObjects(BoidAgent agent)
        // {
        //     List<Transform> context = new();
        //     Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);


        //     foreach (var collider in contextColliders)
        //     {
        //         if(collider != agent.AgentCollider)
        //             context.Add(collider.transform);
        //     }

        //     return context;
        // }
    }
}
