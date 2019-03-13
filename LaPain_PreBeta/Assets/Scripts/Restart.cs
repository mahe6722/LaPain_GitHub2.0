using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    PlaceHolder_Health playerHealth;

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlaceHolder_Health>();
    }

    void Update()
    {

        if (playerHealth.currentHealth <= 0) {

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}