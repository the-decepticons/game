using System.Collections;
using UnityEngine;

[System.Serializable]

public class LevelData
{
    public string name;
    public FruitCodeData[] levelFruits;
    
    public int pointsForCorrectSol;
    public QuestionData levelQuestion;
   // public SolutionData levelSolution;
}


