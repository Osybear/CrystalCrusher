﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {
  
    public int hitPoints;
    public float rotateSpeed;
    public bool rotate = true;
    public int rotateDir;
    public Animator animator;
    public GameEvent onCrystalDestroy;
    public GameEvent onCrystalAdd;
    public AudioSource audioSource;
    public List<AudioClip> breakClips;
    
    private void Start() {
        onCrystalAdd.Raise();
        Quaternion rotation = Random.rotation;
        animator.transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        rotateDir = Random.Range(0,2)*2-1;
        audioSource.clip = breakClips[Random.Range(0, breakClips.Count)];
    }   

    private void Update() {
        if(rotate)
            animator.transform.Rotate((rotateDir * animator.transform.up) * Time.deltaTime * rotateSpeed);
    }

    public void Damage(int amount){
        hitPoints = hitPoints - amount;
        if(hitPoints <= 0){
            audioSource.Play();
            onCrystalDestroy.Raise();
            animator.enabled = false;
            foreach(Transform child in animator.transform){
                rotate = false;
                child.gameObject.AddComponent(typeof(Rigidbody));
            }
        }
    }
}
