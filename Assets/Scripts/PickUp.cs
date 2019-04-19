using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
   
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        //set position of transform to theDest 
        this.transform.position = theDest.position;
        //parent with hold destination  
        this.transform.parent = GameObject.Find("HoldPosition").transform;
    }

    
    void OnMouseUp()
    {   //parent goes to independent object
        this.transform.parent = null;
    
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
