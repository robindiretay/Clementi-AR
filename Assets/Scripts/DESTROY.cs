using UnityEngine;

public class DESTROY : MonoBehaviour
{
    public GameObject Destroy;

    public void DestroyMe()
    {
        Destroy(gameObject); // Destroys this object immediately
    }
}
