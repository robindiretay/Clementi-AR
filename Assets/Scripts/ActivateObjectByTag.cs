using UnityEngine;

public class ActivateObjectByTag : MonoBehaviour
{
    public string targetTag = "YourTagHere"; // Set the tag in the Inspector or via script

    public void ActivateObject()
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>(); // Includes inactive objects
        foreach (GameObject obj in objects)
        {
            if (obj.CompareTag(targetTag))
            {
                obj.SetActive(true);
                Debug.Log("Activated: " + obj.name);
                return;
            }
        }

        Debug.LogWarning("No GameObject found with tag: " + targetTag);
    }

    public void DisableMeshRenderer()
    {
        GameObject targetObject = GameObject.FindWithTag(targetTag);
        if (targetObject != null)
        {
            MeshRenderer meshRenderer = targetObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                Debug.LogWarning("No MeshRenderer found on object with tag: " + targetTag);
            }
        }
        else
        {
            Debug.LogWarning("No GameObject found with tag: " + targetTag);
        }
    }
}
