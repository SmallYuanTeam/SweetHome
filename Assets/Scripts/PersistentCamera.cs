using UnityEngine;

public class PersistentCamera : MonoBehaviour
{
    private static bool cameraExists;

    void Awake()
    {
        if (!cameraExists)
        {
            DontDestroyOnLoad(gameObject);
            cameraExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
