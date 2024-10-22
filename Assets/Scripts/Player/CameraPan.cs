using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{


    public PlayerMovement player;
    public float deadzone;
    public float followdistance;   
    private Transform target;
    private Vector3 camePos;
    private Vector3 followoffset;
    private Vector3 _mouseDir;
    private void Start()
    {
        target = player.transform;
        followoffset = transform.position - target.position;
      

    }


    public void Update()
    {
        Vector3 mouseDir = player.MouseDirection();

        if(mouseDir.magnitude > deadzone)
        {
            _mouseDir = mouseDir;
        }
        
        camePos = _mouseDir * followdistance + (target.position + followoffset);
       // this.transform.position = target.position + followoffset;
        transform.position = Vector3.Lerp(transform.position, camePos, Time.deltaTime * 10f);
    }


   





}

