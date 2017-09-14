using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlanning : MonoBehaviour
{
    public AnimalMuscle muscle;
    public GeneralSensor obstacleSensor;

    public bool avoid;
    public GameObject currentObstacle; //The current obstacle the animal is trying to avoid.

    // Use this for initialization
    void Start()
    {
        avoid = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (avoid)
        {
            //print(obstacleSensor.rightHit.transform.name);
            //print(obstacleSensor.leftHit.transform.name);

            muscle.instruction = 6;

            if (!obstacleSensor.rightHit.Equals(new RaycastHit()))
            {
                if(obstacleSensor.rightHit.transform.gameObject.Equals(currentObstacle)) //If the new ray is hitting the current obstacle the animal is trying to avoid
                {
                    //print("right hit same: " + currentObstacle);
                    return;
                }

                if (Vector3.Cross(-transform.up, obstacleSensor.rightHit.normal).z > 0) //Means the ray is on the left side of the normal of the surface it hits
                {
                    muscle.turnLeft = false;

                    //print("rightHit, turn right");
                }
                else
                {
                    muscle.turnLeft = true;

                    //print("rightHit, turn left");
                }

                muscle.instruction = 6;
            } //End rightHit

            if (!obstacleSensor.leftHit.Equals(new RaycastHit()))
            {
                if (obstacleSensor.leftHit.transform.gameObject.Equals(currentObstacle)) //If the new ray is hitting the current obstacle the animal is trying to avoid
                {
                    //print("left hit same: " + currentObstacle);
                    return;
                }

                if (obstacleSensor.rightHit.Equals(new RaycastHit())) //If only left ray hit an obstacle
                {
                    if (Vector3.Cross(-transform.up, obstacleSensor.leftHit.normal).z > 0) //Means the ray is on the left side of the normal of the surface it hits
                    {
                        muscle.turnLeft = false;

                        //print("left, turn right");
                    }
                    else
                    {
                        muscle.turnLeft = true;

                        //print("left, turn left");
                    }

                    muscle.instruction = 6;
                } //End only left hit

                else if (obstacleSensor.leftHit.distance < obstacleSensor.rightHit.distance) // Or if the left ray is nearer to an obstacle than the right ray
                {
                    if (!obstacleSensor.leftHit.collider.gameObject.Equals(obstacleSensor.rightHit.collider.gameObject) || obstacleSensor.leftHit.normal.Equals(obstacleSensor.rightHit.normal)) //If the left ray hit on a different obstacle than the right ray, or they hit the same surface of the same obstacle
                    {
                        if (Vector3.Cross(-transform.up, obstacleSensor.leftHit.normal).z > 0) //Means the ray is on the left side of the normal of the surface it hits
                        {
                            muscle.turnLeft = false;

                            //print("left, turn right");
                        }
                        else
                        {
                            muscle.turnLeft = true;

                            //print("left, turn left");
                        }

                        muscle.instruction = 6;
                    } //End if the left ray hit on a different obstacle than the right ray, or they hit the same surface of the same obstacle
                } //End if left is nearer
            } //End leftHit

            if(!obstacleSensor.rightHit.Equals(new RaycastHit()) && obstacleSensor.rightHit.transform.tag == "Obstacle")
            {
                //print("assign new obstacle: " + obstacleSensor.rightHit.transform.name);
                currentObstacle = obstacleSensor.rightHit.transform.gameObject;
            }

            else if(!obstacleSensor.leftHit.Equals(new RaycastHit()) && obstacleSensor.leftHit.transform.tag == "Obstacle")
            {
                //print("assign new obstacle: " + obstacleSensor.leftHit.transform.name);
                currentObstacle = obstacleSensor.leftHit.transform.gameObject;
            }

        } //End avoid
    } //End Update()
}
