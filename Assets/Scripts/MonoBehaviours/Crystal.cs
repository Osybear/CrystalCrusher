using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {
  
    public int hitPoints;
    public float rotateSpeed;
    public Animator animator;
    public GameEvent onCrystalDestroy;
    public GameEvent onCrystalAdd;
    
    private void Start() {
        onCrystalAdd.Raise();
    }   

    public void Damage(int amount){
        hitPoints = hitPoints - amount;
        if(hitPoints <= 0){
            onCrystalDestroy.Raise();
            animator.enabled = false;
            foreach(Transform child in animator.transform){
                child.gameObject.AddComponent(typeof(Rigidbody));
            }
        }
    }
}
