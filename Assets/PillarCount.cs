using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarCount : MonoBehaviour
{
    PlayerStats pillar;
   
    Text pillarText;
    void Start()
    {
        pillar = GameObject.Find("PlayerKnight").GetComponent<PlayerStats>();
        pillarText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pillarText.text = pillar.currentPillars.ToString() + "/" + pillar.allPillars;
    }
}
