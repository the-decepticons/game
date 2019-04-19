using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{   //stores fruittext stored in DC
    public string fruitText;

    private FruitCodeData fruitCodeData;
    
    //when fruit is setup pass in fruitcodedata and store in private FCD
    public void SetUp(FruitCodeData data)
    {
        fruitCodeData = data;
        fruitText = data.fruitCodeText;
    }

    void OnCollisionEnter(Collision col)
    {
        // not needed as playervariant and playchar are both kinematic objects not driven by physics engine
        //if (col.gameObject.name != playervariant)
        //if (col.gameObject.tag == "the tag of your target"){
        //Make stuff here. add fruit tag to all the food?
        Debug.Log(this.gameObject.name + " has collided with " + col.gameObject.name);
        //quick fix turn on iskinematic when collides so fruit doesnt role around - this will also apply to player variant probably do something in the fruit object rather than this 
        if(col.gameObject.name != "Player Variant(Clone)")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }


    }
}
