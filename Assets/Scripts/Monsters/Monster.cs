using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    MonsterManager mgr = null;
    public string waveType = "Simple Wave";
    public int attempts = 0;
    public bool friend = false;

    private MonsterDialogue m_Dialog;
    private MonsterAudio m_Audio;

    void Start()
    {
        mgr = FindObjectOfType<MonsterManager>();
        m_Dialog = gameObject.GetComponentInChildren<MonsterDialogue>();
        m_Audio = gameObject.transform.parent.gameObject.GetComponent<MonsterAudio>();
    }

    public void Friend()
    {
        if (friend)
        {
            m_Dialog.SetDialogue("happy");
            m_Audio.SetAudio("happy");
            mgr.friendCount++;
            friend = true;
        }
    }

    public void Unfriend()
    {
        if (friend)
        {
            return;
        }


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
