using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthRange : MonoBehaviour
{
    public AnimalMuscle muscle;
    public AnimalHealth animalHealth;

    public bool isAttacking; // If the animal is attacking another enemy

    // Use this for initialization
    void Start()
    {
        //animalHealth = FindObjectOfType<AnimalHealth>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            //print("food " + animalHealth.currentHealth);

            if(animalHealth.currentHealth < 10)
            {
                //print("increase health");
                animalHealth.currentHealth++;
                //print("increase health " + animalHealth.currentHealth);
            }

            Destroy(other.gameObject);
            muscle.instruction = 1; // If the food is gone, go back to wandering
            muscle.food = null;
        }

        if (other.tag == "Enemy" && !other.gameObject.Equals(muscle.gameObject))
        {
            isAttacking = true;
            muscle.instruction = 4;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && !other.gameObject.Equals(muscle.gameObject))
        {
            isAttacking = true;
            muscle.instruction = 4;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isAttacking = false;
        }
    }
}
