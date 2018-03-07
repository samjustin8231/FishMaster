using UnityEngine;

/**
 * 子弹类
 * 做的事情：撞到鱼生成网（至于鱼碰到网受伤害，交给网自己），多久消失(交给Ef_DestroySelf)，撞到border消失
 * 子弹飞的事情交给了Ef_AutoMove
 * 该类会挂载到每种子弹的预制体上
 * */
public class BulletAttr : MonoBehaviour
{
    public int speed;
    public int damage;
    public GameObject webPrefab;	//子弹碰到鱼生成的网的预制体

	//border身上挂了刚体，子弹上没有挂刚体，只有boxcollider2d,
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//子弹碰撞到Border，自动销毁
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }

		//子弹碰撞到鱼，生成网，并销毁自己
        if (collision.tag == "Fish")
        {
            GameObject web = Instantiate(webPrefab);						
            web.transform.SetParent(gameObject.transform.parent, false);	//将生成的网和子弹放在同一个容器中
            web.transform.position = gameObject.transform.position;
            web.GetComponent<WebAttr>().damage = damage;

			//销毁子弹
            Destroy(gameObject);
        }
    }
}
