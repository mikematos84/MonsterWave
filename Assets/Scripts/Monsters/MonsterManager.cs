using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    public List<SpawnPoint> spawnPoints;
    public List<GameObject> monsters;
    public int monsterCount = 0;
    public int friendCount = 0;

    public List<TextMesh> txt_FriendCounters;
    
	// Use this for initialization
	void Start () {
        InvokeRepeating("RandomSpawn", 0.0f, 5.0f);

    }
	
	// Update is called once per frame
	void Update () {
        foreach(TextMesh friendCounter in txt_FriendCounters)
        {
            friendCounter.text = friendCount.ToString();
        }
	}

    public void AddSpawnPoint(SpawnPoint spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
    }

    public void RandomSpawn()
    {
        //random spawnpoint
        int rand = Random.Range(0, spawnPoints.Count);
        SpawnPoint spawnPoint = spawnPoints[rand];

        //random monster
        rand = Random.Range(0, monsters.Count);
        GameObject m_RandomMonster = monsters[rand];

        spawnPoint.Spawn(m_RandomMonster);
    }
}
