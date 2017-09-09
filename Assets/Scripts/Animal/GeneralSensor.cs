using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSensor : MonoBehaviour
{
    public AnimalMuscle muscle;
    public float detectingRange;

    public RaycastHit hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position + transform.up, transform.up, out hit, detectingRange))
        {
            Debug.DrawRay(transform.position + transform.up, transform.up * 10, Color.green);
            if(hit.transform.tag == "Food")
            {
                muscle.instruction = 2;
            }
        }

        if(Physics.Raycast(transform.position + transform.up + transform.right * 0.5f, transform.up, out hit, detectingRange))
        {
            Debug.DrawRay(transform.position + transform.up + transform.right * 0.5f, transform.up * 10, Color.red);
            if (hit.transform.tag == "Obstacle")
            {
                muscle.instruction = 6;
            }
        }

        if (Physics.Raycast(transform.position + transform.up - transform.right * 0.5f, transform.up, out hit, detectingRange))
        {
            Debug.DrawRay(transform.position + transform.up - transform.right * 0.5f, transform.up * 10, Color.red);
            if (hit.transform.tag == "Obstacle")
            {
                muscle.instruction = 6;
            }
        }
    }
}
