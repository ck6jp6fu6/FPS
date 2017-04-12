using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

	public GameObject MonsterCandidate1;
	public GameObject MonsterCandidate2;
	public List<Transform> SpawnPoint;
	public GameObject initFollowTarget;

	public float SpawnMonsterTime = 100;
	private float spwanCounter = 0;

	// Update is called once per frame
	void Update () {
		spwanCounter += Time.deltaTime;

		if (spwanCounter >= SpawnMonsterTime) {
			spwanCounter = 0;
			float ran = Random.value;
			if (ran < 0.5) {
				GameObject newMonster = GameObject.Instantiate (MonsterCandidate1);
				newMonster.GetComponent<MonsterScript> ().FollowTarget = initFollowTarget;
				newMonster.transform.position = SpawnPoint [Random.Range (0, SpawnPoint.Count)].position;
			}
			else{
				GameObject newMonster = GameObject.Instantiate (MonsterCandidate2);
				newMonster.GetComponent<AnemyController> ().FollowTarget = initFollowTarget;
				newMonster.transform.position = SpawnPoint [Random.Range (0, SpawnPoint.Count)].position;
			}
		}
	}
}
