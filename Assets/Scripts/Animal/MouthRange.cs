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
        animalHealth = FindObjectOfType<AnimalHealth>();
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
            if(animalHealth.currentHealth < 10)
            {
                animalHealth.currentHealth++;
            }

            Destroy(other.gameObject);
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
