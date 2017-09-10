using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBRightTarget : MonoBehaviour {
    public GameObject Bullet;
    public GameObject R_BulletPosition1;
    public GameObject R_BulletPosition3;
    public GameObject R_BulletPosition5;

    bool RightShotOn = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (RightShotOn == true)
            {
                Instantiate(Bullet, R_BulletPosition1.transform.position, transform.rotation);
                Instantiate(Bullet, R_BulletPosition3.transform.position, transform.rotation);
                Instantiate(Bullet, R_BulletPosition5.transform.position, transform.rotation);
                RightShotOn = false;
                SoundManager.instance.ShotSound();
                StartCoroutine(AttackDelay(Bullet));
            }
        }
    }

    IEnumerator AttackDelay(GameObject Bullet)
    {
        yield return new WaitForSeconds(4f);
        RightShotOn = true;
    }
}
