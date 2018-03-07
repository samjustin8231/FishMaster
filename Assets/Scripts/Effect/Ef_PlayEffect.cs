using UnityEngine;

/**
 * 播放特效的脚本
 * */
public class Ef_PlayEffect : MonoBehaviour
{
    public GameObject[] effectPrefabs;	//需要播放的特效的预制体，通过拖拽的方式给需要的物体赋值

    public void PlayEffect()
    {
        foreach (GameObject effectPrefab in effectPrefabs)
        {
            Instantiate(effectPrefab);
			//对于播放完特效后需要消失的哪些特效，已经在预制体中挂上了Ef_DestroySelf的脚本
        }
    }
}
