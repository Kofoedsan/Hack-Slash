using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    bool ecp = false;
    public int counter = 0;

    GameObject obj;

    private void Start() {
        obj = GameObject.Find("PauseMenu");
        obj.SetActive(false);
    }

    private void Update() {
        ecp = Input.GetKeyDown(KeyCode.Escape);

        if (ecp == true && counter==0) {
            Invoke("PauseStart", 0.01f);
            obj.SetActive(true);
        }

        if (ecp == true && counter > 0 ) {
            ResumeGame();
        }


    }

    void PauseGame() {
        Time.timeScale = 0;
    }

    void ResumeGame() {
        Time.timeScale = 1;
        obj.SetActive(false);
        counter = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseStart() {
        PauseGame();
        counter = 1;
    }

    public void ResumeGameButton()
    {
        ResumeGame();
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        ResumeGame();
        Cursor.lockState = CursorLockMode.None;
    }

}
