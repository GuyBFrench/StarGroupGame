
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehaviour : MonoBehaviour
{

    public UnityEvent onEnemyDamage, onPlayerDamage;

    private Rigidbody rigidEnemy;

    private void Awake()
    {
        rigidEnemy = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("contact");
        if (other.gameObject.CompareTag("Player"))
        {
           onPlayerDamage.Invoke(); 
        }

        if (other.gameObject.CompareTag("Sword"))
        {
         onEnemyDamage.Invoke();
        }
        
        
    }
    
}
