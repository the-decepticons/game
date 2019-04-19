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
            dropCurrentObject();
            itemHeld = false;
        }
    }
    

    void OnTriggerEnter(Collider coll)
    {
        //TO DO - Currently only checks for specific testveg name
        if (coll.gameObject.name.Equals("TestVeg") || coll.gameObject.name.Equals("TestVeg(Clone)"))
        {
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
        interactObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        Instantiate(interactObject, gameObject.transform.GetChild(3).position, new Quaternion(), this.gameObject.transform);
    }

    void dropCurrentObject()
    {
        gameObject.transform.Find("TestVeg(Clone)").GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.Find("TestVeg(Clone)").parent = null;
    }
}
