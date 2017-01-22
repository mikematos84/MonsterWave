using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    MonsterManager mgr = null;

	// Use this for initialization
	void Start () {
        mgr = FindObjectOfType<MonsterManager>();
        mgr.AddSpawnPoint(this);
    }

    public void Spawn(GameObject monster)
    {
        GameObject m_Object = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
        m_Object.transform.position = transform.position;
        m_Object.transform.rotation = transform.rotation;
        m_Object.gameObject.name = "Monster_" + mgr.monsterCount;
        mgr.monsterCount++;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
