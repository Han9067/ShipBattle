using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWake : MonoBehaviour {
    GameObject Player;
    PlayerControll PC; 
    public GameObject Pos;
    public GameObject waterwake;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PC = Player.GetComponent<PlayerControll>();

	}
	
	
	void Update () {

        if (PC.MoveSpeed <= 0)
        {

        }
        if (PC.MoveSpeed >= 1 && PC.MoveSpeed < 10)
        {
            waterwake.transform.Translate(0, 1, 0);
        }
        if (PC.MoveSpeed >= 11 && PC.MoveSpeed < 30)
        {
            waterwake.transform.position = new Vector3(Pos.transform.position.x,
Pos.transform.position.y - 0.3f, Pos.transform.position.z + 30);
        }
        if (PC.MoveSpeed >= 31 && PC.MoveSpeed < 50)
        {
            waterwake.transform.position = new Vector3(Pos.transform.position.x,
Pos.transform.position.y - 0.2f, Pos.transform.position.z + 30);
        }
        if (PC.MoveSpeed >= 51 && PC.MoveSpeed < 500)
        {
            waterwake.transform.position = new Vector3(Pos.transform.position.x,
Pos.transform.position.y - 0.1f, Pos.transform.position.z + 30);
        }
    }
}
