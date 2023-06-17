using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text speedText;
    public TMP_Text defText;
    public TMP_Text attText;
    public TMP_Text lifeText;
    public Image lifeImg;
    public int vida;

    public PlayerProfileSO ppSO;

    private void Start()
    {
       speedText.text=""+ppSO.speed;
       defText.text=""+ppSO.def;
       attText.text=""+ppSO.att;
       ppSO.life=100;
       lifeImg.fillAmount=1;
    }
    public void UpdateLife(){
        lifeText.text= ""+ ppSO.life;
        lifeImg.fillAmount=(float)ppSO.life/100;
    }
}
