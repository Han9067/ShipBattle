using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DMGLabel : MonoBehaviour {

    void Start () {
    }

    void Update() {
        StartCoroutine(LabelUP());
        Destroy(this.gameObject, 1.5f);
    }


    IEnumerator LabelUP()
    {
        float UpSpeed = 1f;

        while (UpSpeed > 0)
        {
            transform.Translate(Vector3.up * UpSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
