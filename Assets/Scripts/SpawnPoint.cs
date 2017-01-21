using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    MonsterManager mgr = null;

	// Use this for initialization
	void Start () {
        mgr = FindObjectOfType<MonsterManager>();
        mgr.spawnPoints.Add(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
