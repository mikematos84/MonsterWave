using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour {

    public AudioClip[] monsterClips = new AudioClip[5];
    public float revealAudioTimer = 3.0f;

    private AudioSource monsterSource;
    //private float tempTimer = 0.0f;
    //private float timerSpan = 2.5f;
    //private int tempCount = 0;

    void Start()
    {

        monsterSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        /*temporary code to cycle through audio clips without gesture mechanics
        if (tempTimer >= 0)
        {
            tempTimer -= Time.deltaTime;

        }

        if (tempTimer <= 0)
        {

            SetAudio(tempCount.ToString());
            tempCount++;
            tempTimer = timerSpan;

        }

        if(tempCount >= monsterClips.Length)
        {

            tempCount = 0;

        } */

        if (revealAudioTimer > 0) {
            revealAudioTimer -= Time.deltaTime;

            if(revealAudioTimer <= 0)
            {

                SetAudio("greeting");
            }
        }

    }

	public void SetAudio(string clipName)
    {
        switch (clipName)
        {
            case "greeting":
                monsterSource.clip = monsterClips[0];
                //Debug.Log("Switching to greeting");
                break;
            case "confused":
            case "0":
                monsterSource.clip = monsterClips[1];
                //Debug.Log("Switching to confused");
                break;
            case "skeptical":
            case "1":
                monsterSource.clip = monsterClips[2];
                //Debug.Log("Switching to skeptical");
                break;
            case "angry":
            case "2":
                monsterSource.clip = monsterClips[3];
                //Debug.Log("Switching to angry");
                break;
            case "happy":
                monsterSource.clip = monsterClips[4];
                //Debug.Log("Switching to happy");
                break;

        }

        monsterSource.Play();

    }
}
