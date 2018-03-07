using UnityEngine;

/**
 * 让转弯生成的鱼自动按照一定的角度旋转
 * 用在转弯生成鱼的地方，动态挂在需要的鱼上
 * */
public class Ef_AutoRotate : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
		//Vector3.forward：z轴正方向
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
