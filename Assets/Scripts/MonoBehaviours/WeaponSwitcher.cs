using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

	public MalletHandler malletHandler;
	public PistolHandler pistolHandler;
	public GameObject malletModels;
	public GameObject pistolModels;
	public Animator malletAnimator;
	public Animator pistolAnimator;
	public bool malletEnabled;
	public bool pistolEnabled;

	private void Start() {
		malletModels.SetActive(false);
		malletHandler.enabled = false;
		pistolModels.SetActive(false);	
		pistolHandler.enabled = false;
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Q)){
			if(malletEnabled && malletModels.activeInHierarchy){
				if(pistolEnabled){
					pistolModels.SetActive(true);
					pistolHandler.enabled = true;
					pistolAnimator.SetTrigger("Equip");

					malletModels.SetActive(false);
					malletHandler.enabled = false;
				}
			}else if(pistolEnabled && pistolModels.activeInHierarchy){
				if(malletEnabled){
					malletModels.SetActive(true);
					malletHandler.enabled = true;
					malletAnimator.SetTrigger("Equip");

					pistolModels.SetActive(false);
					pistolHandler.enabled = false;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.name == "MalletActivator"){	
			if(pistolModels.activeInHierarchy){
				pistolModels.SetActive(false);
				pistolHandler.enabled = false;
			}
			other.gameObject.SetActive(false);
			malletEnabled = true;
			malletHandler.enabled = true;
			malletModels.SetActive(true);
			malletAnimator.SetTrigger("Equip");
		}else if(other.name == "PistolActivator"){
			if(malletModels.activeInHierarchy){
				malletModels.SetActive(false);
				malletHandler.enabled = false;
			}
			other.gameObject.SetActive(false);
			pistolEnabled = true;
			pistolHandler.enabled = true;
			pistolModels.SetActive(true);
			pistolAnimator.SetTrigger("Equip");
		}
	}
}

