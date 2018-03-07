using UnityEngine;
using UnityEngine.UI;

/**
 * 该脚本用来控制游戏主界面中backButton,settingButton的UI脚本
 * 挂在ScriptHolder上
 * */
public class MainSceneUI : MonoBehaviour
{
    public Toggle muteToogle;
    public GameObject settingPanel;

    void Start()
    {
        muteToogle.isOn = !AudioManager.Instance.IsMute;
    }

    public void SwitchMute(bool isOn)
    {
        AudioManager.Instance.SwitchMuteState(isOn);
    }

	/**下面的按钮点击事件通过拖拽的方式调用**/
	//点击返回，返回到start场景
    public void OnBackButtonDown()
    {
		//保存用户数据
        PlayerPrefs.SetInt("gold", GameController.Instance.gold);
        PlayerPrefs.SetInt("lv", GameController.Instance.lv);
        PlayerPrefs.SetFloat("scd", GameController.Instance.smallTimer);
        PlayerPrefs.SetFloat("bcd", GameController.Instance.bigTimer);
        PlayerPrefs.SetInt("exp", GameController.Instance.exp);
        int temp = (AudioManager.Instance.IsMute == false) ? 0 : 1;
        PlayerPrefs.SetInt("mute", temp);
		//进入场景start
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

	//设置按钮
    public void OnSettingButtonDown()
    {
        settingPanel.SetActive(true);
    }

	//设置中的close button
    public void OnCloseButtonDown()
    {
        settingPanel.SetActive(false);
    }
}
