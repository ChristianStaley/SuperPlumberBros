﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairIcon : MonoBehaviour
{
    public Vector3 v3Start;
    public Vector3 v3End;
    public float speed = 2.0f;

    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.localPosition, Vector3.up);
        if(move)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, v3End, Time.deltaTime * speed);
            if (transform.localPosition == v3End)
                move = false;
        }
        
        if(!move)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, v3Start, Time.deltaTime * speed);
            if (transform.localPosition == v3Start)
                move = true;
        }
    }
}
