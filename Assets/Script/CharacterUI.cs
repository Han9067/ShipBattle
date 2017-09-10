using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public Slider HPBar;
    public GameObject HeadUpPosition;
    private CharacterAttribute attribute;

	void Start () {
        attribute = gameObject.GetComponent<CharacterAttribute>();
	}
	
	void Update () {
        if(HPBar != null)
        {
            HPBar.value = (float)attribute.HP / (float)attribute.HPMAX;
            HPBar.transform.position = HeadUpPosition.transform.position;
            HPBar.transform.rotation = Camera.main.transform.rotation;
            if(HPBar.value <= 0)
            {
                Destroy(HPBar.gameObject);
                Destroy(this.gameObject,4);
            }
        }       
    }

}
