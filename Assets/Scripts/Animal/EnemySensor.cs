using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public AnimalMuscle muscle;
    public MeshRenderer render;
    public float nearFoodDistance; // How near the other enemy has to be around the food to be considered near and make animal engage attack
    public AnimalHealth health;
    public MouthRange mouth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !other.gameObject.Equals(muscle.gameObject)) // If the sensor detected an enemy
        {
            //print("the other enemy");
            muscle.enemy = other.gameObject;

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.Equals(muscle.enemy)) // If the enemy detected by the sensor is still within the area
        {
            render.enabled = true;

            if (muscle.food != null // If there is a food around
                && Vector3.Distance(muscle.food.transform.position, other.transform.position) <= nearFoodDistance // and the enemy is near the food
                && !mouth.isAttacking) // and the animal is not attacking already 
                                       //(The script execution order does not affect fixedUpdate, so I manually give the subsumption priority)
            {
                muscle.instruction = 3;
            }

            else if (muscle.food == null) // If there is no food around
            {
                muscle.instruction = 5;
            }
        }

        if (!other.gameObject.Equals(muscle.enemy)) // If the detected object is not the current enemy
        {
            if (other.tag == "Enemy" && !other.gameObject.Equals(muscle.gameObject)) // If the detected object is not the current enemy
            {
                //print("the other enemy");
                muscle.enemy = other.gameObject;

            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(muscle.enemy))
        {
            render.enabled = false;
            muscle.enemy = null;
        }
    }
}
