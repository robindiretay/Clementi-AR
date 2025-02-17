using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera targetCamera;

    void Start()
    {
        // Dynamically find the main camera in the scene when instantiated.
        targetCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (targetCamera != null)
        {
            // Make the UI face the camera.
            transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.forward,
                             targetCamera.transform.rotation * Vector3.up);
        }
    }
}
