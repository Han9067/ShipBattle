using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    public GameObject GameExplan;
    public GameObject KeyExplan;
    public GameObject Achievement;
    public GameObject Shop;
    public GameObject Clear;

    public Text BestScore_TXT;
    public Text Gold_TXT;
    public Text SHOPGold_TXT;
    //
    public GameObject ACH_Panel1;
    public GameObject ACH_Panel2;
    public GameObject ACH_Panel3;
    public GameObject ACH_Panel4;
    public GameObject ACH_Panel5;
    public GameObject ACH_Panel6;
    public GameObject ACH_Panel7;
    public GameObject ACH_Panel8;
    public GameObject ACH_Panel9;
    public GameObject ACH_Panel10;
    public GameObject ACH_Panel11;
    public GameObject ACH_Panel12;

    public Text ACH_Cur1;
    public Text ACH_Cur2;
    public Text ACH_Cur3;
    public Text ACH_Cur4;
    public Text ACH_Cur5;
    public Text ACH_Cur6;
    public Text ACH_Cur7;
    public Text ACH_Cur8;
    public Text ACH_Cur9;
    public Text ACH_Cur10;
    public Text ACH_Cur11;
    public Text ACH_Cur12;

    int iGetScore = 0;
    int iGetGold = 0;
    int iBestScore = 0;
    //
    int KillEnemyNum = 0;
    int KillMiddleBossNum = 0;
    int KillNamedBossNum = 0;

    bool killenemy1 = false;
    bool killenemy10 = false;
    bool killenemy100 = false;
    bool killenemy1000 = false;

    bool killMB1 = false;
    bool killMB5 = false;
    bool killMB20 = false;

    bool killNB1 = false;
    bool killNB4 = false;

    bool OverScore100 = false;
    bool OverScore2500 = false;
    bool OverScore10000 = false;

    int AchOnOff = 0;

    void Start()
    {
        GameExplan.SetActive(false);
        KeyExplan.SetActive(false);
        Achievement.SetActive(false);
        Shop.SetActive(false);

        Clear.SetActive(true);//기록 초기화

        iGetScore = PlayerPrefs.GetInt("EndScore");
        iGetGold = PlayerPrefs.GetInt("Gold");

        if (iGetScore >= iBestScore)
        {
            iBestScore = iGetScore;
            BestScore_TXT.text = iBestScore.ToString();
        }

        LoadAch();

    }

    void Update()
    {
        Gold_TXT.text = iGetGold.ToString();

    }

    void LoadAch()
    {
        KillEnemyNum = PlayerPrefs.GetInt("KillEnemyNum");
        KillMiddleBossNum = PlayerPrefs.GetInt("KillMiddleBossNum");
        KillNamedBossNum = PlayerPrefs.GetInt("KillNamedBossNum");

        AchOnOff = PlayerPrefs.GetInt("killenemy1");
        if (AchOnOff == 1)
        {
            ACH_Cur1.text = "1";
            ACH_Panel1.SetActive(false);
            killenemy1 = true;
            AchOnOff = 0;
        }
        else
        {
            ACH_Panel1.SetActive(true);
        }
        AchOnOff = PlayerPrefs.GetInt("killenemy10");
        if (AchOnOff == 1)
        {
            ACH_Cur2.text = "10";
            ACH_Panel2.SetActive(false);
            killenemy10 = true;
            AchOnOff = 0;
        }
        else
        {
            ACH_Panel2.SetActive(true);
            ACH_Cur2.text = KillEnemyNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("killenemy100");
        if (AchOnOff == 1)
        {
            ACH_Cur3.text = "100";
            ACH_Panel3.SetActive(false);
            killenemy100 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel3.SetActive(true);
            ACH_Cur3.text = KillEnemyNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("killenemy1000");
        if (AchOnOff == 1)
        {
            ACH_Cur4.text = "1000";
            ACH_Panel4.SetActive(false);
            killenemy1000 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel4.SetActive(true);
            ACH_Cur4.text = KillEnemyNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("killMB1");
        if (AchOnOff == 1)
        {
            ACH_Cur5.text = "1";
            ACH_Panel5.SetActive(false);
            killMB1 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel5.SetActive(true);
            ACH_Cur5.text = KillMiddleBossNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("killMB5");
        if (AchOnOff == 1)
        {
            ACH_Cur6.text = "5";
            ACH_Panel6.SetActive(false);
            killMB5 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel6.SetActive(true);
            ACH_Cur6.text = KillMiddleBossNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("killMB20");
        if (AchOnOff == 1)
        {
            ACH_Cur7.text = "20";
            ACH_Panel7.SetActive(false);
            killMB20 = true;
            AchOnOff = 0;
            ACH_Cur7.text = KillMiddleBossNum.ToString();
        }
        {
            ACH_Panel7.SetActive(true);
        }
        AchOnOff = PlayerPrefs.GetInt("killNB1");
        if (AchOnOff == 1)
        {
            ACH_Cur8.text = "1";
            ACH_Panel8.SetActive(false);
            killNB1 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel8.SetActive(true);
            ACH_Cur8.text = KillNamedBossNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("killNB4");
        if (AchOnOff == 1)
        {
            ACH_Cur9.text = "4";
            ACH_Panel9.SetActive(false);
            killNB4 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel9.SetActive(true);
            ACH_Cur9.text = KillNamedBossNum.ToString();
        }
        AchOnOff = PlayerPrefs.GetInt("OverScore100");
        if (AchOnOff == 1)
        {
            ACH_Cur10.text = "100";
            ACH_Panel10.SetActive(false);
            OverScore100 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel10.SetActive(true);
        }
        AchOnOff = PlayerPrefs.GetInt("OverScore2500");
        if (AchOnOff == 1)
        {
            ACH_Cur11.text = "2500";
            ACH_Panel11.SetActive(false);
            OverScore2500 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel11.SetActive(true);
        }
        AchOnOff = PlayerPrefs.GetInt("OverScore10000");
        if (AchOnOff == 1)
        {
            ACH_Cur12.text = "10000";
            ACH_Panel12.SetActive(false);
            OverScore10000 = true;
            AchOnOff = 0;
        }
        {
            ACH_Panel12.SetActive(true);
        }
    }

    public void AchClear()
    {
        iBestScore = 0;
        iGetGold = 0;
        BestScore_TXT.text = iBestScore.ToString();
        PlayerPrefs.DeleteAll();
    }

    #region 메인메뉴 버튼함수들

    public void StartBtn()
    {
        Application.LoadLevel("Stage");
    }

    public void GameExplantion()
    {
        GameExplan.SetActive(true);
    }

    public void KeyExplantion()
    {
        KeyExplan.SetActive(true);
    }

    public void AchievementOn()
    {
        Achievement.SetActive(true);
    }

    public void GE_exit()
    {
        GameExplan.SetActive(false);
    }

    public void KE_exit()
    {
        KeyExplan.SetActive(false);
    }

    public void AchievementOff()
    {
        Achievement.SetActive(false);
    }

    public void SHOP_Open()
    {
        Shop.SetActive(true);
    }

    public void SHOP_exit()
    {
        Shop.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    #endregion
}
