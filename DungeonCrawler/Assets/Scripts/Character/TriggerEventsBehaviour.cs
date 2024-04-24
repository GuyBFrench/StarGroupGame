
using UnityEngine;
using UnityEngine.Events;

namespace Brady
{
    public class TriggerEventsBehaviour : MonoBehaviour
    {

        public UnityEvent onEnemyDamage, onPlayerDamage, onCheerEnd;
        
        private void OnTriggerEnter(Collider other)
        {


            if (other.gameObject.CompareTag("Sword"))
            {
             onEnemyDamage.Invoke();
             Debug.Log("hi");
            }
            
            if (other.gameObject.CompareTag("Player"))
            {
                onPlayerDamage.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            
            if (other.gameObject.CompareTag("Player"))
            {
                onCheerEnd.Invoke(); 
            }
            
        }
        
        
    }    
}

