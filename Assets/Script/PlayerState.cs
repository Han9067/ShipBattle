using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

    public GameObject StateMenu;
    public GameObject SkillMenu;
    public GameObject GameOver;
    public GameObject OptionMenu;
    public GameObject Achievement;
    public GameObject fire;
    public GameObject firePos;

    public Text HP_TXT;
    public Text DMG_TXT;
    public Text DEF_TXT;
    public Text ATTSPD_TXT;
    public Text MOVE_TXT;
    public Text LEVEL_TXT;
    public Text Bonus_TXT;
    public Text SkillBonus_TXT;
    public Text OverStateMessage;
    public Text EndScoreTXT;
    public Text GoldTXT;

    private AchievementToStage Ach;
    private CharacterAttribute CA;
    private PlayerControll PC;
    //스킬
    public GameObject RepairCheck;
    public GameObject SpeedupCheck;
    public GameObject RepairLV;
    public GameObject SpeedupLV;
    public GameObject RepairBtn;
    public GameObject SpeedupBtn;

    public GameObject SpeedupCoolTime;
    public GameObject RepairNotSkill;
    public GameObject SpeedupNotSkill;
    public Text RepairSkillLv_TXT;
    public Text SpeedupSkillLv_TXT;

    //public Text SpeedupCool_TXT;
    //파티클
    public ParticleSystem Repair;


    //라벤
    public TextMesh Red_Label;
    public TextMesh Green_Label;

    public int LevelBonus = 0;
    public int SkillBonus = 0;

    bool StateOn = false;
    bool SkillOn = false;
    bool RepairOn = false;
    bool SpeedupOn = false;
    bool RepairUsingOn = false; //스킬 사용후 딜레이
    bool SpeedupUsingOn = false; //스킬 사용후 딜레이

    int RepairLv = 0;
    int SpeedupLv = 0;
    int RepairHP = 0; //수리스킬로 체력을 회복시켜주는 변수
    int LVRpairHP = 2; //수리스킬이 레벨에 따라 상승하는 변수
    int LVSpeedup = 10; //스피드업스킬이 레벨에 따라 상승하는 변수

    float SpeedupcurTime = 0f;
    float SpeedupcheckTime = 0f;

    bool OptionMenuOn = false;

    void Start () {
        StateMenu.SetActive(false);
        SkillMenu.SetActive(false);
        GameOver.SetActive(false);
        OptionMenu.SetActive(false);
        Achievement.SetActive(false);

        RepairCheck.SetActive(false);
        SpeedupCheck.SetActive(false);
        RepairLV.SetActive(true);
        SpeedupLV.SetActive(true);
        RepairBtn.SetActive(false);
        SpeedupBtn.SetActive(false);

        SpeedupCoolTime.SetActive(false);
        RepairNotSkill.SetActive(false);
        SpeedupNotSkill.SetActive(false);

        fire.SetActive(true);
        fire.transform.position = new Vector3(firePos.transform.position.x
, firePos.transform.position.y - 500, firePos.transform.position.z);


        CA = gameObject.GetComponent<CharacterAttribute>();
        PC = gameObject.GetComponent<PlayerControll>();

        Time.timeScale = 1;
    }

    void Update() {

        //스테이터스 창에 표시되는 능력치들
        HP_TXT.text = CA.HPMAX.ToString();
        DMG_TXT.text = CA.AttackPower.ToString();
        DEF_TXT.text = CA.Def.ToString();
        ATTSPD_TXT.text = CA.AttDelay.ToString();
        MOVE_TXT.text = CA.MoveSpeedMAX.ToString();
        LEVEL_TXT.text = CA.Level.ToString();
        Bonus_TXT.text = LevelBonus.ToString();
        SkillBonus_TXT.text = SkillBonus.ToString();
        RepairSkillLv_TXT.text = RepairLv.ToString();
        SpeedupSkillLv_TXT.text = SpeedupLv.ToString();
        GoldTXT.text = CA.GetGold.ToString();

        if (CA.PlyerExp >= CA.MaxExp)
        {
            CA.PlyerExp -= CA.MaxExp;
            CA.Level += 1;
            CA.MaxExp *= 2;
            LevelBonus += 3;
            CA.HP = CA.HPMAX;
            Red_Label.text = "LEVEL UP!!";
            Instantiate(Red_Label, transform.position, Camera.main.transform.rotation);
            if (CA.Level % 5 == 0)
            {
                SkillBonus += 1;
            }
        }
        if(CA.HP <= CA.HPMAX/4)
        {
            fire.transform.position = new Vector3(firePos.transform.position.x
, firePos.transform.position.y, firePos.transform.position.z);
        }
        else
        {
            fire.transform.position = new Vector3(firePos.transform.position.x
, firePos.transform.position.y - 500, firePos.transform.position.z);
        }

        if (CA.HP <= 0)
        {
            CA.GameOverOn = true; //게임이 종료되었음을 알리는 변수
            Time.timeScale = 0;
            EndScoreTXT.text = CA.GetScore.ToString();
            PlayerPrefs.SetInt("EndScore", CA.GetScore); //점수저장
            PlayerPrefs.SetInt("Gold",CA.GetGold);      //골드저장


            PlayerPrefs.Save();
            GameOver.SetActive(true);
        }

        StartCoroutine(MessageDelay());
    #region 스킬에 사용할 스태미너 없을시
        if (CA.Stamina < 2)
        {
            RepairNotSkill.SetActive(true);
        }
        else
        {
            RepairNotSkill.SetActive(false);
        }

        if(CA.Stamina < 5)
        {
            SpeedupNotSkill.SetActive(true);
        }
        else
        {
            SpeedupNotSkill.SetActive(false);
        }
        #endregion
        
    }
    public void OnClick_PANELINSKILL()
    {
        StateOn = false;
        SkillOn = true;
        StateMenu.SetActive(false);
        SkillMenu.SetActive(true);
    }

    public void OnClick_PANELINSTATE()
    {
        StateOn = true;
        SkillOn = false;
        StateMenu.SetActive(true);
        SkillMenu.SetActive(false);
    }

    public void OnClick_STATE()
    {
        if(StateOn == false)
        {
            if(SkillOn == true)
            {
                SkillOn = false;
                SkillMenu.SetActive(false);
            }
            StateOn = true;
            StateMenu.SetActive(true);
        }
        else if(StateOn == true )
        {
            StateOn = false;
            StateMenu.SetActive(false);
        }
    }

    public void OnClick_SKILL()
    {
        if (SkillOn == false)
        {
            if(StateOn == true)
            {
                StateOn = false;
                StateMenu.SetActive(false);
            }
            SkillOn = true;
            SkillMenu.SetActive(true);
        }
        else if (SkillOn == true)
        {
            SkillOn = false;
            SkillMenu.SetActive(false);
        }
    }


    #region 스테이트 버튼 클릭 함수들
    public void OnClick_HP()
    {
        if(LevelBonus > 0)
        {
            CA.HPMAX += 10;
            LevelBonus -= 1;
            CA.HP = CA.HPMAX;
        }

    }

    public void OnClick_DMG()
    {
        if (LevelBonus > 0)
        {
            CA.AttackPower += 1;
            LevelBonus -= 1;
        }
    }

    public void OnClick_DEF()
    {
        if (LevelBonus > 0)
        {
            CA.Def += 1;
            LevelBonus -= 1;
        }
    }

    public void OnClick_ATTSPD()
    {
        if (LevelBonus > 0)
        {
            if (CA.AttDelay >= 0)
            {
                CA.AttDelay -= 0.2f;
                LevelBonus -= 1;
            }
            else
            {
                OverStateMessage.text = "더 이상 공격속도를 증가시킬 수 없습니다.";
            }
        }
    }

    public void OnClick_MOVE()
    {
        if (LevelBonus > 0)
        {
            CA.MoveSpeedMAX += 2;
            LevelBonus -= 1;
        }
    }

    public void OnClick_StateExit()
    {
        StateMenu.SetActive(false);
        StateOn = false;
    }

    #endregion

    public void OnClick_REPAIR()
    {
        if(SkillBonus > 0) //스킬포인트가 0이면 활성화 x
        {
            if(CA.Level >= 1) //레벨이 5이상부터 활성화
            {
                if (RepairOn == false) //스킬 활성화가 안되있다면
                {
                    RepairCheck.SetActive(true); //스킬체크 활성화
                    RepairLV.SetActive(false); //스킬 레벨제한텍스트 비활성화
                    RepairLv += 1; //스킬 레벨 상승
                    SkillBonus -= 1; //스킬 포인트 감소
                    RepairBtn.SetActive(true); //스킬 버튼 활성화
                    RepairUsingOn = true; //스킬 사용가능
                }
                if (RepairOn == true) //스킬 활성화가 되어있다면
                {
                    RepairLv += 1;
                    LVRpairHP += 2;
                    SkillBonus -= 1;
                }
            }
        }
    }

    public void OnClick_SPEEDUP()
    {
        if (SkillBonus > 0)
        {
            if(CA.Level >= 1) //레벨제한
            {
                if (SpeedupOn == false)
                {
                    SpeedupCheck.SetActive(true);
                    SpeedupLV.SetActive(false);
                    SpeedupLv += 1;
                    SkillBonus -= 1;
                    SpeedupBtn.SetActive(true);
                    SpeedupUsingOn = true;
                }
                if (SpeedupOn == true)
                {
                    SpeedupLv += 1;
                    LVSpeedup += 5;
                    SkillBonus -= 1;
                }
            }
        }
    }

    #region 스킬 버튼 클릭 함수들

    public void OnClick_REPAIRSKILL()
    {
        if(RepairUsingOn == true)//CA.Stamina > 2
        {
            if(CA.Stamina >= 2)
            {
                //스킬 가능 활성화

                CA.Stamina -= 2;
                Instantiate(Repair, this.transform.position, this.transform.rotation);
                if (CA.HP <= CA.HPMAX)
                {
                    RepairHP = LVRpairHP;
                    if (CA.HP >= CA.HPMAX - RepairHP)
                    {
                        RepairHP = CA.HPMAX - CA.HP;
                    }
                    CA.HP += RepairHP;
                    if (CA.HP >= CA.HPMAX)
                    {
                        CA.HP = CA.HPMAX;
                    }
                    Red_Label.text = "+" + RepairHP.ToString();
                    Instantiate(Red_Label, transform.position, Camera.main.transform.rotation);
                    RepairHP = LVRpairHP;
                }
            }
        }
    }

    public void OnClick_SPEEDUPSKILL()
    {
        if(SpeedupUsingOn == true)
        {
            if(CA.Stamina >= 5)
            {
                //스킬 가능 활성화

                CA.Stamina -= 5;
                Instantiate(Repair, this.transform.position, this.transform.rotation);
                CA.MoveSpeedMAX += LVSpeedup;
                PC.MoveSpeed = CA.MoveSpeedMAX;
                SpeedupUsingOn = false;
                Green_Label.text = "+" + LVSpeedup.ToString();
                Instantiate(Green_Label, transform.position, Camera.main.transform.rotation);
                SpeedupCoolTime.SetActive(true);
                StartCoroutine(SpeedupDelay());
            }
        }
    }

    public void OnClick_SkillExit()
    {
        SkillMenu.SetActive(false);
        SkillOn = false;
    }
    #endregion

    #region 옵션 메뉴 함수들

    public void OnClick_Option()
    {
        if(OptionMenuOn == false)
        {
            OptionMenu.SetActive(true);
            OptionMenuOn = true;
        }
        else if(OptionMenuOn == true)
        {
            OptionMenu.SetActive(false);
            OptionMenuOn = false;
        }
    }

    public void OnClick_GoToGame()
    {
        OptionMenu.SetActive(false);
        OptionMenuOn = false;
    }

    public void OnClick_GoToAch()
    {
        Achievement.SetActive(true);
        OptionMenu.SetActive(false);
        OptionMenuOn = false;
    }

    public void OnClick_GoToShop()
    {
        OptionMenu.SetActive(false);
        OptionMenuOn = false;
    }

    public void OnClick_GoToMainMenu()
    {
        OptionMenu.SetActive(false);
        OptionMenuOn = false;
        PlayerPrefs.SetInt("EndScore", CA.GetScore); //점수저장
        PlayerPrefs.SetInt("Gold", CA.GetGold);      //골드저장
        PlayerPrefs.Save();
        Application.LoadLevel("MainMenu");
    }

    public void OnClick_GoToHome()
    {
        OptionMenu.SetActive(false);
        OptionMenuOn = false;
        PlayerPrefs.SetInt("EndScore", CA.GetScore); //점수저장
        PlayerPrefs.SetInt("Gold", CA.GetGold);      //골드저장

        PlayerPrefs.Save();
        Application.Quit();
    }

    public void Ach_Exit()
    {
        Achievement.SetActive(false);
    }

    #endregion



    //이너머레이터 구간
    IEnumerator MessageDelay()
    {
        yield return new WaitForSeconds(1f);
        
        OverStateMessage.text = "";
    }

    IEnumerator SpeedupDelay()
    {
        yield return new WaitForSeconds(5f);

        CA.MoveSpeedMAX -= LVSpeedup;
        if(PC.MoveSpeed > CA.MoveSpeedMAX)
        {
            PC.MoveSpeed = CA.MoveSpeedMAX;
        }
        SpeedupUsingOn = true;
        SpeedupCoolTime.SetActive(false);
    }


    public void GotoMain()
    {
        Application.LoadLevel("MainMenu");
    }
}
