using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingItem : MonoBehaviour {
    public TextMesh DMG_Label;
    GameObject Player;
    GameObject Obj;
    CharacterAttribute CA;
    ObjectManager ObjMgr;

    int HPup = 10;
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Obj = GameObject.FindGameObjectWithTag("Object");
        ObjMgr = Obj.GetComponent<ObjectManager>();
        CA = Player.GetComponent<CharacterAttribute>();
    }

	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if(CA.HP <= CA.HPMAX)
            {
                if (CA.HP >= CA.HPMAX - HPup)
                {
                    HPup = CA.HPMAX - CA.HP;
                }
                Destroy(this.gameObject);
                CA.HP += HPup;
                if (CA.HP >= CA.HPMAX)
                {
                    CA.HP = CA.HPMAX;
                }
                DMG_Label.text = "+" + HPup.ToString();
                Instantiate(DMG_Label, other.transform.position, Camera.main.transform.rotation);
                HPup = 10;

                ObjMgr.ItemCount -= 1;
            }
        }
    }
}
