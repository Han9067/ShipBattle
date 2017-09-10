using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControll : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject R_BulletPosition;
    public GameObject L_BulletPosition;
    public GameObject R_AttackLine;
    public GameObject L_AttackLine;
    public GameObject waterwake;
    public GameObject waterwake2;
    public GameObject waterwakepos;

    public Text PlayerMove;
    public Text Bullet_Position;
    public Text Bullet_Loading;
    public Text Score;

    private CharacterAttribute CA;

    public float MoveSpeed = 0.0f; //이동속도
    float Acceleration = 2.0f; //가속도
    float R_Spin = 50.0f;     //오른쪽 회전속도
    float L_Spin = -50.0f;   //왼쪽 회전속도
    public string BulletPos = "";
    bool KeyPressOn = true;
    //bool BulletPosOn = true;

    bool MoveForwadOn = false;
    bool MoveBackOn = false;
    bool RotRightOn = false;
    bool RotLeftOn = false;

    void Start()
    {
        Screen.SetResolution(Screen.width, (Screen.width / 16) * 9, false);
        R_AttackLine.SetActive(false);
        L_AttackLine.SetActive(false);
        waterwake.SetActive(true);
        waterwake2.SetActive(true);
        CA = gameObject.GetComponent<CharacterAttribute>();
    }
    void Update()
    {
        PKey();
        PlayerMove.text = MoveSpeed.ToString("0");
        Score.text = CA.GetScore.ToString();
        transform.Translate(0f, 0f, MoveSpeed * Time.deltaTime);
        WaterWake();

        #region 동작들
        if (MoveForwadOn)
        {
            MoveSpeed += Acceleration;
            if (MoveSpeed >= CA.MoveSpeedMAX)
            {
                MoveSpeed = CA.MoveSpeedMAX;
            }
        }
        if (MoveBackOn)
        {
            MoveSpeed -= Acceleration / 5;
            if (MoveSpeed <= 0)
            {
                MoveSpeed = 0;
            }
        }
        if (RotRightOn)
        {
            transform.Rotate(0f, 1f * R_Spin * Time.deltaTime, 0f);
        }
        if (RotLeftOn)
        {
            transform.Rotate(0f, -1f * R_Spin * Time.deltaTime, 0f);
        }

        #endregion

    }

    void PKey()
    {
        //float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            MoveSpeed += Acceleration;
            if (MoveSpeed >= CA.MoveSpeedMAX)
            {
                MoveSpeed = CA.MoveSpeedMAX;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveSpeed -= Acceleration / 5;
            if (MoveSpeed <= 0)
            {
                MoveSpeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -h * L_Spin * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, h * R_Spin * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            BulletPos = "R";
            Bullet_Position.text = BulletPos;
            R_AttackLine.SetActive(true);
            L_AttackLine.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            BulletPos = "L";
            Bullet_Position.text = BulletPos;
            R_AttackLine.SetActive(false);
            L_AttackLine.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if(Bullet_Position.text == "R" || Bullet_Position.text == "L")
            {
                if (KeyPressOn == true)
                {
                    KeyPressOn = false;
                    Bullet_Loading.text = "사격 준비";
                    if (Bullet_Position.text == "R")
                    {
                        Instantiate(Bullet, R_BulletPosition.transform.position, transform.rotation);
                        StartCoroutine(AttackDelay(Bullet));//변수 AttDelay 만큼 포탄 발사 비활성
                        SoundManager.instance.ShotSound();
                        //StartCoroutine(R_Glide(Bullet));//반동
                    }
                    if (Bullet_Position.text == "L")
                    {
                        Instantiate(Bullet, L_BulletPosition.transform.position, transform.rotation);
                        StartCoroutine(AttackDelay(Bullet));
                        SoundManager.instance.ShotSound();
                        //StartCoroutine(L_Glide(Bullet));//반동
                    }
                }
            }

        }
    }

    #region UI터치 함수들
    public void OnPointerDown_Foward()
    {
        MoveForwadOn = true;
    }
    public void OnPointerUp_Foward()
    {
        MoveForwadOn = false;
    }
    //////////////////////////////
    public void OnPointerDown_Back()
    {
        MoveBackOn = true;
    }
    public void OnPointerUp_Back()
    {
        MoveBackOn = false;
    }
    //////////////////////////////
    public void OnPointerDown_Right()
    {
        RotRightOn = true;
    }
    public void OnPointerUp_Right()
    {
        RotRightOn = false;
    }
    //////////////////////////////
    public void OnPointerDown_Left()
    {
        RotLeftOn = true;
    }
    public void OnPointerUp_Left()
    {
        RotLeftOn = false;
    }
    //////////////////////////////
    public void OnClick_Shotbtn()
    {
        if (KeyPressOn == true)
        {
            KeyPressOn = false;
            Bullet_Loading.text = "사격 준비";
            if (BulletPos == "R")
            {
                Instantiate(Bullet, R_BulletPosition.transform.position, transform.rotation);
                StartCoroutine(AttackDelay(Bullet));//변수 AttDelay 만큼 포탄 발사 비활성
                SoundManager.instance.ShotSound();
            }
            if (BulletPos == "L")
            {
                Instantiate(Bullet, L_BulletPosition.transform.position, transform.rotation);
                StartCoroutine(AttackDelay(Bullet));
                SoundManager.instance.ShotSound();
            }
        }
    }
    public void OnPointerDown_RBullet()
    {
        BulletPos = "R";
        Bullet_Position.text = BulletPos;
        R_AttackLine.SetActive(true);
        L_AttackLine.SetActive(false);
    }
    public void OnPointerDown_LBullet()
    {
        BulletPos = "L";
        Bullet_Position.text = BulletPos;
        R_AttackLine.SetActive(false);
        L_AttackLine.SetActive(true);
    }
    #endregion


    void WaterWake()
    {
        if (MoveSpeed <= 0)
        {
            waterwake.transform.position = new Vector3(waterwakepos.transform.position.x
            , waterwakepos.transform.position.y - 1.0f, waterwakepos.transform.position.z);
            waterwake2.transform.position = new Vector3(waterwakepos.transform.position.x
            , waterwakepos.transform.position.y - 5.0f, waterwakepos.transform.position.z);
        }
        if (MoveSpeed >= 1 && MoveSpeed <= 30)
        {
            waterwake.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 0.4f, waterwakepos.transform.position.z);
            waterwake2.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 1.0f, waterwakepos.transform.position.z);
        }
        if (MoveSpeed >= 31 && MoveSpeed <= 50)
        {
            waterwake.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 0.3f, waterwakepos.transform.position.z);
            waterwake2.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 0.0f, waterwakepos.transform.position.z);
        }
        if (MoveSpeed >= 51 && MoveSpeed <= 80)
        {
            waterwake.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 0.2f, waterwakepos.transform.position.z);
            waterwake2.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 0.0f, waterwakepos.transform.position.z);
        }
        if (MoveSpeed >= 81)
        {
            waterwake.transform.position = new Vector3(waterwakepos.transform.position.x
                , waterwakepos.transform.position.y - 0.1f, waterwakepos.transform.position.z);
            waterwake2.transform.position = new Vector3(waterwakepos.transform.position.x
            , waterwakepos.transform.position.y - 0.0f, waterwakepos.transform.position.z);
        }
    }

#region 반동함수
    //어느 게임에서도 포탄으로 인한 반동이 존재하지 않아 제외시킴
    IEnumerator R_Glide(GameObject Bullet) 
    {
        float GlideSpeed = 5;

        while(GlideSpeed > 0)
        {
            GlideSpeed -= 10 * Time.deltaTime;

            transform.Translate(-Vector3.right * GlideSpeed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator L_Glide(GameObject Bullet)
    {
        float GlideSpeed = 5;

        while (GlideSpeed > 0)
        {
            GlideSpeed -= 10 * Time.deltaTime;

            transform.Translate(Vector3.right * GlideSpeed * Time.deltaTime);
            yield return null;
        }
    }
    #endregion
    IEnumerator AttackDelay(GameObject Bullet)
    {
        yield return new WaitForSeconds(CA.AttDelay);

        KeyPressOn = true;
        Bullet_Loading.text = "사격 가능";
    }




}
