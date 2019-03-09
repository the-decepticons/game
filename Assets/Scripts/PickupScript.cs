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
            Destroy(gameObject.transform.Find("TestVeg(Clone)").gameObject);
            itemHeld = false;
        }
    }
    

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name.Equals("TestVeg")){
            interactableInRange = true;
            interactObject = coll.gameObject;
        }
    }

    void pickUpCurrentObject()
    {
        Instantiate(interactObject, gameObject.transform.GetChild(3).position, new Quaternion(), this.gameObject.transform);
    }
}
