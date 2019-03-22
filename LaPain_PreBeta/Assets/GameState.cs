using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public GameObject winScreenPanel;
    public Text winScreenText;

    public bool winState;
    public bool gameOverState;

    public GameObject sneko;
    public GameObject player;
    public GameObject pauseCanvas;

	// Use this for initialization
	void Start () {
        winScreenPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update() {

        if(sneko.activeInHierarchy == false){
            winState = true;
        }

		if (winState) {
            winScreenPanel.SetActive(true);
            player.SetActive(false);
            pauseCanvas.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("Menu");
                Time.timeScale = 1;
            }
        }

	}
}
