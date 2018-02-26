using UnityEngine;

public class Ef_PlayEffect : MonoBehaviour
{
    public GameObject[] effectPrefabs;

    public void PlayEffect()
    {
        foreach (GameObject effectPrefab in effectPrefabs)
        {
            Instantiate(effectPrefab);
        }
    }
}
