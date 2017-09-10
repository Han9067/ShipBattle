using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute : MonoBehaviour {

    public float Radius;
    public int HPMAX;
    public int HP;
    public int Stamina;
    public int StaminaMax;

    public int AttackPower; //공격력
    public int Def; //방어력
    public float AttDelay = 3f; //다음 공격까지의 쿨타임 (공격속도)
    public int MoveSpeedMAX = 50;

    public int PlyerExp = 0; //플레이어의 경험치
    public int EnemyExp = 0; //적을 물리쳤을시 얻는 경험치
    public int MaxExp = 0; //레벨당 달성해야하는 경험치

    public int GetScore;

    public int GetGold;

    public int Level = 1;

    public bool GameOverOn = false;

}
