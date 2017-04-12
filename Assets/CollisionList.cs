using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionList : MonoBehaviour {

	public List<Collider> CollisionObjects;

	public void OnTriggerEnter(Collider other){
		CollisionObjects.Add (other);
	}

	public void OnTriggerExit(Collider other){
		CollisionObjects.Remove (other);
	}
}
