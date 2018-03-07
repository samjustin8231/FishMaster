using UnityEngine;

/**
 * 鱼的类
 * 挂在鱼的预制体上
 * 
 * 做的事情：撞到border消失； takeDamage(调用+gold,+exp; 播放鱼死亡特效；产生金币飞向左下角特效； 鱼对象销毁)
 * 鱼移动的事情交给了Ef_AutoMove脚本
 * */
public class FishAttr : MonoBehaviour
{
    public int hp;			//该鱼的hp
	public int exp;			//击中该鱼获得exp
    public int gold;		//击中该鱼获得金币数
    public int maxNum;		//生成数量最大值
    public int maxSpeed;	//生成鱼的移动速度最大值

    public GameObject diePrefab;
    public GameObject goldPrefab;

	/**
	 * 碰撞检测，碰撞体是物理组件的一类，它要与刚体一起添加到游戏对象上才能触发碰撞
	 * 发生碰撞的东西双方至少有一个是要带刚体的(并且是动态的)，即只有带刚体的碰撞体去撞其他碰撞体时，双方才会收到碰撞事件
	 * 
	 * 鱼和Border至少有一个添加刚体，此处是在Border和鱼上都添加了刚体(鱼上面可以不用添加刚体的，
	 * 	但是为了后面子弹和鱼碰撞，所以鱼身上也挂上了刚体)，并且都添加了BoxCollider2D
	 * 两个碰撞器中至少有一个开启了IsTrigger，为了不会发生物理中的碰撞后反弹(为了碰撞后穿越过去)
	 * 
	 * 参数collision: 鱼碰撞到的东西
	 * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//鱼碰撞到Border，自动销毁
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

	/**
	 * 子弹击中鱼，鱼受到伤害
	 * 当hp<=0时鱼死亡
	 * 
	 * 做的事情：调用+gold,+exp; 播放鱼死亡特效；产生金币飞向左下角特效； 鱼对象销毁
	 * */
    void TakeDamage(int value)
    {
        hp -= value;
        if (hp <= 0)
        {//鱼死亡
			//1.子弹命中鱼得到相应的gold和exp
            GameController.Instance.gold += gold;
            GameController.Instance.exp += exp;

			//2.播放鱼死亡效果
            GameObject die = Instantiate(diePrefab);	//鱼死亡的预制体身上有Ef_DestroySelf脚本，1s后会自动销毁
            die.transform.SetParent(gameObject.transform.parent, false);
            die.transform.position = transform.position;
            die.transform.rotation = transform.rotation;

			//3.鱼死亡后会有获得金币的效果(飞向左下角，然后消失)
            GameObject goldGo = Instantiate(goldPrefab);
            goldGo.transform.SetParent(gameObject.transform.parent, false);
            goldGo.transform.position = transform.position;
            goldGo.transform.rotation = transform.rotation;

			//鲨鱼死亡时，播放粒子特效
			//只给金鲨和银鲨添加了播放特效的脚本
            if (gameObject.GetComponent<Ef_PlayEffect>() != null)
            {
				//播放获得金币的音效
                AudioManager.Instance.PlayEffectSound(AudioManager.Instance.rewardClip);
				//播放金币飞的特效
                gameObject.GetComponent<Ef_PlayEffect>().PlayEffect();
            }
			//4.鱼对象销毁
            Destroy(gameObject);
        }
    }
}
