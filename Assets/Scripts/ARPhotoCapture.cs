using UnityEngine;
using System.IO;
using System.Collections;

public class ARPhotoCapture : MonoBehaviour
{
    private string folderName = "ClementiAR";
    public Canvas uiCanvas; // Assign the Canvas component in the Inspector

    public void CapturePhoto()
    {
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        if (uiCanvas != null)
        {
            uiCanvas.enabled = false; // Disable only the Canvas component
        }

        yield return new WaitForEndOfFrame();

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        byte[] bytes = screenshot.EncodeToPNG();
        Destroy(screenshot);

        string directoryPath;
#if UNITY_EDITOR
        directoryPath = Path.Combine(Application.dataPath, folderName);
#else
        directoryPath = Path.Combine(Application.persistentDataPath, folderName);
#endif

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string filePath = Path.Combine(directoryPath, "AR_Capture_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Screenshot saved to: " + filePath);

        if (uiCanvas != null)
        {
            uiCanvas.enabled = true; // Reactivate Canvas component
        }
    }

}
