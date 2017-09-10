using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementToStage : MonoBehaviour {

    GameObject Player;
    CharacterAttribute CA;

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

    public int KillEnemyNum = 0;
    public int KillMiddleBossNum = 0;
    public int KillNamedBossNum = 0;
    int OverScore = 0;

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

    int AchOnOff = 0; //로드시 업적을 이미 달성한 과제들을 활성화 시키게 해주는 변수

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        CA = Player.GetComponent<CharacterAttribute>();

        LoadAch();



    }

    void Update() {
        OverScore = CA.GetScore;

        KillEnemyAch();
        KillMBAch();
        KillNBAch();

        ScoreAch();

        if(CA.GameOverOn == true)
        {
            PlayerPrefs.SetInt("KillEnemyNum", KillEnemyNum);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("KillMiddleBossNum", KillMiddleBossNum);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("KillNamedBossNum", KillNamedBossNum);
            PlayerPrefs.Save();
        }
    }

    void LoadAch()
    {
        KillEnemyNum = PlayerPrefs.GetInt("KillEnemyNum");
        KillMiddleBossNum = PlayerPrefs.GetInt("KillMiddleBossNum");
        KillNamedBossNum = PlayerPrefs.GetInt("KillNamedBossNum");

        AchOnOff = PlayerPrefs.GetInt("killenemy1");
        if(AchOnOff == 1)
        {
            ACH_Cur1.text = "1";
            ACH_Panel1.SetActive(false);
            killenemy1 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killenemy10");
        if (AchOnOff == 1)
        {
            ACH_Cur2.text = "10";
            ACH_Panel2.SetActive(false);
            killenemy10 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killenemy100");
        if (AchOnOff == 1)
        {
            ACH_Cur3.text = "100";
            ACH_Panel3.SetActive(false);
            killenemy100 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killenemy1000");
        if (AchOnOff == 1)
        {
            ACH_Cur4.text = "1000";
            ACH_Panel4.SetActive(false);
            killenemy1000 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killMB1");
        if (AchOnOff == 1)
        {
            ACH_Cur5.text = "1";
            ACH_Panel5.SetActive(false);
            killMB1 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killMB5");
        if (AchOnOff == 1)
        {
            ACH_Cur6.text = "5";
            ACH_Panel6.SetActive(false);
            killMB5 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killMB20");
        if (AchOnOff == 1)
        {
            ACH_Cur7.text = "20";
            ACH_Panel7.SetActive(false);
            killMB20 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killNB1");
        if (AchOnOff == 1)
        {
            ACH_Cur8.text = "1";
            ACH_Panel8.SetActive(false);
            killNB1 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("killNB4");
        if (AchOnOff == 1)
        {
            ACH_Cur9.text = "4";
            ACH_Panel9.SetActive(false);
            killNB4 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("OverScore100");
        if (AchOnOff == 1)
        {
            ACH_Cur10.text = "100";
            ACH_Panel10.SetActive(false);
            OverScore100 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("OverScore2500");
        if (AchOnOff == 1)
        {
            ACH_Cur11.text = "2500";
            ACH_Panel11.SetActive(false);
            OverScore2500 = true;
            AchOnOff = 0;
        }
        AchOnOff = PlayerPrefs.GetInt("OverScore10000");
        if (AchOnOff == 1)
        {
            ACH_Cur12.text = "10000";
            ACH_Panel12.SetActive(false);
            OverScore10000 = true;
            AchOnOff = 0;
        }
    } //업적 로드

    void KillEnemyAch()
    {
        if (killenemy1 == false)
        {
            ACH_Cur1.text = KillEnemyNum.ToString(); //업적창에 표시되는 현재 업적 숫자
            if (KillEnemyNum >= 1)
            {
                ACH_Panel1.SetActive(false);
                killenemy1 = true;
                CA.GetGold += 1;
                PlayerPrefs.SetInt("killenemy1", 1);
                PlayerPrefs.Save();
            }
        }
        if (killenemy10 == false)
        {
            ACH_Cur2.text = KillEnemyNum.ToString();
            if (KillEnemyNum >= 10)
            {
                ACH_Panel2.SetActive(false);
                killenemy10 = true;
                CA.GetGold += 3;
                PlayerPrefs.SetInt("killenemy10", 1);
                PlayerPrefs.Save();
            }
        }
        if (killenemy100 == false)
        {
            ACH_Cur3.text = KillEnemyNum.ToString();
            if (KillEnemyNum >= 100)
            {
                ACH_Panel3.SetActive(false);
                killenemy100 = true;
                CA.GetGold += 20;
                PlayerPrefs.SetInt("killenemy100", 1);
                PlayerPrefs.Save();
            }
        }
        if (killenemy1000 == false)
        {
            ACH_Cur4.text = KillEnemyNum.ToString();
            if (KillEnemyNum >= 1000)
            {
                ACH_Panel4.SetActive(false);
                killenemy1000 = true;
                CA.GetGold += 100;
                PlayerPrefs.SetInt("killenemy1000", 1);
                PlayerPrefs.Save();
            }
        }
    }

    void KillMBAch()
    {
        if (killMB1 == false)
        {
            ACH_Cur5.text = KillMiddleBossNum.ToString();
            if (KillMiddleBossNum >= 1)
            {
                ACH_Panel5.SetActive(false);
                killMB1 = true;
                CA.GetGold += 8;
                PlayerPrefs.SetInt("killMB1", 1);
                PlayerPrefs.Save();
            }
        }
        if (killMB5 == false)
        {
            ACH_Cur6.text = KillMiddleBossNum.ToString();
            if (KillMiddleBossNum >= 5)
            {
                ACH_Panel6.SetActive(false);
                killMB5 = true;
                CA.GetGold += 50;
                PlayerPrefs.SetInt("killMB5", 1);
                PlayerPrefs.Save();
            }
        }
        if (killMB20 == false)
        {
            ACH_Cur7.text = KillMiddleBossNum.ToString();
            if (KillMiddleBossNum >= 20)
            {
                ACH_Panel7.SetActive(false);
                killMB20 = true;
                CA.GetGold += 200;
                PlayerPrefs.SetInt("killMB20", 1);
                PlayerPrefs.Save();
            }
        }
    }

    void KillNBAch()
    {
        if (killNB1 == false)
        {
            ACH_Cur8.text = KillNamedBossNum.ToString();
            if (KillNamedBossNum >= 1)
            {
                ACH_Panel8.SetActive(false);
                killNB1 = true;
                CA.GetGold += 50;
                PlayerPrefs.SetInt("killNB1", 1);
                PlayerPrefs.Save();
            }
        }

        if (killNB4 == false)
        {
            ACH_Cur9.text = KillNamedBossNum.ToString();
            if (KillNamedBossNum >= 4)
            {
                ACH_Panel8.SetActive(false);
                killNB4 = true;
                CA.GetGold += 300;
                PlayerPrefs.SetInt("killNB4", 1);
                PlayerPrefs.Save();
            }
        }
    }

    void ScoreAch()
    {
        if(OverScore100 == false)
        {
            ACH_Cur10.text = OverScore.ToString();
            if (OverScore >= 100)
            {
                ACH_Panel10.SetActive(false);
                OverScore100 = true;
                CA.GetGold += 1;
                PlayerPrefs.SetInt("OverScore100", 1);
                PlayerPrefs.Save();
            }
        }
        if (OverScore2500 == false)
        {
            ACH_Cur11.text = OverScore.ToString();
            if (OverScore >= 2500)
            {
                ACH_Panel11.SetActive(false);
                OverScore2500 = true;
                CA.GetGold += 30;
                PlayerPrefs.SetInt("OverScore2500", 1);
                PlayerPrefs.Save();
            }
        }
        if (OverScore10000 == false)
        {
            ACH_Cur12.text = OverScore.ToString();
            if (OverScore >= 10000)
            {
                ACH_Panel12.SetActive(false);
                OverScore10000 = true;
                CA.GetGold += 150;
                PlayerPrefs.SetInt("OverScore10000", 1);
                PlayerPrefs.Save();
            }
        }
    }
}
