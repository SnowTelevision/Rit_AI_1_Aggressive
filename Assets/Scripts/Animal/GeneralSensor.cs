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
        hit = new RaycastHit();
        avoidPlanner.avoid = false;

        //Debug.DrawRay(transform.position - transform.up + transform.right * 0.75f * transform.lossyScale.x, transform.up * detectingRange, Color.white);
        //Debug.DrawRay(transform.position - transform.up - transform.right * 0.75f * transform.lossyScale.x, transform.up * detectingRange, Color.white);

        if (Physics.Raycast(transform.position + transform.up, transform.up, out hit, detectingRange))
        {
            if(hit.transform.tag == "Food")
            {
                Debug.DrawRay(transform.position + transform.up, transform.up * hit.distance, Color.green);

                muscle.food = hit.transform.gameObject;
                muscle.instruction = 2;
            }
        }

        if(Physics.Raycast(transform.position - transform.up + transform.right * 0.75f * transform.lossyScale.x, transform.up, out rightHit, detectingRange)) //Right side of the animal
        {
            if (rightHit.transform.tag == "Obstacle" && (muscle.food.Equals(null) || hit.Equals(new RaycastHit()) || rightHit.distance < hit.distance))
            {
                Debug.DrawRay(transform.position - transform.up + transform.right * 0.75f * transform.lossyScale.x, transform.up * rightHit.distance, Color.red);

                avoidPlanner.avoid = true;
            }
        }

        if (Physics.Raycast(transform.position - transform.up - transform.right * 0.75f * transform.lossyScale.x, transform.up, out leftHit, detectingRange)) //Left side of the animal
        {
            if (leftHit.transform.tag == "Obstacle" && (muscle.food.Equals(null) || hit.Equals(new RaycastHit()) || leftHit.distance < hit.distance))
            {
                Debug.DrawRay(transform.position - transform.up - transform.right * 0.75f * transform.lossyScale.x, transform.up * leftHit.distance, Color.red);

                avoidPlanner.avoid = true;
            }
        }
    }
}
