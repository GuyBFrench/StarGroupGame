
using UnityEngine;
using UnityEngine.Events;

namespace Brady
{
    public class TriggerEventsBehaviour : MonoBehaviour
    {

        public UnityEvent onEnemyDamage, onPlayerDamage;
        
        private void OnTriggerEnter(Collider other)
        {


            if (other.gameObject.CompareTag("Sword"))
            {
             onEnemyDamage.Invoke();
            }
            
            if (other.gameObject.CompareTag("Player"))
            {
                onPlayerDamage.Invoke(); 
            }
        }
        
        
    }    
}

