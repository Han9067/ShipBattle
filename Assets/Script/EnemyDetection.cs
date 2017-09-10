using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {
    GameObject Enemy;
    Enemy_Action EA;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        EA = Enemy.GetComponent<Enemy_Action>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            EA.ObjDetection = true;
        }
        if (other.gameObject.tag.Equals("MiddleBoss"))
        {
            EA.ObjDetection = true;
        }
        if (other.gameObject.tag.Equals("Player"))
        {
            EA.ObjDetection = true;
        }
        if (other.gameObject.tag.Equals("Terrain2"))
        {
            EA.ObjDetection = true;
        }
    }
	
}
