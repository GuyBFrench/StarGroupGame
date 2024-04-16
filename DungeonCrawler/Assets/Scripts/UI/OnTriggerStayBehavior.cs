using UnityEngine;
using UnityEngine.UI;

public class OnTriggerStayBehavior : MonoBehaviour
{
    public Button myButton;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the button visible
            myButton.gameObject.SetActive(true);
        }
    }
    
}
