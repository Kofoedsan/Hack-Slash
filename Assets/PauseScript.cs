using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    bool ecp = false;
    int counter = 0;

    GameObject obj;

    private void Start() {
        obj = GameObject.Find("PauseMenu");
        obj.SetActive(false);
    }

    private void Update() {
        ecp = Input.GetKeyDown(KeyCode.Escape);

        if (ecp == true && counter==0) {
            Invoke("pausestart", 0.01f);
            obj.SetActive(true);
        }

        if (ecp == true && counter > 0 ) {
            ResumeGame();
            obj.SetActive(false);
            counter = 0;
        }
    }

    void PauseGame() {
        Time.timeScale = 0;
    }

    void ResumeGame() {
        Time.timeScale = 1;
    }

    void pausestart() {
        PauseGame();
        counter = 1;
    }

}
