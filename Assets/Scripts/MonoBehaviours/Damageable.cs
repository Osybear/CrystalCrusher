using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {

	public int health;
	public UnityEvent onHealthZero;
	
	public void Damage(int amount){
		health = health - amount;	 
		if(health <= 0){
			onHealthZero.Invoke();
		}
	}

	public void Heal(int amount){
		health = health + amount;
	}
}
