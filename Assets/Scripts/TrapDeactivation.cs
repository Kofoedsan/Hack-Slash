using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeactivation : MonoBehaviour
{
    private GameObject[] saw;
    public Material material;
    private Renderer rend;

    void Start()
    {
        saw = GameObject.FindGameObjectsWithTag("Saw");
        rend = GetComponent<Renderer>();
        
    }

    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("Player") && !this.gameObject.GetComponent<TrapActivation>().enabled)
        {
            Invoke("TrapDeactivate", 1);
        }
    }

    void TrapDeactivate()
    {
        foreach(GameObject ready in saw) {
            ready.GetComponent<Rotate>().enabled = false;
            ready.GetComponent<WaypointFollower>().enabled = false;
            ready.GetComponent<AudioSource>().enabled = false;
        this.gameObject.GetComponent<TrapDeactivation>().enabled = false;
        this.gameObject.GetComponent<TrapActivation>().enabled = true;
        rend.sharedMaterial = material;
        }
    }
}
