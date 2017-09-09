﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMuscle : MonoBehaviour
{
    public int instruction; //Each int means one instruction
                            /// <summary>
                            /// 0: Completely Stop
                            /// 1: Wander
                            /// 2: Move towards food and eat
                            /// 3: Move towards enemy
                            /// 4: Attack enemy
                            /// 5: Flee
                            /// 6: Avoid obstacle
                            /// </summary>

    public float turnSpeed;
    public float moveSpeed;

    public int turnPeriod; //This is only used for wander, the animal will turn and move in one way for this amount of time
    public float lastTurnTime; //Also used for wander, store the last time the animal start make a new turn
    public int turnDirection; //Also used for wander, store a int to give the turning a - or + sign

    // Use this for initialization
    void Start()
    {
        instruction = 0;
        turnPeriod = 0;
        lastTurnTime = 0;
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

        else if (instruction == 6)
        {

        }
    }
}