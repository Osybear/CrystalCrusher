using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUp : MonoBehaviour {

	public int rotateSpeed;
	public int rotateDir;
	public bool rotatable = true;

	private void Start() {
		Quaternion rotation = Random.rotation;
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
		rotateDir = Random.Range(0,2)*2-1;
	}

	private void Update() {
		if(rotatable)
            transform.Rotate((rotateDir * transform.up) * Time.deltaTime * rotateSpeed);
	}

	public void SetRotatable(bool active){
		rotatable = active;
	}
}
