using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapActivation : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player") && !this.gameObject.GetComponent<TrapDeactivation>().enabled)
        {

            Invoke("TrapActivate", 1);
        }

    }

    void TrapActivate()
    {
        foreach(GameObject ready in saw) {
            ready.GetComponent<Rotate>().enabled = true;
            ready.GetComponent<WaypointFollower>().enabled = true;
            ready.GetComponent<AudioSource>().enabled = true;
        this.gameObject.GetComponent<TrapDeactivation>().enabled = true;
        this.gameObject.GetComponent<TrapActivation>().enabled = false;
        rend.sharedMaterial = material;
        }
    }

}
