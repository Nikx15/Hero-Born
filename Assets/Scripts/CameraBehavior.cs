using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Offset for the camera
    public Vector3 CamOffset = new Vector3(0f, 1.2f, -2.6f);
    // target variable
    private Transform _target;
    void Start()
    {
        // lock onto the player
        _target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        //look at the player with the offset
        this.transform.position = _target.TransformPoint(CamOffset);
        this.transform.LookAt(_target);
    }
}
