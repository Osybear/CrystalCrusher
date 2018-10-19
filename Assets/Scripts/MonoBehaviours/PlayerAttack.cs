using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour {

	public PlayerSettings playerSettings;
	public Camera mainCamera;
	public Animator animator;
	public AudioSource audioSource;
	public SoundList hitClips;
	public SoundList missClips;
	
	private void Update() {
		if(Input.GetMouseButtonDown(0)){
			animator.SetTrigger("Swing");
		}
	}

	private void Swing(){
		Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray, out hitInfo, playerSettings.maxDistance)){
			Damageable damageable = hitInfo.transform.GetComponent<Damageable>();
			if(damageable)
				damageable.Damage(playerSettings.strength);
			PlayRandom(hitClips.list);
		}else{
			PlayRandom(missClips.list);
		}
	}

	private void PlayRandom(List<AudioClip> list){
		audioSource.clip = list[Random.Range(0, list.Count)];
		audioSource.Play();
	}
}