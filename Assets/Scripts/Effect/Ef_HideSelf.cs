using UnityEngine;
using System.Collections;

/**
 * n秒后自动隐藏，这个项目里仅仅用在升级提示的自动隐藏
 * 挂在LvUpTips这个物体上
 * */
public class Ef_HideSelf : MonoBehaviour
{
    public IEnumerator HideSelf(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
