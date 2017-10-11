using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimalAndFood : MonoBehaviour
{
    public GameObject animal;
    public GameObject food;
    public LayerMask ignoredLayer;

    public Vector3 mousePos;
    public Vector3 mousePosOnScreen;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -cam.transform.position.z;
        mousePosOnScreen = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(food, mousePosOnScreen, Quaternion.identity);
            //print("LeftClick");
        }

        if (Input.GetMouseButtonUp(1))
        {
            Instantiate(animal, mousePosOnScreen, Quaternion.identity);
            //print("RightClick");
        }

        mousePosOnScreen.z = cam.transform.position.z;
        RaycastHit hit;
        Debug.DrawRay(mousePosOnScreen, Vector3.forward * 100);

        if (Physics.Raycast(mousePosOnScreen, Vector3.forward, out hit, Mathf.Infinity, ~ignoredLayer))
        {
            //print(hit.collider.tag);

            if (hit.collider.tag == "Enemy" || hit.collider.tag == "Food")
            {
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<AnimalHealth>().UI.SetActive(true);
                }

                if (Input.GetMouseButtonUp(2))
                {
                    //print("MiddleClick");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }


}
