using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MalletHandler : MonoBehaviour {

	public float maxDistance;
	public int strength;
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
		if(Physics.Raycast(ray, out hitInfo, maxDistance)){
			Damageable damageable = hitInfo.transform.GetComponent<Damageable>();
			if(damageable)
				damageable.Damage(strength);
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