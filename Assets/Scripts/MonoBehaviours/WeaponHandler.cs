using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

	public GameObject mallet;
	public GameObject pistol;
	public bool malletEnabled;
	public bool pistolEnabled;

	private void Start() {
		mallet.SetActive(false);
		pistol.SetActive(false);	
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Q)){
			if(malletEnabled && mallet.activeInHierarchy){
				if(pistolEnabled){
					pistol.SetActive(true);
					mallet.SetActive(false);
				}
			}else if(pistolEnabled && pistol.activeInHierarchy){
				if(malletEnabled){
					mallet.SetActive(true);
					pistol.SetActive(false);
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.name == "MalletActivator"){	
			if(pistol.activeInHierarchy)
				pistol.SetActive(false);
			other.gameObject.SetActive(false);
			malletEnabled = true;
			mallet.SetActive(true);
		}else if(other.name == "PistolActivator"){
			if(mallet.activeInHierarchy)
				mallet.SetActive(false);
			other.gameObject.SetActive(false);
			pistolEnabled = true;
			pistol.SetActive(true);
		}
	}
}

