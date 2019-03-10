using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float beltSpeed = 1f;
    public float itemFactor = 1.65f;

    private Vector3 displacement;
    private float currentScroll;

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
}
