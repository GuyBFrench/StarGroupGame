using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;
    private Rigidbody rigidbody;
    


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }

    public void CauseKockback()
    {
        StartCoroutine(ApplyKnockback());
    }

    private IEnumerator ApplyKnockback()
    {
        rigidbody.useGravity = false;
        agent.enabled = false;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(-transform.forward * 50);
        yield return new WaitForSeconds(1f);
        
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        agent.Warp(transform.position);
        agent.enabled = true;
    }
    

    
}
