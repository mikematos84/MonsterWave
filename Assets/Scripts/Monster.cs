using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    MonsterManager mgr = null;

	// Use this for initialization
	void Start () {
        mgr = FindObjectOfType<MonsterManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
