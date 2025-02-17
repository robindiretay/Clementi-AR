using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public GameObject childToToggle; // Reference to the child object

    public void OnSelected()
    {
        if (childToToggle != null)
        {
            // Toggle the active state of the child object
            childToToggle.SetActive(!childToToggle.activeSelf);
            Debug.Log($"Child object {childToToggle.name} toggled.");
        }
        else
        {
            Debug.LogWarning("No child object assigned to toggle.");
        }
    }

    private void OnMouseDown() // For touch or click selection
    {
        OnSelected();
    }
}
