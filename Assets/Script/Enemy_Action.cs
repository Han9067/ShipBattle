using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Action : MonoBehaviour {

    GameObject player;
    GameObject Obj;
    AchievementToStage Ach;
    CharacterAttribute EnemeyCA;
    CharacterAttribute PlayerCA;
    ObjectManager ObjMgr;

    public GameObject fire;
    public GameObject firePos;

    //public ParticleSystem BeDamaged;
    //public GameObject DamagePos;

    bool EnemyDestoyOn = false;
    public bool ObjDetection = false;
    public float EnemySpeed = 30;
    int RotSpeed = 25;
    float Walk = 0f;
    Vector3 Waypoints;

    void Start()
    {
        Obj = GameObject.FindGameObjectWithTag("Object");
        player = GameObject.FindGameObjectWithTag("Player");
        ObjMgr = Obj.GetComponent<ObjectManager>();
        Ach = player.GetComponent<AchievementToStage>();

        Waypoints = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
        Walk = EnemySpeed * Time.deltaTime;

        fire.SetActive(true);
        fire.transform.position = new Vector3(firePos.transform.position.x
, firePos.transform.position.y - 500, firePos.transform.position.z);
    }

    void Update()
    {
        PlayerCA = player.GetComponent<CharacterAttribute>();
        EnemeyCA = gameObject.GetComponent<CharacterAttribute>();

        MOVE();

        if (EnemeyCA.HP <= EnemeyCA.HPMAX / 4)
        {
            fire.transform.position = new Vector3(firePos.transform.position.x
, firePos.transform.position.y, firePos.transform.position.z);
        }
        else
        {
            fire.transform.position = new Vector3(firePos.transform.position.x
, firePos.transform.position.y - 500, firePos.transform.position.z);
        }

        if (EnemeyCA.HP <= 0) //에너미의 체력이 0이 되었을때
        {
            if(EnemyDestoyOn == false)
            {
                PlayerCA.PlyerExp += EnemeyCA.EnemyExp;
                PlayerCA.GetScore += EnemeyCA.EnemyExp * 5;
                EnemyDestoyOn = true;
                ObjMgr.EnemyCount -= 1;
                Ach.KillEnemyNum += 1; 
            }
            StartCoroutine(EnemyDeath());
            GameObject.Destroy(this.gameObject, 2);
        }

        if(ObjDetection == true)//후에 AI 개선해야함
        {
            Waypoints = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
            ObjDetection = false;
        }
    }

    void MOVE()
    {
        ////rotation and move
        Quaternion targetRot = Quaternion.LookRotation(Waypoints
            - transform.position); //타겟 방향으로 회전되도록 계산
        Quaternion frameRot = Quaternion.RotateTowards(transform.rotation,
           targetRot, RotSpeed * Time.deltaTime);//현재위치,타겟의 방향, 회전속도
                                        //지정된 타겟의 거리에 따라 가장 가까운방향으로 회전하도록 계산
        transform.rotation = frameRot; //계산된 회전을 오브젝트에게 적용
        //transform.position = Vector3.MoveTowards(transform.position, Waypoints, move);
        transform.position += transform.forward * EnemySpeed * Time.deltaTime; //목표지점으로 이동
        if (Vector3.Distance(Waypoints, transform.position) <= 50f)//목표지점 가기전에 미리 좌표를 변경
        {
            //Waypoints = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));

            Waypoints = new Vector3(transform.position.x + Random.Range(-500, 500),
                5f, transform.position.z + Random.Range(-500, 500));
            //웨이포인트는 생성된 오브젝트가 이동해야하는 목표 if에서 나와있듯이 목표지점에 일정거리에 도착하면
            //목표지점을 랜덤으로 변경한다.
        }
        /////
    }

    IEnumerator EnemyDeath()
    {
        float DownSpeed = 10;

        while (DownSpeed > 0)
        {
            transform.Translate(Vector3.down * DownSpeed * Time.deltaTime);
            DownSpeed -= 1;
            yield return null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Terrain"))
        {
            //GameObject.Destroy(this.gameObject);
            Waypoints = new Vector3(transform.position.x + Random.Range(-500, 500), 5f, transform.position.z + Random.Range(-500, 500));
        }
        if (other.gameObject.tag.Equals("Player"))//후에 개선
        {
            //GameObject.Destroy(this.gameObject);
            //print("hey!!");
            //this.transform.position = new Vector3(Random.Range(-900, 900), 0, Random.Range(-900, 900));
        }
    }
}
