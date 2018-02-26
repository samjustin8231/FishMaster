using UnityEngine;

public class Ef_DestroySelf : MonoBehaviour
{
    public float delay = 1f;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
