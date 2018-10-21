using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oob : MonoBehaviour {

	public float yCutOff;
	public Vector3 spawnPoint;

	private void Update() {
		if(transform.position.y < yCutOff){
			transform.position = spawnPoint;
		}
	}
}
