using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public int numCrystals = 0;
	public int numCrystalsLeft = 0; // how many are left to be destroyed by the player
	
	public void OnCrystalDestroy(){
		numCrystalsLeft--;
		if(numCrystalsLeft <= 0){
			Debug.Log("You win");
		}
	}

	/*
		all crystals will notify the level manager that it exists* free real estate 
	*/
	public void OnCrystalAdd(){
		numCrystals++;
		numCrystalsLeft++;
	}
}
