﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    public List<SpawnPoint> spawnPoints;
    public List<GameObject> monsters;
    public int monsterCount = 0;
    public int friendCount = 0;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSpawnPoint(SpawnPoint spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
        Transform m_Transform = monsters[0].transform;
        GameObject m_Object = Instantiate(monsters[0], new Vector3(0,0,0), Quaternion.identity);
        m_Object.transform.position = spawnPoint.transform.position;
        m_Object.transform.rotation = spawnPoint.transform.rotation;
        m_Object.gameObject.name = "Monster_" + monsterCount;
        monsterCount++;
    }
}
