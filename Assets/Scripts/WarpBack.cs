using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBack : MonoBehaviour
{
    public GameObject animal;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Repeat(transform.position.x, 40f), Mathf.Repeat(transform.position.y, 40f), 0);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Border")
    //    {
    //        print("border");
    //        animal.transform.position = (Vector3.zero - other.transform.position) * 0.9f;
    //    }
    //}
}
