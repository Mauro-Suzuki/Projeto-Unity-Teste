using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTopScore : MonoBehaviour
{
    public Text Label;
    
    private void Awake()
    {

       Label.text = "Top Score: " + PlayerPrefs.GetString("HighScore");
    }


}


/*
 unused code
        //var n = GamePlay.Instance.Score; fix this
        //Label.text += n.ToString();
*/