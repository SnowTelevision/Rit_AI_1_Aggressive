using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    public float totalHealth;
    public AnimalMuscle muscle;

    public float currentHealth;
    public float lastAtkTime;
    public bool recovering; // If the animal is recovering

    // Use this for initialization
    void Start()
    {
        currentHealth = 10;
        recovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(muscle.enemy != null && (currentHealth < 0.2f * totalHealth || recovering)) // If an enemy is near and the health is low
        {
            muscle.instruction = 5;
            recovering = true;
        }

        if(currentHealth > 0.7f * totalHealth) // If the health is back up to above 70%
        {
            recovering = false;
        }
    }
}
