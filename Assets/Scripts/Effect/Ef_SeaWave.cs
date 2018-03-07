using UnityEngine;

/**
 * 浪花特效，浪花从最右边移动到最左边
 * 为浪花动画预制体挂上该脚本和Ef_DestroySelf(4s)的脚本，
 * 	浪花实例化出来后就会自动move，并自动消失(此处时间写死了)
 * */
public class Ef_SeaWave : MonoBehaviour
{
    private Vector3 temp;	//存储浪花开始位置的镜像位置

    void Start()
    {
        temp = -transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, temp, 10 * Time.deltaTime);
    }
}
