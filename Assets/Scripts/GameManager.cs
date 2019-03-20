using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text m_MessageText;
    public GameObject m_PlayerObject;
    public List<GameObject> m_FoodObject;
    public GameObject m_CharacterSpawnLocation;
    public GameObject[] m_FoodSpawnLocation;
    public CharacterManager m_CharacterManager;
    public FoodManager[] m_FoodManager;
    public int m_GameLevel;


    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter();
        SpawnFood();

        // StartCoroutine(GameLoop());
    }


    private void Update()
    {

    }


    private void SpawnCharacter()
    {
        Instantiate(m_PlayerObject, m_CharacterSpawnLocation.transform.position, m_CharacterSpawnLocation.transform.rotation);
    }


    private void SpawnFood()
    {
        Instantiate(m_FoodObject[(int)FoodType.avocado], m_FoodSpawnLocation[0].transform.position, m_FoodSpawnLocation[0].transform.rotation);
        Instantiate(m_FoodObject[(int)FoodType.banana], m_FoodSpawnLocation[1].transform.position, m_FoodSpawnLocation[1].transform.rotation);
        Instantiate(m_FoodObject[(int)FoodType.mushroom], m_FoodSpawnLocation[2].transform.position, m_FoodSpawnLocation[2].transform.rotation);
        Instantiate(m_FoodObject[(int)FoodType.onion], m_FoodSpawnLocation[3].transform.position, m_FoodSpawnLocation[3].transform.rotation);
        Instantiate(m_FoodObject[(int)FoodType.pepper], m_FoodSpawnLocation[4].transform.position, m_FoodSpawnLocation[4].transform.rotation);
        Instantiate(m_FoodObject[(int)FoodType.tomato], m_FoodSpawnLocation[5].transform.position, m_FoodSpawnLocation[5].transform.rotation);
    }


    /*
    IEnumerator GameLoop()
    {

    }
    */
}
