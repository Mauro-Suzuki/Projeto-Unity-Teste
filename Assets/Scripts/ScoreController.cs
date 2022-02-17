using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
    
[System.Serializable]
public class MyIntEvent : UnityEvent<uint>
{

}
public class ScoreController : MonoBehaviour 
{
    public Text ScoreLabel;
    public static uint Score = 0;
    public MyIntEvent onScore;
    public void Start()
    {
        var briks = FindObjectsOfType<BrikController>(); //find all the objects with the brikController script
        foreach (var brik in briks)//This will add every brik in an array an also add listener in every one for the onBreak event.
        {
            brik.onBreak.AddListener(AddScore);
        }
        if (onScore == null)
            onScore = new MyIntEvent();
    }

    
    public void AddScore()
    {
        Score++;
        ScoreLabel.text = Score.ToString();
        onScore.Invoke(Score);
    }


}
