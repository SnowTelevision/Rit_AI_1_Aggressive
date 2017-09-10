using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSensor : MonoBehaviour
{
    public AnimalMuscle muscle;
    public float detectingRange;
    public AvoidPlanning avoidPlanner;

    public RaycastHit hit;

    public RaycastHit rightHit;
    public RaycastHit leftHit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightHit = new RaycastHit();
        leftHit = new RaycastHit();

        if (Physics.Raycast(transform.position + transform.up, transform.up, out hit, detectingRange))
        {
            Debug.DrawRay(transform.position + transform.up, transform.up * 10, Color.green);
            if(hit.transform.tag == "Food")
            {
                muscle.instruction = 2;
            }
        }

        if(Physics.Raycast(transform.position + transform.up + transform.right * 0.6f, transform.up, out rightHit, detectingRange)) //Right side of the animal
        {
            Debug.DrawRay(transform.position + transform.up + transform.right * 0.6f, transform.up * 10, Color.red);

            if (rightHit.transform.tag == "Obstacle")
            {
                avoidPlanner.avoid = true;
            }
        }

        if (Physics.Raycast(transform.position + transform.up - transform.right * 0.6f, transform.up, out leftHit, detectingRange)) //Left side of the animal
        {
            Debug.DrawRay(transform.position + transform.up - transform.right * 0.6f, transform.up * 10, Color.red);

            if (leftHit.transform.tag == "Obstacle")
            {
                avoidPlanner.avoid = true;
            }
        }
    }
}
