using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject levelsPanel;
	public GameObject controlsPanel;
	public GameObject BackButton;

	private void Start() {
		levelsPanel.SetActive(false);
		controlsPanel.SetActive(false);
		BackButton.SetActive(false);
	}

	public void LoadScene(GameObject level){
		SceneManager.LoadScene(level.name);
	}
}
