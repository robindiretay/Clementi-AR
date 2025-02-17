using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARModelPlacer : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager imageManager;
    [SerializeField] private GameObject modelPrefab;  // Assign your model prefab in Inspector
    [SerializeField] private Transform arCamera;      // Assign the AR Camera from the scene
    [SerializeField] private LayerMask floorLayer;    // Assign a layer for valid floors
    [SerializeField] private GameObject buildGUI;
    [SerializeField] private GameObject buildGUIButton;

    private GameObject spawnedModel;
    private bool isPlacing = false;

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            if (!isPlacing) // If not already placing, start placement mode
            {
                StartPlacementMode();
                buildGUIButton.SetActive(true);
            }
        }
    }

    public void StartPlacementMode()
    {
        isPlacing = true;
        spawnedModel = Instantiate(modelPrefab);
    }

    private void Update()
    {
        if (isPlacing && spawnedModel != null)
        {
            // Make the model follow the center of the AR camera view
            Vector3 targetPosition = arCamera.position + arCamera.forward * 2f; // Adjust distance as needed
            spawnedModel.transform.position = targetPosition;
        }
    }

    public void PlaceObject()
    {
        if (!isPlacing || spawnedModel == null) return;

        // Perform a downward raycast to check for a floor
        if (Physics.Raycast(spawnedModel.transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, floorLayer))
        {
            spawnedModel.transform.position = hit.point; // Snap to the detected floor
            isPlacing = false;
            buildGUI.SetActive(true);
            buildGUIButton.SetActive(false);
        }
        else
        {
            Debug.Log("Invalid Placement: No floor detected!");
        }
    }
}
