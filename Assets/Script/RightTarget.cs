using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTarget : MonoBehaviour {
    public GameObject Bullet;
    public GameObject R_BulletPosition;
    bool RightShotOn = true;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            if(RightShotOn == true)
            {
                Instantiate(Bullet, R_BulletPosition.transform.position, transform.rotation);
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
