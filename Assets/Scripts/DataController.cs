using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//so we can load scenes
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public LevelData[] allLevelData;
    // Start is called before the first frame update
    void Start()
    {
        //normally when scenes are loaded previous objects that are unloaded from previous secene are destoryed by setting this object to DDOL this will persist
        //the way this appears in the UI is moved into a separate scene called DDOL which never gets unloaded
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Game");

        
    }
    //later on will likely pass in integer to select what round we are in from allleveldata[]
    public LevelData GetCurrentLevelData()
    {
        return allLevelData[0];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
