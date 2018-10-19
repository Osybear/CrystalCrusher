using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oob : MonoBehaviour {

	public Transform spawnPoint;
	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			other.transform.position = spawnPoint.position;
		}
	}
}
