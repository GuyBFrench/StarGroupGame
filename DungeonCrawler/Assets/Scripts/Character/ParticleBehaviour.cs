using System.Collections;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(turnOffParticle());
    }

    private IEnumerator turnOffParticle()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
