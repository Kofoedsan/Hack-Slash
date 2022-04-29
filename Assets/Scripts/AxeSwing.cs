using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeSwing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotateSpeed = 60f;
    


    void Update()
    {

        transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * rotateSpeed, 90) - 45, 0f, 0f);
    

    }

 



}
