using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OnTriggerStayBehavior : MonoBehaviour
{
    public Button openButton;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the button visible
            openButton.gameObject.SetActive(true);
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the button invisible
            openButton.gameObject.SetActive(false);
        }
    }

}
