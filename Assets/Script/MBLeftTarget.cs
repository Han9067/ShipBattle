using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLeftTarget : MonoBehaviour {
    public GameObject Bullet;
    public GameObject L_BulletPosition1;
    public GameObject L_BulletPosition3;
    public GameObject L_BulletPosition5;
    bool LeftShotOn = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (LeftShotOn == true)
            {
                Instantiate(Bullet, L_BulletPosition1.transform.position, transform.rotation);
                Instantiate(Bullet, L_BulletPosition3.transform.position, transform.rotation);
                Instantiate(Bullet, L_BulletPosition5.transform.position, transform.rotation);
                LeftShotOn = false;
                SoundManager.instance.ShotSound();
                StartCoroutine(AttackDelay(Bullet));
            }
        }
    }

    IEnumerator AttackDelay(GameObject Bullet)
    {
        yield return new WaitForSeconds(4f);
        LeftShotOn = true;
    }
}
