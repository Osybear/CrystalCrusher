using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

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
			Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo, maxDistance)){
				Debug.Log(hitInfo.transform);
				Crystal crystal = hitInfo.transform.GetComponent<Crystal>();
				if(crystal != null){
					crystal.Damage(strength);
				}
			}else{
				Debug.DrawLine(ray.origin, mainCamera.transform.position + (mainCamera.transform.forward * maxDistance), Color.red, 1f);
			}
			animator.SetTrigger("Swing"); 
		}
	}
}