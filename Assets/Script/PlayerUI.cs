using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Slider HPBar;
    public Slider StaminaBar;
    public Slider EXPBar;
    public Text HP;
    public Text HPMAX;
    public Text Stamina;
    public Text StaminaMax;
    public Text EXP;
    public Text EXPMAX;

    float curTime = 0f;
    float checkTime = 0f;

    private CharacterAttribute attribute;

    void Start()
    {
        attribute = gameObject.GetComponent<CharacterAttribute>();
        checkTime = 3.0f; //스테미나 리젠 시간
    }
    void Update()
    {
        curTime += Time.deltaTime;
        //
        HPBar.value = (float)attribute.HP / (float)attribute.HPMAX;
        StaminaBar.value = (float)attribute.Stamina / (float)attribute.StaminaMax;
        EXPBar.value = (float)attribute.PlyerExp / (float)attribute.MaxExp;
        HP.text = attribute.HP.ToString();
        HP.text = attribute.HP.ToString();
        HPMAX.text = attribute.HPMAX.ToString();
        Stamina.text = attribute.Stamina.ToString();
        StaminaMax.text = attribute.StaminaMax.ToString();
        EXP.text = attribute.PlyerExp.ToString();
        EXPMAX.text = attribute.MaxExp.ToString();

        if(curTime > checkTime) //스태미나 리젠
        {
            if(attribute.Stamina < attribute.StaminaMax)
            {
                attribute.Stamina += 1;
            }
            curTime = 0;
        }
    }

}
