using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMuscle : MonoBehaviour
{
    /// <summary>
    /// In this project, everything but the animal itself will not move (obstacle won't move, food won't move, and enemies won't chase the animal or flee, so enemies won't move either).
    /// </summary>

    public int instruction; //Each int means one instruction
                            /// <summary>
                            /// 0: Completely Stop
                            /// 1: Wander
                            /// Done
                            /// 2: Move towards food and eat
                            /// Done
                            /// 3: Move towards enemy
                            /// 4: Attack enemy
                            /// 5: Flee
                            /// 6: Avoid obstacle
                            /// Done
                            /// </summary>

    public float turnSpeed;
    public float moveSpeed;
    public float avoidMulti; //How much faster the animal will turn if it is trying to avoid obstacles

    /// <summary>
    /// 1: Wander
    /// </summary>
    public int turnPeriod; //This is only used for wander, the animal will turn and move in one way for this amount of time
    public float lastTurnTime; //Also used for wander, store the last time the animal start make a new turn
    public int turnDirection; //Also used for wander, store a int to give the turning a - or + sign

    /// <summary>
    /// 2: Seek food
    /// </summary>
    public GameObject food;

    /// <summary>
    /// 3: Seek enemy
    /// </summary>
    public GameObject enemy;

    /// <summary>
    /// 4: Atk
    /// </summary>

    /// <summary>
    /// 5: Flee
    /// </summary>

    /// <summary>
    /// 6: Avoid
    /// </summary>
    public bool turnLeft; //If it is true then the animal will turn left to avoid the obstacle, else it will turn right.
    

    // Use this for initialization
    void Start()
    {
        instruction = 0;
        turnPeriod = 0;
        lastTurnTime = 0;
        //transform.rotation.SetLookRotation(transform.up, -transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(instruction == 0)
        {
            return;
        }

        else if(instruction == 1)
        {
            if(Time.time - lastTurnTime > turnPeriod)
            {
                lastTurnTime = Time.time;
                turnPeriod = bRand.betterRandom(0, 3);
                turnDirection = bRand.betterRandom(-50, 49);
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Time.deltaTime * turnSpeed * Mathf.Sign(turnDirection));
            transform.position = transform.position + transform.up * Time.deltaTime * moveSpeed;
        }

        else if (instruction == 2)
        {
            //transform.rotation.SetLookRotation(transform.up, -transform.forward);
            transform.up = Vector3.Normalize(food.transform.position - transform.position);
            //transform.LookAt(food.transform);
            //transform.rotation.SetLookRotation(-transform.up, transform.forward);
            transform.position = transform.position + transform.up * Time.deltaTime * moveSpeed;
        }

        else if (instruction == 3)
        {

        }

        else if (instruction == 4)
        {

        }

        else if (instruction == 5)
        {

        }

        ///
        /// After avoid, the animal will choose a new random direction (turn left or right)
        ///
        else if (instruction == 6)
        {
            //print("Avoid");

            if(turnLeft)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Time.deltaTime * turnSpeed * 1f * avoidMulti);
                transform.position = transform.position + transform.up * Time.deltaTime * moveSpeed;
            }

            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Time.deltaTime * turnSpeed * -1f * avoidMulti);
                transform.position = transform.position + transform.up * Time.deltaTime * moveSpeed;
            }

            lastTurnTime = Time.time;
            turnPeriod = bRand.betterRandom(0, 3);
            turnDirection = bRand.betterRandom(-50, 49);
        }
    }
}