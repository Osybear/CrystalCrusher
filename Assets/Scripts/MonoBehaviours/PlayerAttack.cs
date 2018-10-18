using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	/*
	raycast out from the camera.
	if the object hit has a (Interactable) script
	call the action of that interactable object
	*/
	public float maxDistance;
	public int strength;
	public Camera mainCamera;
	public Animator animator;
	public AudioSource audioSource;
	public List<AudioClip> malletHit;
	public List<AudioClip> malletMiss;

	private void Update() {
		if(Input.GetMouseButtonDown(0)){
			animator.SetTrigger("Swing");
		}
	}

	private void Swing(){
		Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray, out hitInfo, maxDistance)){
			audioSource.clip = malletHit[Random.Range(0, malletHit.Count)];
			audioSource.Play();
			Crystal crystal = hitInfo.transform.GetComponent<Crystal>();
			if(crystal != null)
				crystal.Damage(strength);
		}else{
			audioSource.clip = malletMiss[Random.Range(0, malletMiss.Count)];
			audioSource.Play();
		}
	}

}