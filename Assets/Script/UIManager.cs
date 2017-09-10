using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject HudUIRoot;
    public Slider HPBarPrefab;
    public Slider MBHPBarPrefab;
    public GameObject Static_Canvas;
    //싱글톤패턴
    private static UIManager instance_ = null;
    public static UIManager instance
    {
        get
        {
            return instance_;
        }
        private set { }
    }

    public void Awake()
    {
        instance_ = this;
        Static_Canvas.SetActive(true);
    }

    public void SetHpBar(GameObject actor)
    {
        CharacterUI CU = actor.GetComponent<CharacterUI>();
        GameObject newHpBar = ObjectManager.CreateENEMY(HudUIRoot, HPBarPrefab.gameObject);

        if (CU != null)
        {
            CU.HPBar = newHpBar.GetComponent<Slider>();
        }           
    }

    public void SetMBHpBar(GameObject actor)
    {
        CharacterUI CU = actor.GetComponent<CharacterUI>();
        GameObject newHpBar = ObjectManager.CreateENEMY(HudUIRoot, MBHPBarPrefab.gameObject);

        if (CU != null)
        {
            CU.HPBar = newHpBar.GetComponent<Slider>();
        }
    }

    public void AddDMGText(GameObject actor, int damage)
    {
        CharacterUI CU = actor.GetComponent<CharacterUI>();
       

    }
}
