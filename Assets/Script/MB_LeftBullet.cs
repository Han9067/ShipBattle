using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_LeftBullet : MonoBehaviour {
    public Rigidbody rb; //리지바디
    public ParticleSystem Explosion;
    public TextMesh DMG_Label;
    public GameObject WaterSplash;
    private CharacterAttribute CA;
    private CharacterAttribute CA2;

    int DMGText = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject MB = GameObject.FindWithTag("MiddleBoss");
        CA = MB.GetComponent<CharacterAttribute>();
    }

    void Update()
    {
        rb.AddForce(-this.transform.right * 300);

        Destroy(this.gameObject, 3);
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Terrain"))
        {
            Destroy(this.gameObject);
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
        }
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            CA2 = other.gameObject.GetComponent<CharacterAttribute>();
            CA2.HP = CA2.HP - (CA.AttackPower - CA2.Def);
            DMGText = -(CA.AttackPower - CA2.Def);
            DMG_Label.text = DMGText.ToString();//데미지 표시
            Instantiate(DMG_Label, other.transform.position, Camera.main.transform.rotation); //데미지 표시 생성
            SoundManager.instance.HitSound();
        }
        if (other.gameObject.tag.Equals("Sea"))
        {
            Destroy(this.gameObject);
            Instantiate(WaterSplash, this.transform.position, this.transform.rotation);
        }
    }
}
