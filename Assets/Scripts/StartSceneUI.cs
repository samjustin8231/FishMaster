using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 开始scene的uI控制
 * 挂在ScriptHolder上
 * */
public class StartSceneUI : MonoBehaviour
{
	//开始新游戏
    public void NewGame()
    {
		//删除用户的数据
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("lv");
        PlayerPrefs.DeleteKey("exp");
        PlayerPrefs.DeleteKey("scd");
        PlayerPrefs.DeleteKey("bcd");

        SceneManager.LoadScene(1);
    }

    public void OldGame()
    {
		//进入游戏main场景
        SceneManager.LoadScene(1);
    }

    public void OnCloseButton()
    {
        Application.Quit();
    }
}
