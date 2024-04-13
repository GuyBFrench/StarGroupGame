using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SceneReferenceList", menuName = "Scenes/Scene List Reference")]
public class SceneReferenceList : ScriptableObject
{
    [SerializeField] private List<SceneReference> sceneReferences = new List<SceneReference>();
    private int currentIndex = 0;

    public void LoadRandomScene()
    {
        if (sceneReferences.Count == 0)
        {
            Debug.LogWarning("Scene list is empty.");
            return;
        }

        int randomIndex = Random.Range(0, sceneReferences.Count);
        sceneReferences[randomIndex].LoadScene();
    }

    public void LoadNextScene()
    {
        if (sceneReferences.Count == 0)
        {
            Debug.LogWarning("Scene list is empty.");
            return;
        }

        sceneReferences[currentIndex].LoadScene();
        currentIndex = (currentIndex + 1) % sceneReferences.Count;
    }
}