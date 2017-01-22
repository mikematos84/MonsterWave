using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour {

    public AudioClip[] monsterClips = new AudioClip[3];

    private AudioSource monsterSource;

    void Start()
    {

        monsterSource = GetComponent<AudioSource>();

    }

	public void SetAudio(string clipName)
    {
        switch (clipName)
        {
            case "excited":
                monsterSource.clip = monsterClips[0];
                break;
            case "confused":
            case "0":
            case "1":
                monsterSource.clip = monsterClips[1];
                break;
            case "angry":
            case "2":
                monsterSource.clip = monsterClips[2];
                break;
        }

        monsterSource.Play();

    }
}
