using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    public Text oneShootCostText;
    public Text goldText;
    public Text lvText;
    public Text lvNameText;
    public Text smallCountdownText;
    public Text bigCountdownText;
    public Button bigCountdownButton;
    public Button backButton;
    public Button settingButton;
    public Slider expSlider;

    public int lv = 0;
    public int exp = 0;
    public int gold = 500;
    public const int bigCountdown = 240;
    public const int smallCountdown = 60;
    public float bigTimer = bigCountdown;
    public float smallTimer = smallCountdown;
    public Color goldColor;
    public int bgIndex = 0;

    public Image bgImage;
    public GameObject lvUpTips;
    public GameObject seaWaveEffect;
    public GameObject fireEffect;
    public GameObject changeEffect;
    public GameObject lvEffect;
    public GameObject goldEffect;

    public Transform bulletHolder;
    public Sprite[] bgSprites;
    public GameObject[] gunGos;
    public GameObject[] bullet1Gos;
    public GameObject[] bullet2Gos;
    public GameObject[] bullet3Gos;
    public GameObject[] bullet4Gos;
    public GameObject[] bullet5Gos;

    //使用的是第几档的炮弹
    private int costIndex = 0;
    //每一炮所需的金币数和造成的伤害值
    private int[] oneShootCosts = { 5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    private string[] lvName = { "新手", "入门", "钢铁", "青铜", "白银", "黄金", "白金", "钻石", "大师", "宗师" };

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        gold = PlayerPrefs.GetInt("gold", gold);
        lv = PlayerPrefs.GetInt("lv", lv);
        exp = PlayerPrefs.GetInt("exp", exp);
        smallTimer = PlayerPrefs.GetFloat("scd", smallCountdown);
        bigTimer = PlayerPrefs.GetFloat("bcd", bigCountdown);
        UpdateUI();
    }

    void Update()
    {
        ChangeBulletCost();
        Fire();
        UpdateUI();
        ChangeBg();
    }

    void ChangeBg()
    {
        if (bgIndex != lv / 20)
        {
            bgIndex = lv / 20;
            AudioManager.Instance.PlayEffectSound(AudioManager.Instance.seaWaveClip);
            Instantiate(seaWaveEffect);
            if (bgIndex >= 3)
            {
                bgImage.sprite = bgSprites[3];
            }
            else
            {
                bgImage.sprite = bgSprites[bgIndex];
            }
        }
    }

    void UpdateUI()
    {
        bigTimer -= Time.deltaTime;
        smallTimer -= Time.deltaTime;
        if (smallTimer <= 0)
        {
            smallTimer = smallCountdown;
            gold += 50;
        }
        if (bigTimer <= 0 && bigCountdownButton.gameObject.activeSelf == false)
        {
            bigCountdownText.gameObject.SetActive(false);
            bigCountdownButton.gameObject.SetActive(true);
        }
        //经验等级换算公式：升级所需经验=1000+200*当前等级
        while (exp >= 1000 + 200 * lv)
        {
            exp = exp - (1000 + 200 * lv);
            lv++;
            lvUpTips.SetActive(true);
            lvUpTips.transform.Find("Text").GetComponent<Text>().text = lv.ToString();
            StartCoroutine(lvUpTips.GetComponent<Ef_HideSelf>().HideSelf(0.6f));
            AudioManager.Instance.PlayEffectSound(AudioManager.Instance.lvUpClip);
            Instantiate(lvEffect);
        }
        goldText.text = "$" + gold;
        lvText.text = lv.ToString();
        if ((lv / 10) <= 9)
        {
            lvNameText.text = lvName[lv / 10];
        }
        else
        {
            lvNameText.text = lvName[9];
        }
        smallCountdownText.text = "  " + (int)smallTimer / 10 + "  " + (int)smallTimer % 10;
        bigCountdownText.text = (int)bigTimer + "s";
        expSlider.value = ((float)exp) / (1000 + 200 * lv);
    }

    void Fire()
    {
        GameObject[] useBullets = bullet5Gos;
        int bulletIndex;
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (gold - oneShootCosts[costIndex] >= 0)
            {
                switch (costIndex / 4)
                {
                    case 0: useBullets = bullet1Gos; break;
                    case 1: useBullets = bullet2Gos; break;
                    case 2: useBullets = bullet3Gos; break;
                    case 3: useBullets = bullet4Gos; break;
                    case 4: useBullets = bullet5Gos; break;
                }
                bulletIndex = (lv % 10 >= 9) ? 9 : lv % 10;
                gold -= oneShootCosts[costIndex];
                AudioManager.Instance.PlayEffectSound(AudioManager.Instance.fireClip);
                Instantiate(fireEffect);
                GameObject bullet = Instantiate(useBullets[bulletIndex]);
                bullet.transform.SetParent(bulletHolder, false);
                bullet.transform.position = gunGos[costIndex / 4].transform.Find("FirePos").transform.position;
                bullet.transform.rotation = gunGos[costIndex / 4].transform.Find("FirePos").transform.rotation;
                bullet.GetComponent<BulletAttr>().damage = oneShootCosts[costIndex];
                bullet.AddComponent<Ef_AutoMove>().dir = Vector3.up;
                bullet.GetComponent<Ef_AutoMove>().speed = bullet.GetComponent<BulletAttr>().speed;
            }
            else
            {
                StartCoroutine(GoldNotEnough());
            }
        }
    }

    void ChangeBulletCost()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            OnButtonMDown();
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            OnButtonPDown();
        }
    }

    public void OnButtonPDown()
    {
        gunGos[costIndex / 4].SetActive(false);
        costIndex++;
        AudioManager.Instance.PlayEffectSound(AudioManager.Instance.changeClip);
        Instantiate(changeEffect);
        costIndex = (costIndex > oneShootCosts.Length - 1) ? 0 : costIndex;
        gunGos[costIndex / 4].SetActive(true);
        oneShootCostText.text = "$" + oneShootCosts[costIndex];
    }

    public void OnButtonMDown()
    {
        gunGos[costIndex / 4].SetActive(false);
        costIndex--;
        AudioManager.Instance.PlayEffectSound(AudioManager.Instance.changeClip);
        Instantiate(changeEffect);
        costIndex = (costIndex < 0) ? oneShootCosts.Length - 1 : costIndex;
        gunGos[costIndex / 4].SetActive(true);
        oneShootCostText.text = "$" + oneShootCosts[costIndex];
    }

    public void OnBigCountdownButtonDown()
    {
        gold += 500;
        AudioManager.Instance.PlayEffectSound(AudioManager.Instance.rewardClip);
        Instantiate(goldEffect);
        bigCountdownButton.gameObject.SetActive(false);
        bigCountdownText.gameObject.SetActive(true);
        bigTimer = bigCountdown;
    }

    IEnumerator GoldNotEnough()
    {
        goldText.color = goldColor;
        goldText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        goldText.color = goldColor;
    }
}
