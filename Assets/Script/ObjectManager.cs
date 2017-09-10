using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public GameObject enemy_red;
    public GameObject enemy_blue;
    public GameObject enemy_green;
    public GameObject MiddleBoss;

    public GameObject item1Prefab;
    private static ObjectManager instance;

    public int EnemyCount = 1;
    public int ItemCount = 1;
    public int MiddleBossCount = 1;
    public enum ObjectType
    {
        MiddleBoss,
        Enemy,
        Item,
    }

    Dictionary<ObjectType, List<GameObject>> objectLists =
        new Dictionary<ObjectType, List<GameObject>>();
    public void AddObject(ObjectType objType, GameObject obj)
    {
        if (!objectLists.ContainsKey(objType))
        {
            objectLists[objType] = new List<GameObject>();
        }

        if (!objectLists[objType].Contains(obj))
        {
            objectLists[objType].Add(obj);
        }
    }

    public void RemoveObject(ObjectType objType, GameObject obj)
    {
        if (objectLists[objType].Contains(obj))
        {
            objectLists[objType].Remove(obj);
        }
    }

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //스폰
        InvokeRepeating("CreateEnemy", 1f, 1f * (Random.Range(7, 10) / 10f));
        InvokeRepeating("CreateItem", 1f, 20f * (Random.Range(7, 10) / 10f));
        InvokeRepeating("CreateMiddleBoss", 1f, 60f * (Random.Range(7, 10) / 10f));

    }

    public static GameObject CreateENEMY(GameObject parent, GameObject prefab)
    {
        GameObject go = GameObject.Instantiate(prefab) as GameObject;
        if (go != null && parent != null)
        {
            Transform t = go.transform;
            //t.parent = parent.transform; //부모 설정
            t.SetParent(parent.transform); // SetParent는 복사된 오브젝트의 하이라키상의 부모를 설정할 수 있다. 
            t.localPosition = new Vector3(Random.Range(-2000, 2000), 5f, Random.Range(-2000, 2000));
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }
        return go;
    }

    public static GameObject CreateITEM(GameObject parent, GameObject prefab)
    {
        GameObject go = GameObject.Instantiate(prefab) as GameObject;
        if (go != null && parent != null)
        {
            Transform t = go.transform;
            t.SetParent(parent.transform);
            t.localPosition = new Vector3(Random.Range(-2000, 2000), 0f, Random.Range(-2000, 2000));
            t.localRotation = Quaternion.identity;
            t.localScale = new Vector3(5, 5, 5);
        }
        return go;
    }

    public void CreateEnemy()
    {
        if (EnemyCount <= 30)
        {
            int EnemySpawn = Random.Range(0, 3); 
            switch(EnemySpawn)
            {
                case 0:
                    GameObject enemy1 = CreateENEMY(gameObject, enemy_red);
                    AddObject(ObjectType.Enemy, enemy1);
                    UIManager.instance.SetHpBar(enemy1);
                    EnemyCount += 1;
                    break;
                case 1:
                    GameObject enemy2 = CreateENEMY(gameObject, enemy_blue);
                    AddObject(ObjectType.Enemy, enemy2);
                    UIManager.instance.SetHpBar(enemy2);
                    EnemyCount += 1;
                    break;
                case 2:
                    GameObject enemy3 = CreateENEMY(gameObject, enemy_green);
                    AddObject(ObjectType.Enemy, enemy3);
                    UIManager.instance.SetHpBar(enemy3);
                    EnemyCount += 1;
                    break;
            }
        }
    }

    public void CreateMiddleBoss()
    {
        if (EnemyCount <= 3)
        {
            GameObject enemy = CreateENEMY(gameObject, MiddleBoss);
            AddObject(ObjectType.Enemy, enemy);
            UIManager.instance.SetMBHpBar(enemy);
            EnemyCount += 1;
        }
    }

    public void CreateItem()
    {
        if (ItemCount <= 10)
        {
            GameObject item = CreateITEM(gameObject, item1Prefab);
            AddObject(ObjectType.Item, item);
            ItemCount += 1;
        }
    }
    public static void Cancel()
    {
        instance.CancelInvoke();
    }
}
