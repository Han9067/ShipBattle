using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip soundExplosion;
    public AudioClip soundShot;

    AudioSource myAudio;

    public static SoundManager instance; //정적할당

    void Awake() //start보다 먼저 호출
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
    public void ShotSound()
    {
        myAudio.PlayOneShot(soundShot);
    }

    public void HitSound()
    {
        myAudio.PlayOneShot(soundExplosion);
    }

    void Update () {
		
	}
}
