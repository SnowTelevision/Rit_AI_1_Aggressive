﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBack : MonoBehaviour
{
    public GameObject animal;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Border")
        {
            print("border");
            animal.transform.position = (Vector3.zero - other.transform.position) * 0.9f;
        }
    }
}
