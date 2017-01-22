using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    MonsterManager mgr = null;
    public string waveType = "Simple Wave";
    public int attempts = 0;
    public bool friend = false;

    void Start()
    {
    }

    public void Friend()
    {
        MonsterDialogue m_Dialog = gameObject.GetComponentInChildren<MonsterDialogue>();
        MonsterAudio m_Audio = gameObject.GetComponentInChildren<MonsterAudio>();

        m_Dialog.SetDialogue("happy");
        m_Audio.SetAudio("happy");
        mgr.friendCount++;
        friend = true;
    }

    public void Unfriend()
    {
        if (friend)
        {
            return;
        }

        MonsterDialogue m_Dialog = gameObject.GetComponentInChildren<MonsterDialogue>();
        MonsterAudio m_Audio = gameObject.GetComponentInChildren<MonsterAudio>();

        m_Dialog.SetDialogue(attempts.ToString());
        m_Audio.SetAudio(attempts.ToString());

        attempts++;

        if (attempts > 2)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        
    }
}
