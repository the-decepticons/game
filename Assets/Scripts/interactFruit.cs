using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactFruit : MonoBehaviour
{
    public GameObject newObject;
    public Transform newPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // to do: on click, instance new object at target position, destroy original object
    void OnMouseDown()
    {
        Instantiate(newObject, newPosition.position, Quaternion.identity);
    }
}
