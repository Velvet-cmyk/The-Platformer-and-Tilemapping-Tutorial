using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontrollersecond : MonoBehaviour
{
    private Vector3 pos1= new Vector3(60.36f,-0.38f,0); 
    private Vector3 pos2= new Vector3(66,-0.38f,0); 
    public float speed= 4.0f;
    
    // Update is called once per frame
    void Update()
    {
       transform.position=Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));  
    }
}

