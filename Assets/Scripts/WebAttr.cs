using UnityEngine;

/**
 * 做的事情：fish碰到网，受伤害；(受伤害的具体过程交给鱼自己来)
 * 挂在网的预制体上
 * */
public class WebAttr : MonoBehaviour
{
    public float disapperTime;	//网的自动消失时间
    public int damage;	

    void Start()
    {
        Destroy(gameObject, disapperTime);	//网几秒后销毁自己
    }

	//鱼生成挂了动态刚体，故网身上只需要加上boxcollider2d
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//子弹碰到鱼
        if (collision.tag=="Fish")
        {
			//给鱼发送消息，通知鱼执行TakeDamage方法
            collision.SendMessage("TakeDamage", damage);
        }
    }
}
