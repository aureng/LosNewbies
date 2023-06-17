using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TMP_Text speedText;
    public TMP_Text defText;
    public TMP_Text attText;
    public PlayerProfileSO ppSO;
    public Image XPimg;
    public TMP_Text xpValue;
    public TMP_Text skillpoints;
    public TMP_Text IDtext;
    public string sdkWallet= "Ku328hDjdunlDjsdak9128u31j";
    public Button up1;
    public Button up2;
    public Button up3;
    public Button down1;
    public Button down2;
    public Button down3;
    public Button upgrade;
    public TMP_Text txtConection;

    private int maxPoints;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ppSO.skillsPoints = 3;
        }
    }
    private void Start()
    {

        down1.interactable = false;
        down2.interactable = false;
        down3.interactable = false;
        skillpoints.text = "" + ppSO.skillsPoints;
        maxPoints = ppSO.skillsPoints;
        XPimg.fillAmount = (float)ppSO.xperience / 100;
        xpValue.text = "" + ppSO.xperience;
        if (maxPoints == 0)
        {
            up1.interactable = false;
            up2.interactable = false;
            up3.interactable = false;
            upgrade.interactable = false;
        }
        UpdateSkillsTxt();

    }
    public void ConnectWallet()
    {
        SDKQuery();
    }
    public void DisconnectWallet()
    {
        IDtext.text = "Guess";
        speedText.text = "- -";
        defText.text = "- -";
        attText.text = "- -";
        xpValue.text = "- -";
        XPimg.fillAmount =0;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("frish");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void SDKQuery()
    {
        IDtext.text = "ID: " + sdkWallet;
        ppSO.def = ppSO.def;
        ppSO.att = ppSO.att;
        ppSO.speed = ppSO.speed;
        xpValue.text = ""+ppSO.xperience;
        XPimg.fillAmount = (float)ppSO.xperience / 100;

        down1.interactable = false;
        down2.interactable = false;
        down3.interactable = false;
        skillpoints.text = "" + ppSO.skillsPoints;
        maxPoints = ppSO.skillsPoints;
        if (maxPoints == 0)
        {
            up1.interactable = false;
            up2.interactable = false;
            up3.interactable = false;
            upgrade.interactable = false;
        }
        UpdateSkillsTxt();
    }
    public void Uplevel(int indx)
    {
        ppSO.skillsPoints--;
        if (indx == 0)
        {
            ppSO.speed++;
        }
        if (indx == 1)
        {
            ppSO.def++;
        }
        if (indx == 2)
        {
            ppSO.att++;
        }
        down1.interactable = true;
        down2.interactable = true;
        down3.interactable = true;
        if (ppSO.skillsPoints <= 0)
        {
            up1.interactable = false;
            up2.interactable = false;
            up3.interactable = false;
        }
        UpdateSkillsTxt();
    }
    public void DownLevel(int indx)
    {
        ppSO.skillsPoints++;
        if (indx == 0)
        {
            ppSO.speed--;
        }
        if (indx == 1)
        {
            ppSO.def--;
        }
        if (indx == 2)
        {
            ppSO.att--;
        }
        up1.interactable = true;
        up2.interactable = true;
        up3.interactable = true;
        if (ppSO.skillsPoints >= maxPoints)
        {
            down1.interactable = false;
            down2.interactable = false;
            down3.interactable = false;
        }
        UpdateSkillsTxt();
    }
    public void UpdateSkillsTxt()
    {
        speedText.text = "" + ppSO.speed;
        defText.text = "" + ppSO.def;
        attText.text = "" + ppSO.att;
        skillpoints.text = "" + ppSO.skillsPoints;
        if (ppSO.skillsPoints <= 0)
            ppSO.skillsPoints = 0;
    }
    public void UpdateToSDK()
    {
        if (ppSO.skillsPoints==0)
        {
            up1.interactable = false;
            up2.interactable = false;
            up3.interactable = false;
            upgrade.interactable = false;
        }
        
        down1.interactable = false;
        down2.interactable = false;
        down3.interactable = false;
    }
    public void Conextion()
    {
        if (txtConection.text.Equals("Disconect"))
        {
            DisconnectWallet();
            txtConection.text = "Conect";
        }
        else
        {
            SDKQuery();
            txtConection.text = "Disconect";
        }
    }
}
