using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<string> input;
    public List<string> soln;


    // Start is called before the first frame update
    void Start()
    {
        input = new List<string>();
        setSolution();
    }

    void setSolution()
    {
        soln.Add("move_forward()");
        soln.Add("move_forward()");
        soln.Add("move_forward()");
        soln.Add("move_forward()");
        soln.Add("move_forward()");
        soln.Add("open()");
    }

    // Update is called once per frame
    public void checkWin()
    {
        int samecnt = 0;

        for(int i=0; i<(input.Count); i++)
        {
            if (i < soln.Count)
            {
                if (soln[i].Equals(input[i]))
                {
                    samecnt++;
                }
            }
        }

        if ( samecnt == input.Count && input.Count == soln.Count )
        {
            GameObject content = GameObject.Find("Content");
            GameObject textBox = content.gameObject.transform.GetChild(0).gameObject;
            Text code = textBox.GetComponent<Text>() as Text;
            code.text += "Success!" + "\n";
        }
    }

    void Update()
    {

    }
}
