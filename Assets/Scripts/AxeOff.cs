using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeOff : MonoBehaviour
{
    private GameObject[] axe;
    public Material material;
    private Renderer rend;

    void Start()
    {
        axe = GameObject.FindGameObjectsWithTag("SwingAxe");
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
        foreach (GameObject ready in axe)
        {
            ready.GetComponent<AxeSwing>().enabled = false;
            ready.GetComponent<AxeSwing>().transform.eulerAngles = new Vector3(135f, 0f, 0f);
            this.gameObject.GetComponent<TrapDeactivation>().enabled = false;
            this.gameObject.GetComponent<TrapActivation>().enabled = true;
        }
    }
}