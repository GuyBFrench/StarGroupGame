using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SlimeEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Rigidbody rigidbody;
    private NavMeshAgent agent;
    


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        transform.LookAt(player);
    }

    public void OnMove()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        agent.SetDestination(player.position);
        yield return new WaitForSeconds(1);
        agent.SetDestination(transform.position);
    }
    

}
