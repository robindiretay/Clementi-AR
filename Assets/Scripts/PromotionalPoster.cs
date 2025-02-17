using UnityEngine;

public class PromotionalPoster : MonoBehaviour
{
    void Start()
    {
        DisplayTitle("Hello! Name's Robin.");
        DisplayDescription("Nice to meet you!");
    }

    void DisplayTitle(string title)
    {
        Debug.Log("Congrats! You've made it!");
    }

    void DisplayDescription(string description)
    {
        Debug.Log("This is my promotional poster with past works - both personal and school.");
    }
}
