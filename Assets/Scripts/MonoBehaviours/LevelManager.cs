using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public int numCrystals = 0;
	public int numCrystalsLeft = 0; // how many are left to be destroyed by the player
	public AudioClip breakClip;
	public AudioSource audioSource;

	public void OnCrystalDestroy(){
		numCrystalsLeft--;
		if(numCrystalsLeft <= 0){
			StartCoroutine(OnLastCrytalDestroyed());
		}
	}

	public void OnCrystalAdd(){
		numCrystals++;
		numCrystalsLeft++;
	}

	public IEnumerator OnLastCrytalDestroyed(){
		audioSource.Play();
		yield return new WaitForSeconds(breakClip.length);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene("Menu");
	}
}
