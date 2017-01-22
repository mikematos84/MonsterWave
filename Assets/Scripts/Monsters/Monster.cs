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
        m_Dialog.SetDialogue("happy");
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
        m_Dialog.SetDialogue(attempts.ToString());
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
