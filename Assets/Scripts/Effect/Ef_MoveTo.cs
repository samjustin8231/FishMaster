using UnityEngine;

/**
 * 此处主要用来处理鱼死亡时获得金币有个效果：在死亡处生成的金币飞向左下角的goldCollect处
 * 挂在大小金币预制体上
 * */
public class Ef_MoveTo : MonoBehaviour
{
    private GameObject goldCollect;

    void Start()
    {
        goldCollect = GameObject.Find("GoldCollect");
    }

    void Update()
    {
		//MoveTowards插值移动的方式
        transform.position = Vector3.MoveTowards(transform.position, goldCollect.transform.position, 5 * Time.deltaTime);
    }
}
