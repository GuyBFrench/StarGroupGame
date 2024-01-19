using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }
    

    
}
