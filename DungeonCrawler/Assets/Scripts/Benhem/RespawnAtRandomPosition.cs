using UnityEngine;

public class RespawnAtRandomPosition : MonoBehaviour
{
    public Vector3DataList spawnPositions; // Reference to Vector3DataList

    private Vector3[] childOffsets; // Store original positions of children relative to parent

    void Start()
    {
        // Store original positions of children relative to parent
        StoreChildOffsets();
    }

    public void RespawnAtRandomLocation()
    {
        if (spawnPositions == null || spawnPositions.vector3DList.Count == 0)
        {
            Debug.LogWarning("No spawn positions assigned.");
            return;
        }

        Vector3 randomPosition = GetRandomPosition();
        transform.position = randomPosition;

        // Apply the same offset to children after moving the parent
        ApplyChildOffsets();
    }

    Vector3 GetRandomPosition()
    {
        Vector3Data randomPosData = spawnPositions.vector3DList[Random.Range(0, spawnPositions.vector3DList.Count)];
        return randomPosData.value;
    }

    void StoreChildOffsets()
    {
        int childCount = transform.childCount;
        childOffsets = new Vector3[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childOffsets[i] = transform.GetChild(i).localPosition;
        }
    }

    void ApplyChildOffsets()
    {
        if (childOffsets == null || childOffsets.Length == 0)
            return;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = childOffsets[i];
        }
    }
}