using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Action : MonoBehaviour {

    GameObject player;
    GameObject Obj;
    AchievementToStage Ach;
    CharacterAttribute EnemeyCA;
    CharacterAttribute PlayerCA;
    ObjectManager ObjMgr;

    bool EnemyDestoyOn = false;
    public bool ObjDetection = false;
    public float EnemySpeed = 40;
    int RotSpeed = 35;
    float Walk = 0f;
    Vector3 Waypoints;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Obj = GameObject.FindGameObjectWithTag("Object");
        ObjMgr = Obj.GetComponent<ObjectManager>();
        Ach = player.GetComponent<AchievementToStage>();

        Waypoints = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
        Walk = EnemySpeed * Time.deltaTime;
    }

    void Update()
    {
        PlayerCA = player.GetComponent<CharacterAttribute>();
        EnemeyCA = gameObject.GetComponent<CharacterAttribute>();

        MOVE();

        if (EnemeyCA.HP <= 0) //에너미의 체력이 0이 되었을때
        {
            if (EnemyDestoyOn == false)
            {
                PlayerCA.PlyerExp += EnemeyCA.EnemyExp;
                PlayerCA.GetScore += EnemeyCA.EnemyExp * 5;
                EnemyDestoyOn = true;
                Ach.KillMiddleBossNum += 1;
            }
            StartCoroutine(EnemyDeath());
            GameObject.Destroy(this.gameObject, 2);
        }

        if (ObjDetection == true)//후에 AI 개선해야함
        {
            Waypoints = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
            ObjDetection = false;
        }
    }

    void MOVE()
    {
        ////rotation and move
        Quaternion targetRot = Quaternion.LookRotation(Waypoints - transform.position);
        Quaternion frameRot = Quaternion.RotateTowards(transform.rotation,
           targetRot, RotSpeed * Time.deltaTime);
        transform.rotation = frameRot;
        //transform.position = Vector3.MoveTowards(transform.position, Waypoints, move);
        transform.position += transform.forward * EnemySpeed * Time.deltaTime;
        if (Vector3.Distance(Waypoints, transform.position) <= 50f)//목표지점 가기전에 미리 좌표를 변경
        {
            Waypoints = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
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
            this.transform.position = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
        }
        if (other.gameObject.tag.Equals("Player"))//후에 개선
        {

        }
    }
}
