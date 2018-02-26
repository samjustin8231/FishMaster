using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gold")
        {
            AudioManager.Instance.PlayEffectSound(AudioManager.Instance.goldClip);
            Destroy(collision.gameObject);
        }
    }
}
