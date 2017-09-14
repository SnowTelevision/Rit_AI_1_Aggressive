using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public AnimalMuscle muscle;
    public MeshRenderer render;

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
        if(other.tag == "Enemy" && !other.gameObject.Equals(transform.parent.gameObject))
        {
            //print("the other enemy");

        }
    }
}
