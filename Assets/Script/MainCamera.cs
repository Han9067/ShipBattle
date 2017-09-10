using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform Player;

    public float distance = 120.0f; //카메라와 타겟의 거리
    float mouseRotation = 0f; //마우스의 좌우회전
    float mouseHeight = 30f; //마우스의 위아래 회전

    void LateUpdate()
    {

        mouseRotation += Input.GetAxis("Mouse X") * 3; 
        mouseHeight -= Input.GetAxis("Mouse Y") * 3;
        if (mouseHeight <= -20)
        {
            mouseHeight += Input.GetAxis("Mouse Y") * 3;
        }
        if(mouseHeight >= 50)
        {
            mouseHeight = 50;
        }


        Quaternion currentRotation = Quaternion.Euler(mouseHeight, mouseRotation, 0);

        transform.position = Player.position + new Vector3(0, 30, 0) -
            (currentRotation * Vector3.forward * distance);

        distance = distance - (Input.GetAxis("Mouse ScrollWheel") * 50);
        if (distance <= 80 || distance >= 160)
        {
            distance = distance + (Input.GetAxis("Mouse ScrollWheel") * 50);
        }
        transform.LookAt(Player);


    }
}
