using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private bool interactableInRange = false;
    private bool itemHeld = false;
    private GameObject interactObject;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && interactableInRange && !itemHeld)
        {
            pickUpCurrentObject();
            itemHeld = true;
        }

        if (Input.GetButtonDown("Fire2") && itemHeld)
        {
            //TO DO - Currently only checks for specific testveg name
            Destroy(gameObject.transform.Find("TestVeg(Clone)").gameObject);
            itemHeld = false;
        }
    }
    

    void OnTriggerEnter(Collider coll)
    {
        //TO DO - Currently only checks for specific testveg name
        if (coll.gameObject.name.Equals("TestVeg")){
            interactableInRange = true;
            interactObject = coll.gameObject;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        //TO DO - Currently only checks for specific testveg name
        if (coll.gameObject.name.Equals("TestVeg"))
        {
            interactableInRange = false;
        }
    }

    void pickUpCurrentObject()
    {
        Instantiate(interactObject, gameObject.transform.GetChild(3).position, new Quaternion(), this.gameObject.transform);
    }
}
