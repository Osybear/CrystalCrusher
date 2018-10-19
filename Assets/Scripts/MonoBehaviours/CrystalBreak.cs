using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBreak: MonoBehaviour {

	public Animator animator;

	public void BreakIntoPieces(){
		animator.enabled = false;
        foreach(Transform child in animator.transform){
            child.gameObject.AddComponent(typeof(Rigidbody));
        }
	}
}
