using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChestBehaviour : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public UnityEvent pickupEvent, stopPlayerEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", true);
            stopPlayerEvent.Invoke();
            StartCoroutine(BeginPickUp());

        }
        
        
    }

    private IEnumerator BeginPickUp()
    {
        
        yield return new WaitForSeconds(2);
        
        pickupEvent.Invoke();
    }
}
