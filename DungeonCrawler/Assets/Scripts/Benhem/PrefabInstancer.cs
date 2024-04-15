using UnityEngine;
using System.Collections.Generic;

public class PrefabInstancer : MonoBehaviour
{
    public List<GameObject> prefabs = new List<GameObject>();
    public int initialPoolSize = 10;
    public Vector3DataList spawnPositions; // Reference to Vector3DataList
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        if (prefabs.Count == 0)
        {
            Debug.LogWarning("No prefabs assigned to the PrefabInstancer.");
            return;
        }

        if (spawnPositions == null || spawnPositions.vector3DList.Count == 0)
        {
            Debug.LogWarning("No spawn positions assigned to the PrefabInstancer.");
            return;
        }

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Count)];
            Vector3 randomPosition = GetRandomPosition();
            GameObject obj = Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3Data randomPosData = spawnPositions.vector3DList[Random.Range(0, spawnPositions.vector3DList.Count)];
        return randomPosData.value;
    }

    public GameObject GetObjectFromPool()
    {
        if (objectPool.Count == 0)
        {
            Debug.LogWarning("Object pool is empty.");
            return null;
        }

        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public void RespawnObject(GameObject objToRespawn)
    {
        if (spawnPositions == null || spawnPositions.vector3DList.Count == 0)
        {
            Debug.LogWarning("No spawn positions assigned to the PrefabInstancer.");
            return;
        }

        Vector3 randomPosition = GetRandomPosition();
        objToRespawn.SetActive(false);
        objToRespawn.transform.position = randomPosition;
        objToRespawn.SetActive(true);
    }
}
