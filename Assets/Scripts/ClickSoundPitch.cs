using UnityEngine;

public class ClickSoundPitch : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource component that plays the sound
    public AudioClip clickSound; // The sound effect to play
    public float pitchIncrease = 0.1f; // Amount to increase pitch per click
    public float maxPitch = 2.0f; // Maximum pitch before resetting

    private float originalPitch; // Stores the original pitch

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Try to get the AudioSource if not assigned
        }

        if (audioSource != null)
        {
            originalPitch = audioSource.pitch; // Store the initial pitch
        }
        else
        {
            Debug.LogError("AudioSource not found! Assign an AudioSource component.");
        }
    }

    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.pitch += pitchIncrease; // Increase pitch
            if (audioSource.pitch > maxPitch)
            {
                audioSource.pitch = originalPitch; // Reset pitch when max is reached
            }

            audioSource.PlayOneShot(clickSound); // Play the sound
        }
    }
}
