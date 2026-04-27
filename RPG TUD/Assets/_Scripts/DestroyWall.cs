using UnityEngine;

public class DestroyWall : MonoBehaviour
{

    public GameObject key;
    
    void Update()
    {
        if (!key.activeSelf)
        {
            Destroy(gameObject);
        }
    }
}
