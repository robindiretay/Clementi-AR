using UnityEngine;
using System.Collections;

public class DelayedActivator : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    [Header("Delay Settings")]
    public float delay = 2f; // Time in seconds

    public void StartActivationSequence()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        yield return new WaitForSeconds(delay);

        if (objectToDeactivate != null)
            objectToDeactivate.SetActive(false);

        if (objectToActivate != null)
            objectToActivate.SetActive(true);
    }
}