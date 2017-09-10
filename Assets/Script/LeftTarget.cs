using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTarget : MonoBehaviour {
    public GameObject Bullet;
    public GameObject L_BulletPosition;
    bool LeftShotOn = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if(LeftShotOn == true)
            {
                Instantiate(Bullet, L_BulletPosition.transform.position, transform.rotation);
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
