using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("lv");
        PlayerPrefs.DeleteKey("exp");
        PlayerPrefs.DeleteKey("scd");
        PlayerPrefs.DeleteKey("bcd");
        SceneManager.LoadScene(1);
    }

    public void OldGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCloseButton()
    {
        Application.Quit();
    }
}
