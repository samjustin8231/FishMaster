using UnityEngine;

public class Ef_SeaWave : MonoBehaviour
{
    private Vector3 temp;

    void Start()
    {
        temp = -transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, temp, 10 * Time.deltaTime);
    }
}
