using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* TO DO: 
    - Removing commands from list using undo button
    - What happens when player clicks fruit too many times? if statement
    - Use commands list when checking solution
*/

public class CodeView : MonoBehaviour
{
	public List<string> commands = new List<string>();
	private string command;
    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update the code viewer when a fruit is clicked
    // Add the command to the list of commands
    void OnMouseUp()
    {
    	command = getFruitText();
        commands.Add(command);
        gc.input.Add(command);
        displayCommandInCodeViewer();
        gc.checkWin();
	}

    // Find the command associated with the fruit
    private string getFruitText() {
        GameObject fruit = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        Text fruitText = fruit.GetComponent<Text> () as Text;
        return fruitText.text;
    }

    private void displayCommandInCodeViewer(){
        GameObject content = GameObject.Find("Content");
        GameObject textBox = content.gameObject.transform.GetChild(0).gameObject;
        Text code = textBox.GetComponent<Text> () as Text;
        code.text += command + "\n";
    }
}
