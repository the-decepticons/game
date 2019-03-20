using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.
    public GameObject m_Player;                 // Reference to the prefab the players will control.
    public FruitManager[] m_Fruit;              // A collection of managers for enabling and disabling different aspects of the tanks.
    public CharacterManager m_Character;        // A collection of managers for enabling and disabling different aspects of the tanks.


}
