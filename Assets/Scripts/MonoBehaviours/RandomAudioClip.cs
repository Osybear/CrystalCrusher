using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClip : MonoBehaviour {

	public SoundList soundList;
	private AudioSource source;

	private void Start() {
		source = GetComponent<AudioSource>();
	}

	public void Play(){
		source.clip = soundList.list[Random.Range(0, soundList.list.Count)];
		source.Play();
	}

}
