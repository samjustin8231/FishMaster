using UnityEngine;

/**
 * 自动销毁的脚本，如果某个gameObj需要几秒后自动销毁，只需挂上该脚本就可以了
 * 鱼死亡后显示n秒后自动隐藏，特效播放n秒后自动隐藏
 * 挂在鱼死亡预制体，需要销毁的各种特效预制体
 * */
public class Ef_DestroySelf : MonoBehaviour
{
    public float delay = 1f;	
    void Start()
    {
        Destroy(gameObject, delay);
    }
}
