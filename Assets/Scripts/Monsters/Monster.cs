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
    private PlayMakerFSM m_MonsterFSM;
    private PlayMakerFSM m_LeftHandFSM;
    private PlayMakerFSM m_RightHandFSM;

    void Start()
    {
        m_MonsterFSM = transform.parent.gameObject.GetComponent<PlayMakerFSM>();
        m_LeftHandFSM = GameObject.Find("[CameraRig]/Controller (left)/DRAMATIC_hands").GetComponent<PlayMakerFSM>();
        m_RightHandFSM = GameObject.Find("[CameraRig]/Controller (right)/DRAMATIC_hands").GetComponent<PlayMakerFSM>();
        mgr = FindObjectOfType<MonsterManager>();
        m_Dialog = gameObject.GetComponentInChildren<MonsterDialogue>();
        m_Audio = gameObject.transform.parent.gameObject.GetComponent<MonsterAudio>();
    }

    public void Friend()
    {
        if (!friend)
        {
            m_MonsterFSM.Fsm.Event("success");
            m_LeftHandFSM.Fsm.Event("success");
            m_RightHandFSM.Fsm.Event("success");

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
