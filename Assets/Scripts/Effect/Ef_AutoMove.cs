using UnityEngine;

/**
 * 移动脚本：鱼，子弹等移动
 * 为了移动操作变的方便：把鱼的生成方向的所有x轴正方向都对着地图中心
 * 		就可以直接沿着x轴正方向移动
 * */
public class Ef_AutoMove : MonoBehaviour
{
    public float speed = 1f;	//移动速度
	//每种鱼的x轴正方向都调为对着屏幕的中心了，
	//子弹的x轴正方向没有处理，故子弹的dir = Vector3.top
    public Vector3 dir = Vector3.right;		//移动的方向：x轴的正方向

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
