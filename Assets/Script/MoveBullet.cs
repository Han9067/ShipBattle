using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBullet : MonoBehaviour {
    //public float moveSpeed = 10.0f;
    public Rigidbody rb; //리지바디
    public ParticleSystem Explosion;
    public TextMesh DMG_Label;
    public GameObject WaterSplash;

    private PlayerControll PC;
    private CharacterAttribute CA;
    private CharacterAttribute CA2;

    int DMGText = 0;
    public int power = 1000; //미사일 속도의 파워
    private string sBulletPos = "";
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindWithTag("Player"); //플레이어 오브젝트
        PC = player.gameObject.GetComponent<PlayerControll>();
        
    }

	void Update () {
        //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //rb.AddForce(this.transform.right * power);

        sBulletPos = PC.BulletPos; //플레이어 포탄위치값을 받는다

        if (sBulletPos == "R") //iBulletPos가 R이면 오른쪽으로 포탄을
        {                    //L이면 왼쪽으로 포탄을 발사
            rb.AddForce(this.transform.right * power);
        }
        if (sBulletPos == "L")
        {
            rb.AddForce(-this.transform.right * power);
        }

        Destroy(this.gameObject,3);
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Terrain"))
        {
            Destroy(this.gameObject);
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
        }
        if (other.gameObject.tag.Equals("Enemy"))
        {        
            Destroy(this.gameObject);
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            CA2 = other.gameObject.GetComponent<CharacterAttribute>();
            CA = PC.gameObject.GetComponent<CharacterAttribute>();
            CA2.HP = CA2.HP - (CA.AttackPower - CA2.Def);
            DMGText = -(CA.AttackPower - CA2.Def);
            DMG_Label.text = DMGText.ToString();
            Instantiate(DMG_Label, other.transform.position, Camera.main.transform.rotation);
            SoundManager.instance.HitSound();
        }
        if (other.gameObject.tag.Equals("Sea"))
        {
            Destroy(this.gameObject);
            Instantiate(WaterSplash, this.transform.position, this.transform.rotation);
        }
    }
}
