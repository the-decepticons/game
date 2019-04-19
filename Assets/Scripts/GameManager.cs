using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public Text m_MessageText;
    public Text m_QuestionText;
    public GameObject m_PlayerObject;
    public List<GameObject> m_FoodObject;
    public GameObject m_CharacterSpawnLocation;
    public GameObject[] m_FoodSpawnLocation;
    public CharacterManager m_CharacterManager;
    public FoodManager[] m_FoodManager;
    public int m_GameLevel;
    //set in inspector
    public SimpleObjectPool bananaObjectPool;
    //my stuff
    private DataController dataContoller;
    private LevelData currentLevelData;
    private QuestionData question;
    private SolutionData solution;
    private FruitCodeData[] fruits;
    private bool isLevelActive;
    private List<GameObject> bananaGameObjects = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        //store ref to DC
        dataContoller = FindObjectOfType<DataController>(); // risks associated with usinf ind object of type but can be confident datacontroller to be there because we start from persistent scene
        Debug.Log(dataContoller);
        currentLevelData = dataContoller.GetCurrentLevelData();
        Debug.Log(currentLevelData.name);
        // question 
        question = currentLevelData.levelQuestion;
        //fruits in a level
        fruits = currentLevelData.levelFruits;

        
        
        SpawnCharacter();

        SpawnFruit();
        //SpawnFood();
        //isroundactive = true;
        // StartCoroutine(GameLoop());
    }

    //first thing we want to do is show title in screen
    //then instantiate fruit, player, show question in UI and also show fruit data displayed for this level 
    //could use display of title to make sure fruit elements are got rid of?

    private void ShowLevelTitle()
    {
        //not really necessary but good methodology for when fruit will be removed by oven
        RemoveFruit();
        //display currentLevelData.name

    }

    private void SpawnFruit()
    {
       // m_QuestionText.text = question.questionText;
        //Instantiate fruit that are parts of the level
        
        for (int i = 0; i < currentLevelData.levelFruits.Length; i++)
            
        {   //get banana from object pool and place at spawn location array position
            GameObject bananaGameObject = bananaObjectPool.GetObject();
            
            bananaGameObject.GetComponent<Transform>().position = m_FoodSpawnLocation[i].transform.position;
            bananaGameObject.GetComponent<Transform>().rotation = m_FoodSpawnLocation[i].transform.rotation;
            bananaGameObject.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;

            //iterate through levelfruits passing data into the setup of banana prefab
            bananaGameObject.GetComponent<FruitScript>().SetUp(currentLevelData.levelFruits[i]);
            bananaGameObjects.Add(bananaGameObject);
            


            //does this change the object in bananagameobjects? is it the same as doing before add to array?

            //get banana thats not being used and set it up

            //spawn at random point List<Product> products = GetProducts();
            //products.Shuffle();

        }
    }

    private void RemoveFruit()
    {//foodobjects
        while (bananaGameObjects.Count > 0)
        {
            //send back to object pool to be ready to be reused and then remove from list of active fruit game objects 
            bananaObjectPool.ReturnObject(bananaGameObjects[0]);
            bananaGameObjects.RemoveAt(0);
        }
    }


    private void Update()
    {

    }



    private void SpawnCharacter()
    {
        Instantiate(m_PlayerObject, m_CharacterSpawnLocation.transform.position, m_CharacterSpawnLocation.transform.rotation);
    }

    /*
    private void SpawnFood()
    {

        //Instantiate food object and set transform upon holding to holdposition
        GameObject food1 = Instantiate(m_FoodObject[(int)FoodType.avocado], m_FoodSpawnLocation[0].transform.position, m_FoodSpawnLocation[0].transform.rotation);
        food1.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;

        GameObject food2 = Instantiate(m_FoodObject[(int)FoodType.banana], m_FoodSpawnLocation[1].transform.position, m_FoodSpawnLocation[1].transform.rotation);
        food2.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;

        GameObject food3 = Instantiate(m_FoodObject[(int)FoodType.mushroom], m_FoodSpawnLocation[2].transform.position, m_FoodSpawnLocation[2].transform.rotation);
        food3.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;
        GameObject food4 = Instantiate(m_FoodObject[(int)FoodType.onion], m_FoodSpawnLocation[3].transform.position, m_FoodSpawnLocation[3].transform.rotation);
        food4.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;
        GameObject food5 = Instantiate(m_FoodObject[(int)FoodType.pepper], m_FoodSpawnLocation[4].transform.position, m_FoodSpawnLocation[4].transform.rotation);
        food5.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;
        GameObject food6 = Instantiate(m_FoodObject[(int)FoodType.tomato], m_FoodSpawnLocation[5].transform.position, m_FoodSpawnLocation[5].transform.rotation);
        food6.GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;

        can put this all on one line of code but it looks like this.... 
         Instantiate(m_FoodObject[(int)FoodType.avocado], m_FoodSpawnLocation[0].transform.position, m_FoodSpawnLocation[0].transform.rotation).GetComponent<PickUp>().theDest = GameObject.Find("HoldPosition").transform;
        could maybe do some refactoring   }*/

}
    
  

