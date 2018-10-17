using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	/*
	raycast out from the camera.
	if the object hit has a (Interactable) script
	call the action of that interactable object
	*/
	public Camera mainCamera;
	public float maxDistance;
	public int strength;
	public Animator animator;
	
	private void Update() {
		if(Input.GetMouseButtonDown(0)){
			animator.SetTrigger("Swing");
		}
	}

	private void Swing(){
		Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray, out hitInfo, maxDistance)){
			Crystal crystal = hitInfo.transform.GetComponent<Crystal>();
			if(crystal != null)
				crystal.Damage(strength);
		}else{
			Debug.DrawLine(ray.origin, mainCamera.transform.position + (mainCamera.transform.forward * maxDistance), Color.red, 1f);
		}
	}
}