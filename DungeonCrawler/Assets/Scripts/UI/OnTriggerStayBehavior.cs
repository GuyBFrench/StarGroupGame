using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnTriggerStayBehavior : MonoBehaviour
{
    public Button openButton;
    public UnityEvent cheerEvent,endCheerEvent;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the button visible
            openButton.gameObject.SetActive(true);
            cheerEvent.Invoke();
            Debug.Log("Yes");
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the button invisible
            openButton.gameObject.SetActive(false);
            endCheerEvent.Invoke();
        }
    }

}
