using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float beltSpeed = 1f;
    public float itemFactor = 1.65f;

    private Vector3 displacement;
    private float currentScroll;


    //to store x coord of collision and code of fruit possibly not the most efficent way?
    private Dictionary<float, string> foodOrderConveyor =
            new Dictionary<float, string>();
    
 
 
    private void Update()
    {
        // Scroll texture to fake it moving
        currentScroll = currentScroll + Time.deltaTime * beltSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, currentScroll);
    }

    // This function repeats as long as the object is touching
     private void OnCollisionStay(Collision otherThing)
     {
         // move objects each frame relative to itemSpeed * original position
         displacement = transform.forward * beltSpeed * itemFactor * Time.deltaTime;
         otherThing.rigidbody.MovePosition(otherThing.rigidbody.position + displacement);

         // this adds force instead of displacement but has unexpected behaviour:
         // otherThing.rigidbody.AddForce(displacement / Time.deltaTime, ForceMode.Acceleration);
     }
     
    void OnCollisionEnter(Collision col)
    {
        // not needed as playervariant and playchar are both kinematic objects not driven by physics engine
        //if (col.gameObject.name != playervariant)
        //if (col.gameObject.tag == "the tag of your target"){
        //Make stuff here. add fruit tag to all the food?
    Debug.Log(this.gameObject.name + " has collided with " + col.gameObject.name);
        //quick fix turn on iskinematic when collides so fruit doesnt role around - this will also apply to player variant probably do something in the fruit object rather than this 
        col.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //get contacts from collision and get x out of this 
        ContactPoint contact = col.GetContact(0);

       //this is how you'd get rotation Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        Debug.Log(pos.x);
        //Use tags in future? if col.gameobject.tag = food/fruit then proceed
        GameObject food1 = col.gameObject;

       // foodOrderConveyor.Add(pos.x, food1.GetComponent<BananaScript>().foodCode);


        //i want to nly be able to put it in once, so must be romved every time its picked up, then re inserted in a way that both sorts it and preserves order
        //!!!!! START HERE 


    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name + " has triggered " + other.gameObject.name);
    }
}

