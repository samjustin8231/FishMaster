using UnityEngine;

/**
 * 金币收集，鱼死亡时，加金币的有个效果，飞到左下角的“总金币”处，碰撞到之后自动消失
 * 挂在左下角金币汇总的gameObj上
 * */
public class GoldCollect : MonoBehaviour
{
	//金币碰撞到后自动消失
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gold")
        {
            AudioManager.Instance.PlayEffectSound(AudioManager.Instance.goldClip);
            Destroy(collision.gameObject);
        }
    }
}
