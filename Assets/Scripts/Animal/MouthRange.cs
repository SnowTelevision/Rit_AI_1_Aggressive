using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthRange : MonoBehaviour
{
    public AnimalMuscle muscle;
    public AnimalHealth animalHealth;

    // Use this for initialization
    void Start()
    {
        animalHealth = FindObjectOfType<AnimalHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            if(animalHealth.health < 10)
            {
                animalHealth.health++;
            }

            Destroy(other.gameObject);
        }

    }
}
