using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float speed = 0f;
    [SerializeField] private AudioSource spikesOut;
    [SerializeField] private AudioSource spikesIn;

    void Update()
    {  

       if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
         {
            
            currentWaypointIndex++;
            speed = 20f;
            if (currentWaypointIndex >= waypoints.Length)
            {
                spikesOut.Play();
                currentWaypointIndex = 0;
                speed = 0.0f;
            }
       
        }
        if (speed == 0.0f)
        {
            Invoke("speedDown", 3);
            spikesIn.Play();
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
           
    }
    void speedDown()
    {
        speed = 1.2f;
        
    }


}

