
using UnityEngine;

public class WorldSpaceCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void FixedUpdate()
    {
        transform.LookAt(player);
    }
}
