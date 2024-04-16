using UnityEngine;
using System.Collections.Generic;

public class GameObjectPooler : MonoBehaviour
{
    public List<GameObject> initialPoolObjects = new List<GameObject>();
    public Vector3DataList spawnPositions; // Reference to Vector3DataList
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        if (initialPoolObjects.Count == 0)
        {
            Debug.LogWarning("No initial pool objects assigned to the GameObjectPooler.");
            return;
        }

        if (spawnPositions == null || spawnPositions.vector3DList.Count == 0)
        {
            Debug.LogWarning("No spawn positions assigned to the GameObjectPooler.");
            return;
        }

        // Add objects from the scene to the pool
        foreach (GameObject obj in initialPoolObjects)
        {
            AddObjectToPool(obj);
        }
    }

    void AddObjectToPool(GameObject obj)
    {
        if (obj != null)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject newObj = Instantiate(obj, randomPosition, Quaternion.identity);
            newObj.SetActive(false);
            objectPool.Add(newObj);
        }
        else
        {
            Debug.LogWarning("Attempting to add a null object to the pool.");
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
            Debug.LogWarning("No spawn positions assigned to the GameObjectPooler.");
            return;
        }

        Vector3 randomPosition = GetRandomPosition();
        objToRespawn.SetActive(false);
        objToRespawn.transform.position = randomPosition;
        objToRespawn.SetActive(true);
    }
}
